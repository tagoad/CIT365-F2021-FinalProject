using SacramentPlanner.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace SacramentPlanner.Services
{
    public class MemberService
    {
        private readonly IMongoCollection<Member> _members;

        public MemberService(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);

            _members = database.GetCollection<Member>(settings.MemberCollectionName);
        }

        public List<Member> Get() =>
            _members.Find(member => true).ToList();

        public Member Get(string id) =>
            _members.Find<Member>(member => member.Id == id).FirstOrDefault();

        public Member Create(Member member)
        {
            _members.InsertOne(member);
            return member;
        }

        public void Update(string id, Member memberIn) =>
            _members.ReplaceOne(member => member.Id == id, memberIn);

        public void Remove(Member memberIn) =>
            _members.DeleteOne(member => member.Id == memberIn.Id);

        public void Remove(string id) =>
            _members.DeleteOne(member => member.Id == id);
    }
}
