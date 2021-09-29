using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubePlayer.Features.VideoPlayer.Models;

namespace YoutubePlayer.Features.VideoPlayer.Services
{
    public class MediaService : IMediaService
    {
        #region Constructor

        public MediaService()
        {

        }

        #endregion

        #region Methods

        public async Task<MediaInfo> GetMediaInfoAsync(string url)
        {
            var videoDetails = new MediaInfo();
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(url);
            if (video != null)
            {
                videoDetails.Author = video.Author.ToString();
                videoDetails.Title = video.Title;
                videoDetails.Duration = video.Duration.ToString();
            }
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            if (streamInfo != null)
            {
                videoDetails.Url = streamInfo.Url;
            }
            return videoDetails;
        }

        #endregion
    }
}
