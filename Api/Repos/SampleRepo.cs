using QuickSampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickSampleApi.Repos
{
    public class SampleRepo
    {
        private SampleContext db;

        public SampleRepo(SampleContext db)
        {
            this.db = db;
        }

        public List<Sample> GetProduts()
        {
            if (db != null)
            {
                List<Sample> employees = new List<Sample>();

                var result = db.Samples.OrderByDescending(x => x.SampleName).ToList();

                return result;
            }

            return null;
        }
    }
}
