using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class GuestVM
    {
        public int guestId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string name { get; set; }

        [Range(10, uint.MaxValue, ErrorMessage = "Please enter valid phone number")]
        public uint phone { get; set; }

        public bool active { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string street1 { get; set; }

        public string street2 { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string city { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string state { get; set; }

        [Range(7, int.MaxValue, ErrorMessage = "Please enter valid zipcode")]
        public int zipcode { get; set; }


    
     public GuestSM Map(GuestVM human) 
     {
            GuestSM hm = new GuestSM();
            hm.GuestId = human.guestId;
            hm.Name = human.name;
            hm.Phone =human.phone;
            hm.Active = human.active;
            hm.Street1 = human.street1;
            hm.Street2 = human.street2;
            hm.City = human.city;
            hm.State = human.state;
            hm.Zipcode = human.zipcode;
            return hm;
        }
      
        public GuestVM Map(GuestSM human) 
        {
            GuestVM hm = new GuestVM();
            hm.guestId = human.GuestId;
            hm.name = human.Name;
            hm.phone = human.Phone;
            hm.street1 = human.Street1;
            hm.street2 = human.Street2;
            hm.city = human.City;
            hm.state = human.State;
            hm.zipcode = human.Zipcode;
            return hm;
        }
       
        public List<GuestSM> Map(List<GuestVM> guests)
        {
            List<GuestSM> people = new List<GuestSM>();
            foreach (GuestVM guest in guests)
            {
                people.Add(Map(guest));
            }
            return people;
        }
    
        public List<GuestVM> Map(List<GuestSM> guests) 
        {
            List<GuestVM> people = new List<GuestVM>();
            foreach (GuestSM guest in guests)
            {
                people.Add(Map(guest));
            }
            return people;
        }
    }
}