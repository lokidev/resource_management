using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResourceManagementApi.Services;
using Microsoft.AspNetCore.Mvc;
using ResourceManagementApi.Services.Interfaces;

namespace ResourceManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private IResourceService _resourceService;
        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_resourceService.GetAll());
        }
    }
}
