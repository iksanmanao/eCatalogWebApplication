using System.ComponentModel.DataAnnotations;

namespace eCatalogWebApplication.Models
{
    public class Catalog
    {
        [Key]
        public int IDCatalog { get; set; }

        public string NameCatalog { get; set; }

        public string SubCatalog { get; set; }

        public Catalog()
        {

        }
    }
}
