using System;
using System.Collections.Generic;
using DotNetTestApi.Models;

namespace DotNetTestApi.Services
{
    public class ArtistService
    {
        private static readonly ArtistService _instance = new ArtistService();

        public List<Artist> _artists = new List<Artist>()
        {
            new Artist { id = 1, name = "Elliott Smith" },
            new Artist { id = 2, name = "Shy Boys"}
        };

        private ArtistService()
        {
        }

        public static ArtistService GetInstance() => _instance;

        public Artist GetArtist(int id)
        {
            foreach(Artist artist in _artists)
            {
                if(artist.id == id)
                {
                    return artist;
                }
            }

            return null;
        }

        public ICollection<Artist> GetAll()
        {
            return _artists;
        }

        public Artist AddArtist(Artist newArtist)
        {
            // determine max id of all current artists
            int maxId = 0;
            foreach (Artist artist in _artists)
            {
                if(artist.id > maxId)
                {
                    maxId = artist.id;
                }
            }

            // set new artistId
            newArtist.id = maxId + 1;

            // save the artist to the List
            _artists.Add(newArtist);

            // return the new artist
            return newArtist;
        }
    }
}
