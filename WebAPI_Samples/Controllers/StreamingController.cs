using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Samples.Services;

namespace WebAPI_Samples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingController : ControllerBase
    {
        private IVideoStreamService _streamService;

        public StreamingController(IVideoStreamService streamingService)
        {
            _streamService = streamingService;
        }

        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get (string name)
        {
            var stream = await _streamService.GetVideoByName(name);

            return new FileStreamResult(stream, "video/mp4");
        }
    }
}
