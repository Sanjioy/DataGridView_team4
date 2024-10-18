using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace DataGridView_team4
{
    /// <summary>
    /// Расширения для различных классов
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Создание привязки между двумя объектами
        /// </summary>
        public static void BindData<TControl, TSource>(this TControl control,
            Expression<Func<TControl, object>> controlProperty,
            TSource dataSource,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider validationProvider = null)
            where TControl : Control
            where TSource : class
        {
            var controlPropName = GetPropertyName(controlProperty);
            var sourcePropName = GetPropertyName(sourceProperty);

            BindControlToSource(control, controlPropName, dataSource, sourcePropName);
            SetupValidationIfNeeded(control, dataSource, sourcePropName, validationProvider);
        }

        /// <summary>
        /// Привязка свойства управления к источнику данных
        /// </summary>
        private static void BindControlToSource<TControl, TSource>(TControl control,
            string controlPropName, TSource dataSource, string sourcePropName)
            where TControl : Control
            where TSource : class
        {
            control.DataBindings.Add(new Binding(controlPropName, dataSource, sourcePropName,
                false, DataSourceUpdateMode.OnPropertyChanged));
        }

        /// <summary>
        /// Настройка валидации при необходимости
        /// </summary>
        private static void SetupValidationIfNeeded<TControl, TSource>(TControl control,
            TSource dataSource, string sourcePropName, ErrorProvider validationProvider)
            where TControl : Control
            where TSource : class
        {
            if (validationProvider == null)
            {
                return;
            }
            var sourcePropInfo = dataSource.GetType().GetProperty(sourcePropName);
            if (sourcePropInfo == null)
            {
                return;
            }

            var validators = sourcePropInfo.GetCustomAttributes<ValidationAttribute>();
            if (validators?.Any() == true)
            {
                control.Validating += (s, e) =>
                {
                    PerformValidation(control, dataSource, sourcePropName, validationProvider);
                };
            }
        }

        /// <summary>
        /// Выполнение валидации
        /// </summary>
        private static void PerformValidation<TSource>(Control control, TSource dataSource,
            string sourcePropName, ErrorProvider validationProvider)
            where TSource : class
        {
            var context = new ValidationContext(dataSource);
            var validationResults = new List<ValidationResult>();
            validationProvider.SetError(control, string.Empty);

            if (!Validator.TryValidateObject(dataSource, context, validationResults, validateAllProperties: true))
            {
                DisplayValidationErrors(validationResults, sourcePropName, control, validationProvider);
            }
        }

        /// <summary>
        /// Отображение ошибок валидации
        /// </summary>
        private static void DisplayValidationErrors(IEnumerable<ValidationResult> validationResults,
            string sourcePropName, Control control, ErrorProvider validationProvider)
        {
            foreach (var validationError in validationResults.Where(x => x.MemberNames.Contains(sourcePropName)))
            {
                validationProvider.SetError(control, validationError.ErrorMessage);
                Debug.WriteLine($"Ошибка в поле {sourcePropName}: {validationError.ErrorMessage}");
            }
        }

        /// <summary>
        /// Получить имя свойства объекта
        /// </summary>
        private static string GetPropertyName<TItem, TMember>(Expression<Func<TItem, TMember>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            if (propertyExpression.Body is UnaryExpression unaryExpression)
            {
                var operand = unaryExpression.Operand as MemberExpression;
                return operand.Member.Name;
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Получить описание поля enum
        /// </summary>
        public static string GetEnumDisplayValue<T>(this T enumValue)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                return null;
            }

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attributes.Length > 0)
                {
                    description = ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return description;
        }
    }
}
