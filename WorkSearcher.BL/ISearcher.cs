using System;
using System.Collections.Generic;

namespace WorkSearcher.BL
{
    public interface ISearcher
    {
        /// <summary>
        /// Ejecuta una busqueda de una o mas palabras y devuelve los link relacionados.
        /// </summary>
        /// <param name="querys">palabras a buscar.</param>
        /// <returns></returns>
        IEnumerable<Uri> Search(params string[] querys);
    }
}
