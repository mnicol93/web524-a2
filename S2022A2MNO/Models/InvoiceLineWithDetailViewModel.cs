using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2022A2MNO.Models
{
    public class InvoiceLineWithDetailViewModel :
        InvoiceLineBaseViewModel 
    {
        [StringLength(150)]
        public string TrackName { get; set; }
        [StringLength(150)]
        public string TrackComposer{ get; set; }
        [StringLength(150)]
    }
}