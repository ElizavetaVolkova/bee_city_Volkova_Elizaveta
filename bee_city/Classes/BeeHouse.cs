using bee_city.Enums;
namespace bee_city.Classes
{
    internal class BeeHouse
    {
        public int HouseNumber { get; set; }
        public HouseType HouseType { get; set; }
        public Dimension Dimension { get; set; }
        public BeeFamily BeeFamily { get; set; }
        public Condition Condition { get; set; }
    }
}
