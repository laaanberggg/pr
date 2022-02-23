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
    /// Логика взаимодействия для adSpCs.xaml
    /// </summary>
    public partial class adSpCs : Page
    {
        public adSpCs()
        {
            InitializeComponent();
            lvSpCs.ItemsSource = Base.DB.rezh.ToList();
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<rezhrasp> TC = Base.DB.rezhrasp.Where(x => x.rrid == index).ToList();
            string str = "";
            foreach (rezhrasp item in TC)
            {
                str += item.causes.causeArend.ToString() + "\n";
            }
            tb.Text = str;
        }
    }
}
