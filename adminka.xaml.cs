using System.Windows;
using System.Windows.Controls;

namespace murzaev
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class adminka : Page
    {
        private polzovateli _user;
        public adminka(polzovateli user)
        {
            InitializeComponent();
            _user = user;
            frame.adminFrame = AdminFrame;
        }

        private void buttUserShow_Click(object sender, RoutedEventArgs e)
        {
            frame.adminFrame.Navigate(new adUsers());
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            frame.mainFrame.Navigate(new space());
        }

        private void buttZanyat_Click(object sender, RoutedEventArgs e)
        {
            frame.adminFrame.Navigate(new adSpCs());
        }

        private void buttNewBron_Click(object sender, RoutedEventArgs e)
        {
            frame.adminFrame.Navigate(new createEdit());
        }

        private void buttAcc_Click(object sender, RoutedEventArgs e)
        {
            frame.mainFrame.Navigate(new UserCabinet(_user, true));
        }

        private void buttZapis_Click(object sender, RoutedEventArgs e)
        {
            frame.adminFrame.Navigate(new newBron());
        }
    }
}

