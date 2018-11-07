using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace iTube.Model
{
    public class Video : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int index;
        public int Index
        {
            get => index;
            set
            {
                index = value;
            }
        }

        private BitmapImage thumbnail;
        public BitmapImage Thumbnail
        {
            get => thumbnail;
            set
            {
                thumbnail = value;
                NotifyPropertyChanged("Thumbnail");
            }
        }

        private int channelIndex;
        public int ChannelIndex
        {
            get => channelIndex;
            set
            {
                channelIndex = value;
            }
        }
        private BitmapImage channelArt;
        public BitmapImage ChannelArt
        {
            get => channelArt;
            set
            {
                channelArt = value;
                NotifyPropertyChanged("ChannelArt");
            }
        }
        private string channelName;
        public string ChannelName
        {
            get => channelName;
            set
            {
                channelName = value;
                NotifyPropertyChanged("ChannelName");
            }
        }
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                NotifyPropertyChanged("Title");
            }
        }
        private int views;
        public int Views
        {
            get => views;
            set
            {
                views = value;
                NotifyPropertyChanged("Views");
            }
        }
        private DateTime date;
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                NotifyPropertyChanged("Date");
            }
        }
    }
}
