using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prakticke_zadani.View
{
    /// <summary>
    /// Interaction logic for warning.xaml
    /// </summary>
    public partial class warning : Window
    {
        public warning(String msg)
        {
            InitializeComponent();
            textBox.Text = msg;
        }

        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
