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

namespace murzaev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.mainFrame = mainFrame;
            frame.mainFrame.Navigate(new unknow());
        }

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            frame.mainFrame.Navigate(new vhod());
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            frame.mainFrame.Navigate(new reg());
        }
    }
}
