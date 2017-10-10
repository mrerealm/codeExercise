using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Domain.Entities
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public List<Race> Races { get; set; }
    }
}
