using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using DevExpress.Xpf.Spreadsheet;
using DevExpress.Xpf.Spreadsheet.Internal;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfApplication2
{
    public class HeaderConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value[0] == null)
                return null;
            string columnHeader = value[0].ToString();
            ObservableCollection<CustomHeaderCaption> collection = value[1] as ObservableCollection<CustomHeaderCaption>;
            if (collection == null || collection.Count == 0)
                return columnHeader;

            string result = collection.Where(l => l.OriginalCaption == columnHeader).Select(caption => caption.NewHeader).FirstOrDefault();
            if (result != null)
                return result;

            return columnHeader;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
