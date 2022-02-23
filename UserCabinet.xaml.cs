using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для UserCabinet.xaml
    /// </summary>
    public partial class UserCabinet : Page
    {
        private bool _tumbler;
        private polzovateli _user;
        private string _path;
        private userPhoto _userPic;
        public UserCabinet(polzovateli User, bool tumbler)
        {
            InitializeComponent();
            _tumbler = tumbler;
            _user = User;
            tbName.Text = _user.name;
            tbSurname.Text = _user.surname;
            tbLogin.Text = _user.login;
            if (User.polzovateli != null && User.polzovateli.photo != null)
            {
                byte[] binArr = User.userPhoto.photo;
                BitmapImage bmUserPic = new BitmapImage();
                using (MemoryStream ms = new MemoryStream(binArr))
                {
                    bmUserPic.BeginInit();
                    bmUserPic.StreamSource = ms;
                    bmUserPic.CacheOption = BitmapCacheOption.OnLoad;
                    bmUserPic.EndInit();
                }
                UserPic.Source = bmUserPic;
            }
        }

        private void ButtEditClick(object sender, RoutedEventArgs e)
        {
            EditWin editWin = new EditWin(_user);
            editWin.ShowDialog();
            frame.mainFrame.Navigate(new UserCabinet(_user, _tumbler));
        }

        private void PicEditClick(object sender, RoutedEventArgs e)
        {
            userPhoto picture = Base.DB.userPhoto.FirstOrDefault(x => x.userid == _user.userid);
            if (picture == null)
            {
                _userPic = new userPhoto();
                _userPic.userid = _user.userid;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                _path = OFD.FileName;
                System.Drawing.Image sdImage = System.Drawing.Image.FromFile(_path);
                ImageConverter imageConverter = new ImageConverter();
                byte[] binArr = (byte[])imageConverter.ConvertTo(sdImage, typeof(byte[]));
                _userPic.photo = binArr;
                Base.DB.userPhoto.Add(_userPic);
                Base.DB.SaveChanges();
                MessageBox.Show("Фото добавлено в профиль!", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                _path = OFD.FileName;
                System.Drawing.Image sdImage = System.Drawing.Image.FromFile(_path);
                ImageConverter imageConverter = new ImageConverter();
                byte[] binArr = (byte[])imageConverter.ConvertTo(sdImage, typeof(byte[]));
                picture.photo = binArr;
                Base.DB.SaveChanges();
                MessageBox.Show("Фото обновлено!", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            frame.mainFrame.Navigate(new UserCabinet(_user, _tumbler));
        }

        private void ButtExitClick(object sender, RoutedEventArgs e)
        {
            if (_tumbler == true)
            {
                frame.mainFrame.Navigate(new adminka(_user));
            }
            else
            {
                frame.mainFrame.Navigate(new space());
            }
        }
    }
}
