using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YoutubePlayer.Features.VideoPlayer.Services;
using YoutubePlayer.Providers.Analytics.Services;
using YoutubePlayer.Providers.Navigation.Base;
using YoutubePlayer.Providers.Navigation.Services;
using YoutubePlayer.Resx;

namespace YoutubePlayer.Features.VideoPlayer.Pages
{
    public class VideoPlayerViewModel : ViewModelBase
    {
        #region Properties

        bool _isLoading = true;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
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

        readonly IAnalyticsService _analyticsService;
        readonly IMediaService _mediaService;
        readonly INavigationService _navigationService;

        #endregion

        #region Constructor

        public VideoPlayerViewModel(IAnalyticsService analyticsService, IMediaService mediaService,
                                    INavigationService navigationService)
        {
            _analyticsService = analyticsService;
            _mediaService = mediaService;
            _navigationService = navigationService;
            MediaOpenedCommand = new Command(MediaOpened);
        }

        #endregion

        #region Methods

        void MediaOpened()
        {
            IsLoading = false;
        }

        async Task GetMediaInfo(string url)
        {
            try
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
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(AppResources.AlertText, ex.Message, AppResources.OkText);
                _analyticsService.TrackError(ex);
                await _navigationService.PopAsync();
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
