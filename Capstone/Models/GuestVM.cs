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
        public int GuestId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(10, uint.MaxValue, ErrorMessage = "Please enter valid phone number")]
        public uint Phone { get; set; }

        public bool Active { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        [Range(7, int.MaxValue, ErrorMessage = "Please enter valid zipcode")]
        public int Zipcode { get; set; }


    
     public GuestSM Map(GuestVM human) 
     {
            GuestSM hm = new GuestSM();
            hm.GuestId = human.GuestId;
            hm.Name = human.Name;
            hm.Phone =human.Phone;
            hm.Active = human.Active;
            hm.Street1 = human.Street1;
            hm.Street2 = human.Street2;
            hm.City = human.City;
            hm.State = human.State;
            hm.Zipcode = human.Zipcode;
            return hm;
        }
      
        public GuestVM Map(GuestSM human) 
        {
            GuestVM hm = new GuestVM();
            hm.GuestId = human.GuestId;
            hm.Name = human.Name;
            hm.Phone = human.Phone;
            hm.Street1 = human.Street1;
            hm.Street2 = human.Street2;
            hm.City = human.City;
            hm.State = human.State;
            hm.Zipcode = human.Zipcode;
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