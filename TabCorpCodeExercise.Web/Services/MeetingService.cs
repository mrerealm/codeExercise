using CodingExercise.Domain.Entities;
using CodingExercise.Domain.ValueObjects;
using CodingExercise.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CodingExercise.Services
{
    public class MeetingService: IMeetingService
    {
        public string DataPath { get; set; }

        private MeetingRepository MeetingRepository { get; set; }
        private RaceRepository RaceRepository { get; set; }

        public MeetingService ()
        {
            DataPath = ConfigurationManager.AppSettings.Get("datalocationPath");
            MeetingRepository = new MeetingRepository();
            RaceRepository = new RaceRepository();
        }

        public List<Meeting> Get()
        {
            var meetings = new List<Meeting>();

            var dataFiles = Directory.GetFiles(DataPath, "*.json");

            foreach (var file in dataFiles)
            {
                var contents = File.ReadAllText(file);
                var dataPackage = JsonConvert.DeserializeObject<MeetingPackage>(contents);
                if (dataPackage != null) {
                    foreach (var race in dataPackage.Meeting.Races)
                    {
                        race.MeetingId = dataPackage.Meeting.Id;
                    }
                    meetings.Add(dataPackage.Meeting);
                }
            }

            return meetings;
        }

        public Meeting AddOrUpdate(Meeting entity)
        {
            if (entity != null) RaceRepository.AddOrUpdate(entity.Races);
            return MeetingRepository.AddOrUpdate(entity);
        }


        public IEnumerable<Meeting> AddOrUpdate(IEnumerable<Meeting> list)
        {
            foreach(var meeting in list)
            {
                RaceRepository.AddOrUpdate(meeting.Races);
            }
            return MeetingRepository.AddOrUpdate(list);
        }

        public int SaveChanges()
        {
            RaceRepository.SaveChances();
            return MeetingRepository.SaveChances();
        }
    }
}