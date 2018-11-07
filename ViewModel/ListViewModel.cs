using iTube.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace iTube.ViewModel
{
    public class ListViewModel
    {
        public ObservableCollection<Video> VideoList { get; set; }
        private DBHelper dbHelper;

        public ListViewModel()
        {
            VideoList = new ObservableCollection<Video>();
            dbHelper = new DBHelper("itube", "itube",App.SERVER_URI, "itube");
            GetVideo();
        }

        public void GetVideo()
        {
            
            dbHelper.OpenConnection();

            MySqlDataReader result = dbHelper.ExecuteReaderQuery(
                "SELECT user.nick, user.idx, user.profile, video.idx, video.title, video.thumbnail, video.views, video.date FROM video,user WHERE video.uploader = user.idx;"
                );
            while (result.Read())
            {
                Video video = new Video()
                {
                    ChannelName = result[0].ToString(),
                    ChannelIndex = Convert.ToInt32(result[1].ToString()),
                    ChannelArt = new BitmapImage(),
                    Index = Convert.ToInt32(result[3].ToString()),
                    Title = result[4].ToString(),
                    Thumbnail = new BitmapImage(new Uri(result[5].ToString())),
                    Views = Convert.ToInt32(result[6]),
                    Date = (DateTime)result[7]
                };

                video.ChannelArt.BeginInit();
                if (result[2].ToString().Trim().Length == 0)
                {
                    video.ChannelArt.UriSource = new Uri("pack://application:,,,/iTube;component/Resource/ic_person.png", UriKind.Absolute);
                }

                else
                {
                    video.ChannelArt.UriSource = new Uri("http://" + App.SERVER_URI + "/video/" + result[2].ToString());
                }
                video.ChannelArt.EndInit();

                VideoList.Add(video);
            }
            
            result.Close();
            dbHelper.CloseConnection();
        }
    }
}
