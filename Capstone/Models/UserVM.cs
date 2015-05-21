using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.ComponentModel.DataAnnotations;


namespace Capstone.Models
{
    public class UserVM
    {
        public int userId { get; set; }

        [Required]
        [Display(Name = "username")]
        [StringLength(50, MinimumLength = 3)]
        public string username { get; set; }

        [Required]
        [Display(Name = "password")]
        [StringLength(32, MinimumLength = 4)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&+=]).*$", ErrorMessage = "You must have at least one Uppercase and a special character.")]
        public string password { get; set; }

        public bool user { get; set; }

        public bool poweruser { get; set; }

        public bool admin { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string street1 { get; set; }

        public string street2 { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string city { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string state { get; set; }

        [Range(7, int.MaxValue, ErrorMessage = "Please enter valid zipcode")]
        public int zipcode { get; set; }
        

        public static UserSM Map(UserVM human) 
     {
            UserSM hm = new UserSM();
            hm.UserId = human.userId;
            hm.Username = human.username;
            hm.Password =human.password;
            hm.User = human.user;
            hm.Poweruser = human.poweruser;
            hm.Admin = human.admin;
            hm.Street1 = human.street1;
            hm.Street2 = human.street2;
            hm.City = human.city;
            hm.State = human.state;
            hm.Zipcode = human.zipcode;
            return hm;
        }
      
        public static UserVM Map(UserSM human) 
        {
            UserVM hm = new UserVM();
            hm.userId = human.UserId;
            hm.username = human.Username;
            hm.password = human.Password;
            hm.user = human.User;
            hm.poweruser = human.Poweruser;
            hm.admin = human.Admin;
            hm.street1 = human.Street1;
            hm.street2 = human.Street2;
            hm.city = human.City;
            hm.state = human.State;
            hm.zipcode = human.Zipcode;
            return hm;
        }
       
        public static List<UserSM> Map(List<UserVM> Users)
        {
            List<UserSM> people = new List<UserSM>();
            foreach (UserVM User in Users)
            {
                people.Add(Map(User));
            }
            return people;
        }
    
        public static List<UserVM> Map(List<UserSM> Users) 
        {
            List<UserVM> people = new List<UserVM>();
            foreach (UserSM User in Users)
            {
                people.Add(Map(User));
            }
            return people;
        }
    
    }
}