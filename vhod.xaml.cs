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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class vhod : Page
    {
        string path = "Users.csv";
        List<polz> Users = new List<polz>();
        public vhod()
        {
            InitializeComponent();
        }

        private void buttAuthPage_Click(object sender, RoutedEventArgs e)
        {
            int passCode = tbPassAuth.Password.GetHashCode();
            polzovateli User = Base.DB.polzovateli.FirstOrDefault(x => x.login == tbLogAuth.Text && x.password == passCode);
            if (User != null)
            {
                if (User.admin == true)
                {
                    MessageBox.Show("Добро пожаловать на борт, капитан " + User.name, "Авторизация", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    frame.mainFrame.Navigate(new adminka(User));
                }
                else
                {
                    MessageBox.Show("Здравствуйте, " + User.name, "Авторизация", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    frame.mainFrame.Navigate(new UserCabinet(User, false));
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден, повторите ввод или зарегистрируйтесь!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void cancelAuthPage_Click(object sender, RoutedEventArgs e)
        {
            frame.mainFrame.Navigate(new space());
        }
    }
}
