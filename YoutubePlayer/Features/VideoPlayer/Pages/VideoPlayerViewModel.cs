using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YoutubePlayer.Features.VideoPlayer.Services;
using YoutubePlayer.Providers.Navigation.Base;

namespace YoutubePlayer.Features.VideoPlayer.Pages
{
    public class VideoPlayerViewModel : ViewModelBase
    {
        #region Properties

        bool _isRunning = true;
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        string _author;
        public string Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        string _duration;
        public string Duration
        {
            get => _duration;
            set => SetProperty(ref _duration, value);
        }

        string _url;
        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        #endregion

        #region Commands

        public ICommand MediaOpenedCommand { get; set; }

        #endregion

        #region Services

        readonly IMediaService _mediaService;

        #endregion

        #region Constructor

        public VideoPlayerViewModel(IMediaService mediaService)
        {
            _mediaService = mediaService;
            MediaOpenedCommand = new Command(MediaOpened);
        }

        #endregion

        #region Methods

        void MediaOpened()
        {
            IsRunning = false;
        }

        async Task GetMediaInfo(string url)
        {
            var mediaInfo = await _mediaService.GetMediaInfoAsync(url);
            if (mediaInfo != default)
            {
                Author = mediaInfo.Author;
                Title = mediaInfo.Title;
                Duration = mediaInfo.Duration;
                Url = mediaInfo.Url;
            }
        }

        #endregion

        #region Override methods

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is string)
            {
                var url = navigationData as string;
                await GetMediaInfo(url);
            }
        }

        #endregion
    }
}
