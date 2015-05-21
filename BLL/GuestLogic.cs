using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ApplicationLogger;

namespace BLL
{
    public class GuestLogic:IGuestLogic
    {
        private ILoggerIO logs;
        private IGuestDAO guestData;
        

        public GuestLogic(IGuestDAO guestDAO, ISQLDAO dao, ILoggerIO log)
        {
            
            logs = log;
            guestData = guestDAO;   //injecting dependency
            guestData.SetDataWriter(dao);//dependency injector through a infrastructure
        }
        public List<GuestSM>GetAllGuests()
        {
            return Map(guestData.GetAllGuests());
        }
        public GuestSM GetGuestById(int id)
        {
            return Map(guestData.GetGuestById(id.ToString()));
        }
        public void CreateGuest(GuestSM guest)
        {
            try
            {
                guestData.CreateGuest(Map(guest));
                logs.LogError("Event","A new guest has been been added to database","Class:GuestLogic,Method:CreateGuest");

            }
            catch (Exception d)
            {
                logs.LogError("Error","A new guest has not been added to the database","Class:GuestLogic,Method:CreateGuest");
            }
        }
        public void UpdateGuest(GuestSM guest)
        {
            try
            {
                guestData.UpdateGuest(Map(guest));
                logs.LogError("Event","Guest was successfully able to update","Class:GuestLogic,Method:UpdateGuest");
            }
            catch
            {
                logs.LogError("Error","Guest was unsucessfully able to update","Class:GuestLogic,Method:UpdateGuest");
            }
        }

        public void DeleteGuestById(int id)
        {
            try
            {
                guestData.DeleteGuestById(id.ToString());
                logs.LogError("Event","Guest was able to remove a guest","Class:GuestLoic,Method:DeleteGuestById");
            }
            catch
            {
                logs.LogError("Error","Guest was unable to remove a guest","Class:GuestLoic,Method:DeleteGuestById");

            }
        }


        private GuestSM Map(GuestDM human) // Converts for guest in the Logic/Presentation Layer
        {
            GuestSM hm = new GuestSM();
            hm.GuestId = Convert.ToInt32(human.GuestId);
            hm.Name = human.Name;
            hm.Phone =Convert.ToUInt32(human.Phone);
            hm.Active = Convert.ToBoolean(human.Active);
            hm.Street1 = human.Street1;
            hm.Street2 = human.Street2;
            hm.City = human.City;
            hm.State = human.State;
            hm.Zipcode = Convert.ToInt32(human.Zipcode);
            return hm;
        }
      
        private GuestDM Map(GuestSM human) //Converts for use in the Data Layer
        {
            GuestDM hm = new GuestDM();
            hm.GuestId = human.GuestId.ToString();
            hm.Name = human.Name;
            hm.Phone = human.Phone.ToString();
            hm.Street1 = human.Street1;
            hm.Street2 = human.Street2;
            hm.City = human.City;
            hm.State = human.State;
            hm.Zipcode = human.Zipcode.ToString();
            return hm;
        }
       
        private List<GuestSM> Map(List<GuestDM> guests) //Converts for Use in the Logic/Presentation Layer
        {
            List<GuestSM> people = new List<GuestSM>();
            foreach (GuestDM guest in guests)
            {
                people.Add(Map(guest));
            }
            return people;
        }
    
        private List<GuestDM> Map(List<GuestSM> guests) //Converts for use in the Data Layer
        {
            List<GuestDM> people = new List<GuestDM>();
            foreach (GuestSM guest in guests)
            {
                people.Add(Map(guest));
            }
            return people;
        }
    }
}