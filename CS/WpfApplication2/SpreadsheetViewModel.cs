using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace WpfApplication2
{
    public class SpreadsheetViewModel 
    {
        ObservableCollection<CustomHeaderCaption> _Captions;
        public SpreadsheetViewModel()
        {
            Captions = new ObservableCollection<CustomHeaderCaption>();
            FillCaptions();
        }
        public ObservableCollection<CustomHeaderCaption> Captions
        {
            get
            {
                return _Captions;
            }
            set
            {
                _Captions = value;
            }
        }

        void FillCaptions()
        {
            Captions.Add(new CustomHeaderCaption("A", "Column 1"));
            Captions.Add(new CustomHeaderCaption("B", "Column 2"));
            Captions.Add(new CustomHeaderCaption("C", "Column 3"));

            Captions.Add(new CustomHeaderCaption("1", "Row 1"));
            Captions.Add(new CustomHeaderCaption("2", "Row 2"));
            Captions.Add(new CustomHeaderCaption("3", "Row 3"));
        }
    }

    public class CustomHeaderCaption
    {
        public string OriginalCaption
        {
            get;
            set;
        }

        public string NewHeader
        {
            get;
            set;
        }
        public CustomHeaderCaption(string oldText, string newText)
        {
            this.OriginalCaption = oldText;
            this.NewHeader = newText;
        }


    }
}
