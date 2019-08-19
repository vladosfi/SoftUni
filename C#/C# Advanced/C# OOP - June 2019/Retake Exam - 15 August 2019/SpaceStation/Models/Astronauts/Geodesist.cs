namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double Initial_Oxigen = 50;
        
        public Geodesist(string name)
            : base(name, Initial_Oxigen)
        {
        }
    }
}
