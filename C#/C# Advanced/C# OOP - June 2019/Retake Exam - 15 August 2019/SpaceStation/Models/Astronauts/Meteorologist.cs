namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double Initial_Oxigen = 90;

        public Meteorologist(string name)
            : base(name, Initial_Oxigen)
        {
        }
    }
}
