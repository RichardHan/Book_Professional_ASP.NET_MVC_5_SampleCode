using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            // Get most popular albums
            var albums = GetTopSellingAlbums(6);

            return View(albums);
        }


        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            return storeDB.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public ActionResult ArtistSearch(string q)
        {
            var artists = GetArtists(q);

            return PartialView("_ArtistSearch", artists);
        }

        private List<Artist> GetArtists(string searchString)
        {
            return storeDB.Artists
                .Where(a => a.Name.Contains(searchString))
                .ToList();
        }

        public ActionResult DailyDeal()
        {
            var album = GetDailyDeal();

            return PartialView("_DailyDeal", album);
        }

        // Select an album and discount it by 50%
        private Album GetDailyDeal()
        {
            var album = storeDB.Albums
                .OrderBy(a => System.Guid.NewGuid())
                .First();

            album.Price *= 0.5m;
            return album;
        }

    }
}