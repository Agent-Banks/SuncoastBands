using System;

namespace SuncoastBands
{
    class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int BandId { get; set; }

        //    Class
        //      |
        //      |   Property Name
        //      |     |
        //      |     |
        public Band Band { get; set; }

    }
}