using System;
using System.Collections.Generic;

namespace YoutubePlayer.Providers.Analytics.Services
{
    public interface IAnalyticsService
    {
        void TrackEvent(string eventName);
        void TrackEvent(string eventName, Dictionary<string, string> dictionary);
        void TrackError(Exception error, Dictionary<string, string> properties = null);
    }
}
