using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xamarin.Essentials;
using YoutubePlayer.Features.Home.Pages;
using YoutubePlayer.Features.VideoPlayer.Pages;
using YoutubePlayer.Features.VideoPlayer.Services;
using YoutubePlayer.Providers.Analytics.Services;
using YoutubePlayer.Providers.Navigation.Services;

namespace YoutubePlayer
{
    public static class Startup
    {
        #region Properties

        public static IServiceProvider ServiceProvider { get; set; }

        #endregion

        #region Methods

        public static void Init()
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    // Tell the host configuration where to file the file (this is required for Xamarin apps)
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                })
                .ConfigureServices(ConfigureServices)
                .Build();

            ServiceProvider = host.Services;
        }


        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            #region Features/ToDo

            services.AddTransient<HomePageViewModel>();
            services.AddTransient<VideoPlayerViewModel>();

            #endregion

            #region Providers

            services.AddTransient<IAnalyticsService, AnalyticsService>();
            services.AddTransient<INavigationService, NavigationService>();

            #endregion

            #region Services

            services.AddTransient<IMediaService, MediaService>();

            #endregion

            services.AddAutoMapper(typeof(Startup));
        }

        #endregion
    }
}
