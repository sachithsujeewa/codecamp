namespace CodeCampInitiative.Data.Entities
{
    public class Session : EntityBase
    {
        public CodeCamp CodeCamp { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Level { get; set; }
        public Speaker Speaker { get; set; }
    }
}
