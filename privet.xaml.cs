using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class privet : Page
    {
        List<theatre> Search;
        List<theatre> Theatre = new List<theatre>();
        public privet()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Data.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] Arr = sr.ReadLine().Split(';');
                    Theatre.Add(new theatre() { bron = Arr[0], theme = Arr[1], rezh = Arr[2], data = Arr[3], time = Arr[4] });
                }
            }
            dgTheatre.ItemsSource = Theatre;
            cbBron.IsChecked = true;
            cbTheme.IsChecked = true;
            cbRezh.IsChecked = true;
            cbData.IsChecked = true;
            cbTime.IsChecked = true;
        }

        private void cbBron_Checked(object sender, RoutedEventArgs e)
        {
            Bron.Visibility = Visibility.Visible;
        }

        private void cbTheme_Checked(object sender, RoutedEventArgs e)
        {
            Theme.Visibility = Visibility.Visible;
        }

        private void cbRezh_Checked(object sender, RoutedEventArgs e)
        {
            Rezh.Visibility = Visibility.Visible;
        }

        private void cbData_Checked(object sender, RoutedEventArgs e)
        {
            Data.Visibility = Visibility.Visible;
        }

        private void cbTime_Checked(object sender, RoutedEventArgs e)
        {
            Time.Visibility = Visibility.Visible;
        }

        private void cbBron_Unchecked(object sender, RoutedEventArgs e)
        {
            Bron.Visibility = Visibility.Hidden;
        }

        private void cbTheme_Unchecked(object sender, RoutedEventArgs e)
        {
            Theme.Visibility = Visibility.Hidden;
        }

        private void cbRezh_Unchecked(object sender, RoutedEventArgs e)
        {
            Rezh.Visibility = Visibility.Hidden;
        }

        private void cbData_Unchecked(object sender, RoutedEventArgs e)
        {
            Data.Visibility = Visibility.Hidden;
        }

        private void cbTime_Unchecked(object sender, RoutedEventArgs e)
        {
            Time.Visibility = Visibility.Hidden;
        }

        private void buttSearch_Click(object sender, RoutedEventArgs e)
        {
            Search = new List<theatre>();
            if (rbBron.IsChecked == true)
            {
                for (int i = 0; i < Theatre.Count; i++)
                {
                    if (tbSearch.Text == Theatre[i].bron)
                    {
                        theatre search = new theatre
                        {
                            bron = Theatre[i].bron,
                            theme = Theatre[i].theme,
                            rezh = Theatre[i].rezh,
                            data = Theatre[i].data,
                            time = Theatre[i].time,
                        };
                        Search.Add(search);
                    }
                }
            }
            try
            {
                dgTheatre.ItemsSource = Search;
            }
            catch
            {
                MessageBox.Show("Проверьте ввод", "Ошибка!");
            }
        }

        private void buttClear_Click(object sender, RoutedEventArgs e)
        {
            frame.mainFrame.Navigate(new privet());
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            frame.mainFrame.Navigate(new space());
        }
    }
}
