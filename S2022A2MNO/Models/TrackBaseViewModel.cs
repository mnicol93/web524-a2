using S2022A2MNO.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2022A2MNO.Models
{
    public class TrackBaseViewModel{
        [Key]
        [Display(Name = "Track ID")]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Display(Name = "Album ID")]
        public int? AlbumId { get; set; }

        [Display(Name = "Media Type ID")]
        public int MediaTypeId { get; set; }

        [Display(Name = "Genre ID")]
        public int? GenreId { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }

        public virtual Genre Genre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        public virtual MediaType MediaType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}