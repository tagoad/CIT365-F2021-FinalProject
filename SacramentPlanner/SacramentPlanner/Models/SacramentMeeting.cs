using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SacramentPlanner.Models
{
    public class SacramentMeeting
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("Date")]
        [Display(Name = "Meeting Date")]
        public DateTime MeetingDate { get; set; }

        [Required]
        public Member Conductor { get; set; }

        [Required]
        [Display(Name = "Opening Prayer")]
        public Member OpeningPrayer { get; set; }
        [Required]
        [Display(Name = "Closing Prayer")]
        public Member ClosingPrayer { get; set; }

        public ICollection<Speaker> Speakers { get; set; }

        [Required]
        [Display(Name = "Opening Hymn")]
        public int OpeningHymn { get; set; }
        [Required]
        [Display(Name = "Sacrament Hymn")]
        public int SacramentHymn { get; set; }
        [Display(Name = "Intermediate Hymn")]
        public int IntermediateHymn { get; set; }
        [Required]
        [Display(Name = "Closing Hymn")]
        public int ClosingHymn { get; set; }

        public string Notes { get; set; }
    }
}
