using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A2MNO.Controllers
{
    public class TracksController : Controller
    {
        private Manager m = new Manager();
        // GET: Tracks
        public ActionResult Index() {
            // Fetch collection
            var t = m.TrackGetAll();
            // Pass the collection to the view
            return View(t);
        }
        public ActionResult AllRockMetal() {
            var allRock = m.TrackGetAllRockMetal();
            return View("Index", allRock);
        }
        public ActionResult AllTyler() {
            var allT = m.TrackGetAllTylerVallance();
            return View("Index", allT);
        }
        public ActionResult Longest() {
            var longest = m.TrackGetAllTop50Longest();
            return View("Index", longest);
        }
        public ActionResult Smallest() {
            var smallest = m.TrackGetAllTop50Smallest();
            return View("Index", smallest);
        }
    }
}
