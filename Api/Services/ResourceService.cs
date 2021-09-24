using ResourceManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResourceManagementApi.Repos;
using Microsoft.Extensions.Configuration;
using ResourceManagementApi.Services.Interfaces;

namespace ResourceManagementApi.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IConfiguration _configuration;

        public ResourceService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICollection<Resource> GetAll()
        {
            using (var db = new ResourceContext(_configuration))
            {
                var t = new ResourceRepo(db);
                return t.GetProduts();
            }
        }
    }
}
