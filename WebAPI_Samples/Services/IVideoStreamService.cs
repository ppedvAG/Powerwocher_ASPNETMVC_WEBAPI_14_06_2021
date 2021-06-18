using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Samples.Services
{
    public interface IVideoStreamService
    {
        Task<Stream> GetVideoByName(string name);
    }
}
