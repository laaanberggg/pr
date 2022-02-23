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
using System.Windows.Shapes;

namespace murzaev

{
    /// <summary>
    /// Логика взаимодействия для EditWin.xaml
    /// </summary>
    public partial class EditWin : Window
    {
        polzovateli _user;
        public EditWin(polzovateli user)
        {
            InitializeComponent();
            _user = user;
            tbNewName.Text = user.name;
            tbNewSurname.Text = user.surname;
            tbNewLogin.Text = user.login;
        }

        private void buttSend_Click(object sender, RoutedEventArgs e)
        {
            _user.name = tbNewName.Text;
            _user.surname = tbNewSurname.Text;
            _user.login = tbNewLogin.Text;
            _user.password = tbNewPass.Password.GetHashCode();
            Base.DB.SaveChanges();
            MessageBox.Show("Данные обновлены!", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            this.Close();
        }
    }
}
