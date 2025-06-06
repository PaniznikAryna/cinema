﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Entity
{
    [Table("Movie")]
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        public int AgeRestriction { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Participant> Participants { get; set; } = new List<Participant>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
