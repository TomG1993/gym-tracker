using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Models
{
    public class SessionHeader : BaseModel
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        public int SessionNumber { get; set; }

        public string SessionName { get; set; }

    }
}
