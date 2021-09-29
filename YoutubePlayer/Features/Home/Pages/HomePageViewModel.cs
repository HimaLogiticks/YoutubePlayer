using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YoutubePlayer.Features.VideoPlayer.Pages;
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

        readonly INavigationService _navigationService;

        #endregion

        #region Constructor

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            PlayVideoCommand = new Command(async () => await NavigateToVideoPlayerPage());
        }

        #endregion

        #region Methods

        async Task NavigateToVideoPlayerPage()
        {
            if (!IsValidUrl(Url))
            {
                await Application.Current.MainPage.DisplayAlert(AppResources.AlertText, AppResources.InvalidUrlMessage, AppResources.OkText);
            }
            else
            {
                await _navigationService.NavigateToAsync<VideoPlayerViewModel>(Url);
            }
        }

        bool IsValidUrl(string url)
        {
            Uri uriResult;
            bool isValid = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttps;
            return isValid;
        }
        #endregion
    }
}
