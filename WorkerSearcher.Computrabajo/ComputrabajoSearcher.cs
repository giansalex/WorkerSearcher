using System;
using System.Collections.Generic;
using WorkSearcher.BL;

namespace WorkerSearcher.Computrabajo
{
    /// <summary>
    /// Search in http://computrabajo.com.pe
    /// </summary>
    public class ComputrabajoSearcher : ISearcher
    {

        public IEnumerable<Uri> Search(params string[] querys)
        {
            var runner = new WebSiteSearch(querys);
            return runner.Run();
        }

    }
}
