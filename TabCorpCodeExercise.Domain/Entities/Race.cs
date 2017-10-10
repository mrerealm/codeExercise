using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Domain.Entities
{
    public class Race
    {
        [Key]
        public long Id { get; set; }
        public int MeetingId { get; set; }
        public string Racenumber { get; set; }
        public string Racename { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
    }
}
