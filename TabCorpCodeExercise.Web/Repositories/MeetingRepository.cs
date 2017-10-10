using CodingExercise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingExercise.Repositories
{
    public class MeetingRepository: IMeetingRepository
    {
        private RacingDataModel DataContext = new RacingDataModel();

        public Meeting AddOrUpdate(Meeting entity)
        {
            return DataContext.MyMeetings.Add(entity);
        }

        public IEnumerable<Meeting> AddOrUpdate(IEnumerable<Meeting> list)
        {
            return DataContext.MyMeetings.AddRange(list);
        }

        public int SaveChances()
        {
            return DataContext.SaveChanges();
        }
    }
}