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
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Username")]
       [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(32, MinimumLength = 4)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&+=]).*$", ErrorMessage = "You must have at least one Uppercase and a special character.")]
        public string Password { get; set; }

        public bool User { get; set; }

        public bool Poweruser { get; set; }

        public bool Admin { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        [Range(7, int.MaxValue, ErrorMessage = "Please enter valid zipcode")]
        public int Zipcode { get; set; }

        public int SecLvl { get; set; }


        public static UserSM Map(UserVM human)
     {
            UserSM hm = new UserSM();
            hm.UserId = human.UserId;
            hm.Username = human.Username;
            hm.Password = human.Password;
            hm.User = human.User;
            hm.Poweruser = human.Poweruser;
            hm.Admin = human.Admin;
            hm.Street1 = human.Street1;
            hm.Street2 = human.Street2;
            hm.City = human.City;
            hm.State = human.State;
            hm.Zipcode = human.Zipcode;
            hm.SecLvl = human.SecLvl;
            return hm;
        }
      
        public static UserVM Map(UserSM human)
        {
            UserVM hm = new UserVM();
            hm.UserId = human.UserId;
            hm.Username = human.Username;
            hm.Password = human.Password;
            hm.User = human.User;
            hm.Poweruser = human.Poweruser;
            hm.Admin = human.Admin;
            hm.Street1 = human.Street1;
            hm.Street2 = human.Street2;
            hm.City = human.City;
            hm.State = human.State;
            hm.Zipcode = human.Zipcode;
            hm.SecLvl = human.SecLvl;
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