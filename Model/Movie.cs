using System.ComponentModel.DataAnnotations;

namespace AdlerCatalogueWebApi.Model
{
    public class Movie
    {
        [Key]
        public int pkTblMovie { get; set; }
        public string sName { get; set; }
        public int nYear { get; set; }
        public string sDuration { get; set; }
    }
}
