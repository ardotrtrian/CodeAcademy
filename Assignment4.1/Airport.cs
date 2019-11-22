using System;
namespace Assignment4._1
{
    class Airport : IComparable<Airport>
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public Sizes Size { get; set; }

        public Airport(string name, string countrycode, Sizes size)
        {
            Name = name;
            CountryCode = countrycode;
            Size = size;
        }

        public int CompareAscending(Airport leftAirport, Airport rightAirport)
        {
            if (leftAirport != null  && rightAirport != null)
            {
                if (leftAirport.Size > rightAirport.Size)
                {
                    return 1;
                }
                if (leftAirport.Size < rightAirport.Size)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            throw new Exception("object is null");
        }

        public int CompareTo(Airport other)
        {
            return CompareAscending(this, other);
        }
    }
    
}
