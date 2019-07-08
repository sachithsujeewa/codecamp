using System;

namespace CodeCampInitiative.Data.Models
{
    public class CodeCampModel
    {
        public string Name { get; set; }
        public string Moniker { get; set; }
        //public LocationModel Location { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; } = 1;
        //public ICollection<SessionModel> Sessions { get; set; }
    }
}
