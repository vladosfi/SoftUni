namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.make = make;
            this.model = model;
            this.horsePower = horsePower;
            this.registrationNumber = registrationNumber;
        }

        public string Make => this.make;
        public string Model => this.model;
        public int HorsePower => this.horsePower;
        public string RegistrationNumber => this.registrationNumber;


    }
}
