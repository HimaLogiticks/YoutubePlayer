using System.Threading.Tasks;
using YoutubePlayer.Features.VideoPlayer.Models;

namespace YoutubePlayer.Features.VideoPlayer.Services
{
    public interface IMediaService
    {
        bool IsValidUrl(string url);
        Task<MediaInfo> GetMediaInfoAsync(string url);
    }
}
