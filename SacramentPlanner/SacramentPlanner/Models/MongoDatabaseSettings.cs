using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string SacramentMeetingCollectionName { get; set; }
        public string MemberCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }

    public interface IMongoDatabaseSettings
    {
        string SacramentMeetingCollectionName { get; set; }
        string MemberCollectionName { get; set; }
        string ConnectionString { get; set; }
        string Database { get; set; }
    }
}
