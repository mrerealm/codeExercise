using CodingExercise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Repositories
{
    interface IMeetingRepository
    {
        Meeting AddOrUpdate(Meeting entity);
        IEnumerable<Meeting> AddOrUpdate(IEnumerable<Meeting> list);
        int SaveChances();
    }
}
