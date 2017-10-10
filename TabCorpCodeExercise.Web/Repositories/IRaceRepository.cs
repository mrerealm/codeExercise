using CodingExercise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingExercise.Repositories
{
    interface IRaceRepository
    {
        Race AddOrUpdate(Race entity);
        IEnumerable<Race> AddOrUpdate(IEnumerable<Race> list);
        int SaveChanges();
    }
}