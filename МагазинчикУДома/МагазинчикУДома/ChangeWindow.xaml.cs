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

namespace МагазинчикУДома
{
    /// <summary>
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        public ChangeWindow()
        {
            InitializeComponent();
            box();
            update();
        }

        public void update()
        {
            
            var iz = App.tov;
            pr.Text = iz.price.ToString();
            nam.Text = iz.name;
            var li = App.DB.Categories.Where(p => p.id == iz.idCatigorie).FirstOrDefault();
            cat.Text = li.nameC;
        }

        public void box()
        {
            var List = App.DB.Categories.ToList();
            List<string> list = new List<string>();
            foreach (var li in List)
            {
                list.Add(li.nameC);
            }
            cat.ItemsSource = list;
        }

        private void ChangeClick(object sender, RoutedEventArgs e)
        {

            if (nam.Text.Trim() != "" && cat.Text.Trim() != "" && pr.Text.Trim() != "")
            {
                var ro = App.DB.Tovars.Where(p => p.id == App.tov.id).FirstOrDefault();
                var categ = App.DB.Categories.Where(p => p.nameC == cat.Text).FirstOrDefault();
                ro.name = nam.Text.Trim();
                ro.price = Convert.ToInt32(pr.Text.Trim());
                ro.idCatigorie = categ.id;
                App.DB.SaveChanges();
                Wi2 wi = new Wi2();
                wi.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Не заполнены поля");
            }

        }
    }
}
