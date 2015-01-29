using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VariablesTypes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Type> _types = new List<Type>()
        {
            typeof (byte),
            typeof (int),
            typeof (float),
            typeof (double),
            typeof (string),
            typeof (bool)
        }; 
        public MainWindow()
        {
            InitializeComponent();
            cmb.ItemsSource = _types;
            cmb.SelectionChanged += cmb_SelectionChanged;
        }

        void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = (Type) cmb.SelectedItem;
            if (selectedType == typeof(byte))
            {
                GetByteInformation();
            }
            if (selectedType == typeof(int))
            {
                GetIntInformation(selectedType);
            }
            if (selectedType == typeof(string))
            {

            }
        }

        private void GetByteInformation()
        {
           
        }

        private void GetIntInformation(Type selectedType)
        {
            var inf = string.Format("Type = {0} \n " +
                                    "Type Integer represent Whole Number \n"+
                                    "Integer Max Value = {1} \n" +
                                    "Integer Min Value = {2} \n", selectedType,int.MaxValue,int.MinValue);

            txt.Text = inf;
            palceHolder.Content = new IntegerPanel();
        }


      
      
    }
}
