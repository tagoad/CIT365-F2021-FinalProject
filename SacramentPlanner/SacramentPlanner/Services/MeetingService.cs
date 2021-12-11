using SacramentPlanner.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace SacramentPlanner.Services
{
    public class MeetingService
    {
        private readonly IMongoCollection<SacramentMeeting> _meetings;

        public MeetingService(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);

            _meetings = database.GetCollection<SacramentMeeting>(settings.SacramentMeetingCollectionName);
        }

        public List<SacramentMeeting> Get() =>
            _meetings.Find(meeting => true).ToList();

        public SacramentMeeting Get(int id) =>
            _meetings.Find<SacramentMeeting>(meeting => meeting.Id == id).FirstOrDefault();

        public SacramentMeeting Create(SacramentMeeting meeting)
        {
            _meetings.InsertOne(meeting);
            return meeting;
        }

        public void Update(int id, SacramentMeeting meetingIn) =>
            _meetings.ReplaceOne(meeting => meeting.Id == id, meetingIn);

        public void Remove(SacramentMeeting meetingIn) =>
            _meetings.DeleteOne(meeting => meeting.Id == meetingIn.Id);

        public void Remove(int id) =>
            _meetings.DeleteOne(meeting => meeting.Id == id);
    }
}
