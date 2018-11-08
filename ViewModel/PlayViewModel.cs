using iTube.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace iTube.ViewModel
{
    public class PlayViewModel : INotifyPropertyChanged
    {
        private DBHelper dbHelper;

        private ObservableCollection<Comment> commentList;
        public ObservableCollection<Comment> CommentList
        {
            get => commentList;
            set
            {
                commentList = value;
                NotifyPropertyChanged(nameof(CommentList));
            }
        }

        private Video currentVideo;
        public Video CurrentVideo
        {
            get => currentVideo;
            set
            {
                currentVideo = value;

                if (currentVideo != null)
                {
                    Title = currentVideo.Title;
                    ChannelName = currentVideo.ChannelProfile.ChannelName;
                    ChannelArt = currentVideo.ChannelProfile.ChannelArt;
                    Date = currentVideo.Date;
                    Views = currentVideo.Views;
                    ChannelIndex = currentVideo.ChannelProfile.ChannelIndex;
                    
                    GetComment(currentVideo.Index);
                }
                else
                {
                    Title = null;
                    ChannelName = null;
                    ChannelArt = null;
                    Date = DateTime.Now;
                    Views = -1;
                    ChannelIndex = -1;
                }

            }
        }
        #region Variables
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        private string channelName;
        public string ChannelName
        {
            get => channelName;
            set
            {
                channelName = value;
                NotifyPropertyChanged(nameof(ChannelName));
            }
        }

        private BitmapImage channelArt;
        public BitmapImage ChannelArt
        {
            get => channelArt;
            set
            {
                channelArt = value;
                NotifyPropertyChanged(nameof(ChannelArt));
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                NotifyPropertyChanged(nameof(Date));
            }
        }

        private int views;
        public int Views
        {
            get => views;
            set
            {
                views = value;
                NotifyPropertyChanged(nameof(Views));
            }
        }

        private int commentCount;
        public int CommentCount
        {
            get => commentCount;
            set
            {
                commentCount = value;
                NotifyPropertyChanged(nameof(CommentCount));
            }
        }

        private int ChannelIndex
        {
            get;
            set;
        }
        #endregion

        public PlayViewModel()
        {
            dbHelper = new DBHelper("itube", "itube", App.SHORT_SERVER_URI, "itube");
            CommentList = new ObservableCollection<Comment>();
        }

        private void GetComment(int vid)
        {
            CommentList.Clear();
            CommentCount = 0;

            dbHelper.OpenConnection();
            MySqlDataReader result = dbHelper.ExecuteReaderQuery("SELECT idx, uid, content, date FROM comment WHERE vid = "+vid+";");
            
            while (result.Read())
            {
                Comment comment = new Comment()
                {
                    Index = Convert.ToInt32(result[0].ToString()),
                    Content = result[2].ToString(),
                    ChannelProfile = Utils.GetProfileByIdx(Convert.ToInt32(result[1].ToString())),
                    Date = (DateTime)result[3]
                };

                CommentList.Add(comment);
                CommentCount++;
            }
            result.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
