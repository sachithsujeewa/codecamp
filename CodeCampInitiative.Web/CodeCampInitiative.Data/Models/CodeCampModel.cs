namespace CodeCampInitiative.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for code camp entity
    /// </summary>
    public class CodeCampModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the moniker.
        /// </summary>
        /// <value>
        /// The moniker.
        /// </value>
        [Required]
        public string Moniker { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        [Required]
        public DateTime EventDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        [Required]
        [Range(1, 30)]
        public int Length { get; set; } = 1;

        //Adding location data in same level 

        /// <summary>
        /// Gets or sets the name of the location venue.
        /// </summary>
        /// <value>
        /// The name of the location venue.
        /// </value>
        public string LocationVenueName { get; set; }

        /// <summary>
        /// Gets or sets the location address1.
        /// </summary>
        /// <value>
        /// The location address1.
        /// </value>
        public string LocationAddress1 { get; set; }

        /// <summary>
        /// Gets or sets the location address2.
        /// </summary>
        /// <value>
        /// The location address2.
        /// </value>
        public string LocationAddress2 { get; set; }

        /// <summary>
        /// Gets or sets the location address3.
        /// </summary>
        /// <value>
        /// The location address3.
        /// </value>
        public string LocationAddress3 { get; set; }

        /// <summary>
        /// Gets or sets the location city town.
        /// </summary>
        /// <value>
        /// The location city town.
        /// </value>
        public string LocationCityTown { get; set; }

        /// <summary>
        /// Gets or sets the location state province.
        /// </summary>
        /// <value>
        /// The location state province.
        /// </value>
        public string LocationStateProvince { get; set; }

        /// <summary>
        /// Gets or sets the location postal code.
        /// </summary>
        /// <value>
        /// The location postal code.
        /// </value>
        public string LocationPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the location country.
        /// </summary>
        /// <value>
        /// The location country.
        /// </value>
        public string LocationCountry { get; set; }

        /// <summary>
        /// Gets or sets the sessions.
        /// </summary>
        /// <value>
        /// The sessions.
        /// </value>
        public IEnumerable<SessionModel> Sessions { get; set; }
    }
}
