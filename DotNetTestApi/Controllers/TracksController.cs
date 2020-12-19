using System;
using System.Collections.Generic;
using System.Web.Http;
using DotNetTestApi.Models;
using DotNetTestApi.Services;

namespace DotNetTestApi.Controllers
{
    [RoutePrefix("tracks")]
    public class TracksController : ApiController
    {
        private TrackService trackService = TrackService.GetInstance();

        // GET http://localhost:8080/api/tracks
        [HttpGet]
        public IHttpActionResult GetAllTracks()
        {
            ICollection<Track> tracks = trackService.GetAll();
            return Ok(tracks);
        }

        // GET http://localhost:8080/api/tracks/1
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetTrack(int id)
        {
            Track track = trackService.GetTrack(id);

            if (track == null)
            {
                // 404 error
                return NotFound();
            }

            return Ok(track);
        }
    }
}
