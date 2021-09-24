using ResourceManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagementApi.Services.Interfaces
{
    public interface IResourceService
    {
        public ICollection<Resource> GetAll();
    }
}
