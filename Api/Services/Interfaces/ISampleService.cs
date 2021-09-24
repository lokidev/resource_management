using QuickSampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickSampleApi.Services.Interfaces
{
    public interface ISampleService
    {
        public ICollection<Sample> GetAll();
    }
}
