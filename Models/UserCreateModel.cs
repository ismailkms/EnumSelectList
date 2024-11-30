using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnumSelectList.Models
{
    public class UserCreateModel
    {
        public string Username { get; set; }
        public int GenderId { get; set; }
        public SelectList Genders { get; set; }
    }
}
