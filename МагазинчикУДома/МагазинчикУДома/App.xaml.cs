using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace МагазинчикУДома
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static user55Entities DB = new user55Entities();
        public static user usi = new user();
        public static Tovars tov = new Tovars();
    }
}
