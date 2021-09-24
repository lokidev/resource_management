using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickSampleApi.Services;
using Microsoft.AspNetCore.Mvc;
using QuickSampleApi.Services.Interfaces;

namespace QuickSampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private ISampleService _sampleService;
        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_sampleService.GetAll());
        }
    }
}
