using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A2MNO.Controllers
{
    public class InvoicesController : Controller
    {
        private Manager m = new Manager();
        // GET: Invoices
        public ActionResult Index() {
            var idx = m.InvoiceGetAll();
            return View(idx);
        }
        
        // GET: Invoices/Details/5
        public ActionResult oneInvoiceIndex(int? id) {
            var oneInvoice = m.InvoiceGetById(id);
            return View("Index", oneInvoice);
        }
        public ActionResult Details(int? id) {
            var obj = m.InvoiceGetByIdWithDetail(id.GetValueOrDefault());
            
            if (obj == null) return HttpNotFound();
            
            return View(obj);
        }
    }
}
