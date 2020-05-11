using System;

namespace GymTrackerApi.Models
{
    public class BaseModel
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}