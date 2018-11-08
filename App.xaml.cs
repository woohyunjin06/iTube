using iTube.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace iTube
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string SHORT_SERVER_URI = "10.80.161.143";
        public static string SERVER_URI = "http://" + SHORT_SERVER_URI + "/itube";

        public static ListViewModel listViewModel = null;
        public static PlayViewModel playViewModel = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            listViewModel = new ListViewModel();
            playViewModel = new PlayViewModel();
            base.OnStartup(e);
        }
    }
}
