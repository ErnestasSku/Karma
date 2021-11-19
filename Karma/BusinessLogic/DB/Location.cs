namespace Backend
{
    public struct Location 
    {
        /// <summary>
        /// Represents Country.
        /// </summary>
        /// 
        public string Country { get; set; }
        /// <summary>
        /// Represents City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Represents State if it is in United States
        /// </summary>
        public string State { get; set; }

        
        /// <summary>
        /// Represents the street of the user.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Represents the post Code of the user.
        /// </summary>
        public string PostCode { get; set; }

        public Location(string Country, string City, string Street = null, string State = null, string PostCode = null)
        {
            this.Country = Country;
            this.City = City;
            this.Street = Street;
            this.State = State ?? "None";
            this.PostCode = PostCode;
        }

    }
}
