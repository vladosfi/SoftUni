namespace CarEngineAndTires
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = horsePower;
        }

        public int HorsePower
        {
            get
            {
                return horsePower;
            }
            private set
            {
                this.horsePower = value;
            }
        }

        public double CubicCapacity
        {
            get
            {
                return cubicCapacity;
            }
            private set
            {
                this.cubicCapacity = value;
            }
        }
    }
}
