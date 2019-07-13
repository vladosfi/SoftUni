namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        private string model;
        private string driverName;

        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
            model = "488-Spider";
        }

        public string DriverName { get => driverName; set => driverName = value; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.model}/{this.Brakes()}/{this.GasPedal()}/{this.DriverName}";

        }
    }
}
