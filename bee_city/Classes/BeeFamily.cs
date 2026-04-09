using bee_city.Enums;

namespace bee_city.Classes
{
    internal class BeeFamily
    {
        public Guid FamilyID { get; set; }
        public string FamilyName { get; set; }
        public FamilyType FamilyType { get; set; }
        public List<Bee> Bees { get; set; }
        public int HoneyHarvest { get; set; }
    }
}
