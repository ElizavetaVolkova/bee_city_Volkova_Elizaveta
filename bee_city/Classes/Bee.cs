using bee_city.Enums;
namespace bee_city.Classes
{
    internal class Bee
    {
        public Guid BeeID { get; set; }
        public string BeeName { get; set; }
        public BeeRole BeeRole { get; set; }
        public BeeSchedule BeeSchedule { get; set; }
        public BeeHobby BeeHobby { get; set; }
    }
}
