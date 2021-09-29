using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace YoutubePlayer.Providers.Analytics.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        #region Methods

        public void TrackEvent(string eventName)
        {
            var properties = new Dictionary<string, string>();
            Microsoft.AppCenter.Analytics.Analytics.TrackEvent(eventName, properties);
        }
        public void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            Microsoft.AppCenter.Analytics.Analytics.TrackEvent(eventName, properties);
        }

        public void TrackView(string viewName)
        {
            var properties = new Dictionary<string, string>();
            Microsoft.AppCenter.Analytics.Analytics.TrackEvent(viewName, properties);
        }

        public void TrackError(Exception error, Dictionary<string, string> properties = null)
        {
            Crashes.TrackError(error, properties);
        }

        #endregion
    }
}
