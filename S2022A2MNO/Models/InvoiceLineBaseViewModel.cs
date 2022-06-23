using S2022A2MNO.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2022A2MNO.Models
{
    public class InvoiceLineBaseViewModel {
        [Key]
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Track Track { get; set; }

    }
}