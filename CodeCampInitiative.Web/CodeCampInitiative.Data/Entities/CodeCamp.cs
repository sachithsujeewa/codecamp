using System;
using System.Collections.Generic;

namespace CodeCampInitiative.Data.Entities
{
    public class CodeCamp : EntityBase
    {
        public string Name { get; set; }
        public string Moniker { get; set; }
        public Location Location { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; } = 1;
        public ICollection<Session> Sessions { get; set; }
    }
}
