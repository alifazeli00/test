using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalogs
{
    public class CatalogItemImgs
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public int CatalogItemId { get; set; }
        public CatalogItem CatalogItem { get; set; }







    }
}
