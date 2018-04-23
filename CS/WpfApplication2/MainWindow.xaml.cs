using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

namespace WpfApplication2 {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
            ssControl1.LoadDocument("Book1.xlsx");
		}
	}

  
}
