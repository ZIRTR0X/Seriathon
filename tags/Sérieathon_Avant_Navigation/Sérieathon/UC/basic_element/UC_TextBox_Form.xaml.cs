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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sérieathon.UC.basic_element
{
    /// <summary>
    /// Interaction logic for UC_TextBox_Form.xaml
    /// </summary>
    public partial class UC_TextBox_Form : UserControl
    {
        public UC_TextBox_Form()
        {
            InitializeComponent();
        }

        public string Message
        {
            set
            {
                TextBox_form.Text = value;
            }
        }

    }
}
