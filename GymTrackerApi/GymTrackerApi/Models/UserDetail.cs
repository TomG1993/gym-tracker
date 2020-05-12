using System.ComponentModel.DataAnnotations;

namespace GymTrackerApi.Models
{
    public class UserDetail : BaseModel
    {
        [Key]
        public int ID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        //public bool Frozen { get; set; }
    }
}