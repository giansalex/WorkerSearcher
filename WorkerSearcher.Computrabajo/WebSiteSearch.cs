using System;
using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using HtmlAgilityPack;
using WorkerSearcher.Computrabajo.Properties;

namespace WorkerSearcher.Computrabajo
{
    /// <summary>
    /// Ejecutor de Busqueda.
    /// </summary>
    internal class WebSiteSearch
    {
        private string[] SourcePages => new []
{
            Resources.Page1,
            Resources.Page2,
            Resources.Page3
        };

        private readonly Uri _baseUri;

        private readonly string[] _searches;

        public WebSiteSearch(string[] query)
        {
            Ensure.That(query)
                .WithExtraMessageOf(() => Resources.ErrorEmptyQuery)
                .HasItems();

            _searches = query;
            _baseUri = new Uri(SourcePages[0]);
        }

        /// <summary>
        /// Retorna los link de la busqueda.
        /// </summary>
        /// <returns>list of url</returns>
        public IEnumerable<Uri> Run()
        {
            var web = new HtmlWeb
            {
                AutoDetectEncoding = true
            };
            var max = int.Parse(Resources.MaxNavigate);

            var result = new List<string>();
            foreach (var page in SourcePages)
            {
                for (var i = 1; i <= max; i++)
                {
                    result.AddRange(GetLinks(web.Load(page + $"?p={i}")));
                }
            }

            foreach (var url in result)
               yield return new Uri(_baseUri, url);            
        }

        private IEnumerable<string> GetLinks(HtmlDocument doc)
        {
            var links = doc.DocumentNode.SelectNodes("//div[contains(@class, 'bRS')]//h2[@class='tO']//a");
            Ensure.That(links, nameof(links))
                .IsNotNull();

            foreach (var link in links)
            {
                Ensure.That(link, nameof(link))
                    .IsNotNull();

                var title = link.InnerText;
                if (_searches.Any(s => title.Contains(s)))
                {
                    yield return link.Attributes["href"].Value;
                }
                    
            }
        }
    }
}
