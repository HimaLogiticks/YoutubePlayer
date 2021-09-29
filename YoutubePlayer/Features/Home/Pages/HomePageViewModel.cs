using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YoutubePlayer.Features.VideoPlayer.Pages;
using YoutubePlayer.Features.VideoPlayer.Services;
using YoutubePlayer.Providers.Navigation.Base;
using YoutubePlayer.Providers.Navigation.Services;
using YoutubePlayer.Resx;

namespace YoutubePlayer.Features.Home.Pages
{
    public class HomePageViewModel : ViewModelBase
    {
        #region Properties

        string _url;
        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        #endregion

        #region Commands

        public ICommand PlayVideoCommand { get; set; }

        #endregion

        #region Services

        readonly IMediaService _mediaService;
        readonly INavigationService _navigationService;

        #endregion

        #region Constructor

        public HomePageViewModel(IMediaService mediaService, INavigationService navigationService)
        {
            _mediaService = mediaService;
            _navigationService = navigationService;
            PlayVideoCommand = new Command(async () => await NavigateToVideoPlayerPage());
        }

        #endregion

        #region Methods

        async Task NavigateToVideoPlayerPage()
        {
            if (!_mediaService.IsValidUrl(Url))
            {
                await Application.Current.MainPage.DisplayAlert(AppResources.AlertText, AppResources.EnterValidUrlMessage, AppResources.OkText);
            }
            else
            {
                await _navigationService.NavigateToAsync<VideoPlayerViewModel>(Url);
            }
        }

        #endregion
    }
}
