using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using YoutubePlayer.Constants;
using YoutubePlayer.Features.Home.Pages;
using YoutubePlayer.Providers.Navigation.Services;

namespace YoutubePlayer
{
    public partial class App : Application
    {
        #region Services

        readonly INavigationService _navigationService;

        #endregion

        #region Constructor

        public App()
        {
            InitializeComponent();
            Startup.Init();
            _navigationService = ViewModelLocator.Resolve<INavigationService>();
            Microsoft.AppCenter.AppCenter.Start($"{Flag.Android}={AppCenter.AndroidKey};" + $"{Flag.IOS}={AppCenter.IosKey};", typeof(Microsoft.AppCenter.Analytics.Analytics), typeof(Crashes));
        }

        #endregion

        #region Methods

        async Task SetMainPage()
        {
            await _navigationService.NavigateToAsync<HomePageViewModel>();
        }

        #endregion

        #region Override Methods

        protected override async void OnStart()
        {
            base.OnStart();
            await _navigationService.InitializeAsync();
            await SetMainPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        #endregion
    }
}
