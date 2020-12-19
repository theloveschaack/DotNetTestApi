using System;
using System.Collections.Generic;
using DotNetTestApi.Models;

namespace DotNetTestApi.Services
{
    public class TrackService
    {
        private static readonly TrackService _instance = new TrackService();
        private ArtistService artistService = ArtistService.GetInstance();

        public List<Track> _tracks = new List<Track>()
        {
            new Track { id = 1, title = "Bottle Up and Explode", artist = ArtistService.GetInstance()._artists[0], genre = "Rock" },
            new Track { id = 2, title = "Christian Brothers", artist = ArtistService.GetInstance()._artists[0], genre = "Rock" },
            new Track { id = 3, title = "A Question Mark", artist = ArtistService.GetInstance()._artists[0], genre = "Rock" },
            new Track { id = 4, title = "Champion", artist = ArtistService.GetInstance()._artists[1], genre = "Rock" },
            new Track { id = 5, title = "View From the Sky", artist = ArtistService.GetInstance()._artists[1], genre = "Rock" }
        };

        private TrackService()
        {
        }

        public static TrackService GetInstance() => _instance;

        public Track GetTrack(int id)
        {
            foreach (Track track in _tracks)
            {
                if (track.id == id)
                {
                    return track;
                }
            }

            return null;
        }

        public ICollection<Track> GetAll()
        {
            return _tracks;
        }

        public ICollection<Track> GetTracksByArtistId(int artistId)
        {
            return _tracks.FindAll(t => t.artist.id == artistId);
        }
    }
}
