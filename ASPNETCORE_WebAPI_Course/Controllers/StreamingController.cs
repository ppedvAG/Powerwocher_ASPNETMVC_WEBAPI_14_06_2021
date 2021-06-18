using ASPNETCORE_WebAPI_Course.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI_Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingController : ControllerBase
    {
        private IVideoStreamService _streamingService;

        public StreamingController(IVideoStreamService streamingService)
        {
            _streamingService = streamingService;
        }

        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get(string name)
        {
            var stream = await _streamingService.GetVideoByName(name);

            return new FileStreamResult(stream, "video/mp4");
        }
    }
}
