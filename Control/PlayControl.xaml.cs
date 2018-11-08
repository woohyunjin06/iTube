using iTube.Model;
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

namespace iTube.Control
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayControl : UserControl
    {
        public PlayControl()
        {
            InitializeComponent();
            this.Loaded += PlayControl_Loaded;
        }

        private void PlayControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.playViewModel;
        }

        public void PlayVideo(Video video)
        {
            videoControl.PlayVideo(video.VideoLink);
            App.playViewModel.CurrentVideo = video;
        }

        public void BackPressed()
        {
            videoControl.StopVideo();
            App.playViewModel.CurrentVideo = null;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView.SelectedItem = null;
        }
    }
}
