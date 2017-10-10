namespace CodingExercise
{
    using CodingExercise.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RacingDataModel : DbContext
    {
        public RacingDataModel()
            : base("name=RacingDataModel")
        {
        }

        public virtual DbSet<Meeting> MyMeetings { get; set; }
        public virtual DbSet<Race> MyRaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<RacingDataModel>(null);
            base.OnModelCreating(modelBuilder);
        }
    }

}