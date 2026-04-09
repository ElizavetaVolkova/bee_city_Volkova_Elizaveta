namespace bee_city.Classes
{
    internal class BeeCity
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public Address Address { get; set; }
        public List<BeeHouse> BeesHouses { get; set; }
        public DateTime DateOfFoundation { get; set; }
    }
}
