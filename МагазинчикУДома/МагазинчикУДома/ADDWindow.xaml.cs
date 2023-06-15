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
    /// Логика взаимодействия для ADDWindow.xaml
    /// </summary>
    public partial class ADDWindow : Window
    {
        public ADDWindow()
        {
            InitializeComponent();
            box();
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

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if(nam.Text.Trim() != "" && cat.Text.Trim() != "" && pr.Text.Trim() != "")
            {
                var categ = App.DB.Categories.Where(p => p.nameC == cat.Text).FirstOrDefault();
                Tovars tovars = new Tovars()
                {
                    name = nam.Text,
                    price = Convert.ToInt32(pr.Text),
                    idCatigorie = categ.id
                };
                App.DB.Tovars.Add(tovars);
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
