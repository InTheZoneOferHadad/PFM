using PFM.Interface;
using PFM.Interface.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFM.POCO
{
    class Ticket : IPoco
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int CustomerId { get; set; }

        public Ticket(int id, int flightId, int customerId)
        {
            Id = id;
            FlightId = flightId;
            CustomerId = customerId;
        }
        public Ticket()
        {

        }
        public override string ToString()
        {
            return $"Ticket {Id} {FlightId} {CustomerId}";
        }

        public static bool operator ==(Ticket t1, Ticket t2)
        {
            return (t1.Id == t2.Id);
        }
        public static bool operator !=(Ticket t1, Ticket t2)
        {
            return (t1.Id != t2.Id);

        }
        public override bool Equals(object obj)
        {
            var Ticket = obj as Ticket;
            if (ReferenceEquals(obj, null))
                return false;
            return this.Id == Ticket.Id;

        }
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
    
}
