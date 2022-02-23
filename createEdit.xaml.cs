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
    /// Логика взаимодействия для createEdit.xaml
    /// </summary>
    public partial class createEdit : Page
    {
        rasp Lesson = new rasp();
        int index = 0;
        bool createFlag = false;
        public createEdit()
        {
            InitializeComponent();
            cbCourse.ItemsSource = Base.DB.causes.ToList();
            cbCourse.SelectedValuePath = "IDCourse";
            cbCourse.DisplayMemberPath = "НазваниеКурса";
            createFlag = true;
        }
        public createEdit(rasp lessUpd)
        {
            InitializeComponent();
            cbCourse.ItemsSource = Base.DB.causes.ToList();
            cbCourse.SelectedValuePath = "IDCourse";
            cbCourse.DisplayMemberPath = "НазваниеКурса";

            Lesson = lessUpd;

            tbTheme.Text = lessUpd.Тема;
            dpDate.SelectedDate = lessUpd.Дата;
            tbPrive.Text = lessUpd.Стоимость.ToString();
            cbCourse.SelectedIndex = (int)lessUpd.Курс - 1;
            cbSpeaker.SelectedIndex = (int)lessUpd.Ведущий - 1;
        }
        private void buttCreate_Click(object sender, RoutedEventArgs e)
        {
            if (cbSpeaker.SelectedItem == null)
            {
                MessageBox.Show("Ошибка! Проверьте ввод и повторите", "Создание занятия", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int idSpeaker = 1;
                switch (cbSpeaker.SelectedItem.ToString())
                {
                    case "Мухина Л.В.":
                        idSpeaker = 1;
                        break;
                    case "Мухин Н.А.":
                        idSpeaker = 2;
                        break;
                    case "Дергачев Д.А.":
                        idSpeaker = 3;
                        break;
                    case "Тараканова Н.А.":
                        idSpeaker = 4;
                        break;
                }
                Lesson.Курс = cbCourse.SelectedIndex + 1;
                Lesson.Тема = tbTheme.Text;
                Lesson.Ведущий = idSpeaker;
                Lesson.Дата = (DateTime)dpDate.SelectedDate;
                Lesson.Стоимость = Int32.Parse(tbPrive.Text);
                if (createFlag == true)
                {
                    Base.DB.rasp.Add(Lesson);
                }
                Base.DB.SaveChanges();
                MessageBox.Show("Занятие успешно записано!", "Запись занятия", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void lbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbSpeaker.Items.Clear();
            index = cbCourse.SelectedIndex + 1;
            List<rezhrasp> CS = Base.DB.rezhrasp.Where(x => x.rrid == index).ToList();
            foreach (rezh Speaker in Base.DB.rezh)
            {
                if (CS.FirstOrDefault(x => x.rrid == Speaker.rezhid) != null)
                {
                    cbSpeaker.Items.Add(Speaker.rezhfio);
                }
            }
        }
    }
}
