using System.ComponentModel.DataAnnotations.Schema;

namespace Examenv3.Models
{
    public class EMISIUNE
    {
        public int Id { get; set; }
        public string Titlu { get; set; }
        public string Producator { get; set; }

        public int AnulLansarii { get; set; }

        public string Gen { get; set; }

        [ForeignKey("CanalTVId")]
        public int CanalTVId { get; set; }

        public CANAL_TV CanalTV { get; set; }
    }
}
