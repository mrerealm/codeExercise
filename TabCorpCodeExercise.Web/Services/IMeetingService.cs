using CodingExercise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Services
{
    interface IMeetingService
    {
        List<Meeting> Get();
        Meeting AddOrUpdate(Meeting entity);
        IEnumerable<Meeting> AddOrUpdate(IEnumerable<Meeting> list);
        int SaveChanges();
    }
}
