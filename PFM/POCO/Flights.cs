using PFM.Interface;
using PFM.Interface.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFM.POCO
{
    class Flights : IPoco
    {
        public int Id { get; set; }
        public int AirlinecompanyId { get; set; }
        public int OriginCountryCode { get; set; }
        public int DestinationCountryCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
        public int RemainingTickets { get; set; }

        public Flights(int id, int airlinecompanyId, int originCountryCode, int destinationCountryCode, DateTime departureTime, DateTime landingTime, int remainingTickets)
        {
            Id = id;
            AirlinecompanyId = airlinecompanyId;
            OriginCountryCode = originCountryCode;
            DestinationCountryCode = destinationCountryCode;
            DepartureTime = departureTime;
            LandingTime = landingTime;
            RemainingTickets = remainingTickets;
        }

        public Flights()
        {

        }
        public override string ToString()
        {
            return $"Flights {Id} {AirlinecompanyId} {OriginCountryCode} {DestinationCountryCode} {DepartureTime} {LandingTime} {RemainingTickets} ";
        }

        public static bool operator ==(Flights f1, Flights f2)
        {
            return (f1.Id == f2.Id);
        }
        public static bool operator !=(Flights f1, Flights f2)
        {
            return (f1.Id != f2.Id);

        }
        public override bool Equals(object obj)
        {
            var Flights = obj as Flights;
            if (ReferenceEquals(obj, null))
                return false;
            return this.Id == Flights.Id;

        }
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
