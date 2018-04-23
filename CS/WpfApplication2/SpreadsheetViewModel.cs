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
    public class SpreadsheetViewModel:INotifyPropertyChanged
    {
        ObservableCollection<CustomHeaderCaption> _Captions;
        public SpreadsheetViewModel()
        {
            Captions = new ObservableCollection<CustomHeaderCaption>();
            Captions.CollectionChanged += Captions_CollectionChanged;
            EmptyDocumentCreatedCommand = new DelegateCommand<object>(EmptyDocumentCreatedExecute);
            DocumentLoadedCommand = new DelegateCommand<object>(DocumentLoadedCommandExecute);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(String propertyName = "") {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        void Captions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            NotifyPropertyChanged("Captions");
        }
        public ICommand DocumentLoadedCommand {
            get;
            private set;
        }
        public ICommand EmptyDocumentCreatedCommand {
            get;
            private set;
        }
        public ObservableCollection<CustomHeaderCaption> Captions {
            get {
                return _Captions;
            }
            set {
                _Captions = value;
                NotifyPropertyChanged("Captions");
            }
        }

        void EmptyDocumentCreatedExecute(object sender) {
            Captions.Clear();
        }
        void DocumentLoadedCommandExecute(object sender) {
            FillCaptions();
        }
      
        void FillCaptions() {
            Captions.Add(new CustomHeaderCaption("A", "Column 1"));
            Captions.Add(new CustomHeaderCaption("B", "Column 2"));
            Captions.Add(new CustomHeaderCaption("C", "Column 3"));
        }
    }

    public class CustomHeaderCaption
    {
        public string OriginalCaption {
            get;
            set;
        }

        public string NewHeader {
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
