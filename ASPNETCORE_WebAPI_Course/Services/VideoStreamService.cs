using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI_Course.Services
{
    public class VideoStreamService : IVideoStreamService
    {
        private HttpClient _client;

        public VideoStreamService()
        {
            _client = new HttpClient();
        }
        public async Task<Stream> GetVideoByName(string name)
        {
            var urlBlob = string.Empty;

            switch (name)
            {
                case "fugees":
                    urlBlob = "http://gartner.gosimian.com/assets/videos/Fugees_ReadyOrNot_278-WIREDRIVE.mp4";
                    break;

                default:
                    urlBlob = "https://www.youtube.com/watch?v=CDl9ZMfj6aE";
                    break;
            }

            return await _client.GetStreamAsync(urlBlob);
        }

        ~VideoStreamService()
        {
            if (_client != null)
                _client.Dispose();
        }
    }
}
