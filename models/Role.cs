using System.ComponentModel.DataAnnotations;

namespace user_registration.models
{
    public class Role
    {
        [Key]
        public int code { get; set; }
        public string name { get; set; }
    }
}