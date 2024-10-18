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
            control.DataBindings.Add(new Binding(controlPropName, dataSource, sourcePropName,
                false,
                DataSourceUpdateMode.OnPropertyChanged));

            // Валидация
            if (validationProvider != null)
            {
                var sourcePropInfo = dataSource.GetType().GetProperty(sourcePropName);
                if (sourcePropInfo != null)
                {
                    var validators = sourcePropInfo.GetCustomAttributes<ValidationAttribute>();
                    if (validators?.Any() == true)
                    {
                        control.Validating += (s, e) =>
                        {
                            var context = new ValidationContext(dataSource);
                            var validationResults = new List<ValidationResult>();
                            validationProvider.SetError(control, string.Empty);
                            if (!Validator.TryValidateObject(dataSource, context, validationResults, validateAllProperties: true))
                            {
                                foreach (var validationError in validationResults.Where(x => x.MemberNames.Contains(sourcePropName)))
                                {
                                    validationProvider.SetError(control, validationError.ErrorMessage);
                                    Debug.WriteLine($"Ошибка в поле {sourcePropName}: {validationError.ErrorMessage}");
                                }
                            }
                        };
                    }
                }
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
                if (attributes != null && attributes.Length > 0)
                {
                    description = ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return description;
        }
    }
}
