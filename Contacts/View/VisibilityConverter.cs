using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace View
{
    /// <summary>
    /// Реализует конвертер значений.
    /// </summary>
    public class VisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Конвертирует булевое значение в значение состояния отображения элемента.
        /// </summary>
        /// <param name="value">Значение, которое надо преобразовать.</param>
        /// <param name="targetType">Тип, к которому надо преобразовать значение value.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns>Отображать элемент, если входное значение true, и скрывать элемент - если false.</returns>
        public object Convert(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }

        /// <summary>
        /// Конвертирует значение состояния отображения элемента в булевое значение.
        /// </summary>
        /// <param name="value">Значение, которое надо преобразовать.</param>
        /// <param name="targetType">Тип, к которому надо преобразовать значение value.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns>True, если элемент отображается. False - если нет.</returns>
        public object ConvertBack(
            object value,
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
