using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity
{
    public class AdoptionEvent
    {
        public int EventID { get; private set; }
        public string EventName { get; private set; }

        public List<IAdoptable> Participants { get; private set; } = new List<IAdoptable>();

        public AdoptionEvent(int eventID, string eventName)
        {
            EventID = eventID;
            EventName = eventName;
            Participants = new List<IAdoptable>();
        }

        public AdoptionEvent()
        {
            Participants = new List<IAdoptable>();
        }

        public void RegisterParticipant(IAdoptable participant)
        {
            Participants.Add(participant);
            Console.WriteLine("Participant registered for the adoption event.");
        }

        public void HostEvent()
        {
            Console.WriteLine($"Adoption Event Hosted: {EventName} (ID: {EventID}) with the following participants:");
            foreach (var participant in Participants)
            {
                participant.Adopt();
            }
        }
    }
}




