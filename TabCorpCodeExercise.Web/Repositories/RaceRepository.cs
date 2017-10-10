using CodingExercise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingExercise.Repositories
{
    public class RaceRepository
    {
        private RacingDataModel DataContext = new RacingDataModel();

        public Race AddOrUpdate(Race entity)
        {
            return DataContext.MyRaces.Add(entity);
        }

        public IEnumerable<Race> AddOrUpdate(IEnumerable<Race> list)
        {
            return DataContext.MyRaces.AddRange(list);
        }

        public int SaveChances()
        {
            return DataContext.SaveChanges();
        }
    }
}