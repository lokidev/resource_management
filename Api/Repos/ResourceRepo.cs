using ResourceManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementApi.Repos
{
    public class ResourceRepo
    {
        private ResourceContext db;

        public ResourceRepo(ResourceContext db)
        {
            this.db = db;
        }

        public List<Resource> GetProduts()
        {
            if (db != null)
            {
                List<Resource> employees = new List<Resource>();

                var result = db.Resources.OrderByDescending(x => x.ResourceName).ToList();

                return result;
            }

            return null;
        }
    }
}
