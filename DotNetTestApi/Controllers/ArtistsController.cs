using System;
using System.Collections.Generic;
using System.Web.Http;
using DotNetTestApi.Models;
using DotNetTestApi.Services;

namespace DotNetTestApi.Controllers
{
    [RoutePrefix("artists")]
    public class ArtistsController : ApiController
    {
        private ArtistService artistService = ArtistService.GetInstance();

        // GET http://localhost:8080/api/artists
        [HttpGet]
        public IHttpActionResult GetAllArtists()
        {
            ICollection<Artist> artists = artistService.GetAll();
            return Ok(artists);
        }

        // GET http://localhost:8080/api/artists/1
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetArtist(int id)
        {
            Artist artist = artistService.GetArtist(id);

            if(artist == null)
            {
                // 404 error
                return NotFound();
            }

            return Ok(artist);
        }

        // POST http://localhost:8080/api/artists
        [HttpPost]
        public IHttpActionResult AddArtist(Artist artist)
        {
            Artist newArtist = artistService.AddArtist(artist);
            return Ok(newArtist);
        }
    }
}
