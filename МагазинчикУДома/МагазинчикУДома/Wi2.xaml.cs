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
using Word = Microsoft.Office.Interop.Word;

namespace МагазинчикУДома
{
    /// <summary>
    /// Логика взаимодействия для Wi2.xaml
    /// </summary>
    public partial class Wi2 : Window
    {
        public Wi2()
        {
            InitializeComponent();
            Title = App.usi.name;
            update();
        }

        public void update()
        {
            var List = App.DB.Tovars.ToList();
            if (poisk.Text.Trim() != "")
            {
                List = App.DB.Tovars.Where(p => p.name.Contains(poisk.Text)).ToList();
            }
            ListVi.ItemsSource = List;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            ADDWindow ad = new ADDWindow();
            ad.Show();
            Close();
        }

        private void ChahceClick(object sender, RoutedEventArgs e)
        {
            var stroka = (Button)sender;
            var izm = (Tovars)stroka.DataContext;
            App.tov = izm;
            ChangeWindow changeWindow = new ChangeWindow();
            changeWindow.Show();
            Close();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            var stroka = (Button)sender;
            var del = (Tovars)stroka.DataContext;
            MessageBox.Show("Tavar budet udalen");
            App.DB.Tovars.Remove(del);
            App.DB.SaveChanges();
            update();
        }

        private void up(object sender, TextChangedEventArgs e)
        {
            update();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            var Li = App.DB.Tovars.ToList();
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();
            Word.Paragraph par = document.Paragraphs.Add();
            Word.Range range = par.Range;

            Word.Table tab = document.Tables.Add(range, Li.Count(), 3);
            
        }
    }
}
