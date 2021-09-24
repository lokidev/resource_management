using QuickSampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickSampleApi.Repos;
using Microsoft.Extensions.Configuration;
using QuickSampleApi.Services.Interfaces;

namespace QuickSampleApi.Services
{
    public class SampleService : ISampleService
    {
        private readonly IConfiguration _configuration;

        public SampleService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICollection<Sample> GetAll()
        {
            using (var db = new SampleContext(_configuration))
            {
                var t = new SampleRepo(db);
                return t.GetProduts();
            }
        }
    }
}
