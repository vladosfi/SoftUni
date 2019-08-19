namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double Initial_Oxigen = 70;
        private const double Oxigen_Decreases_On_Breath = 5;

        public Biologist(string name) 
            : base(name, Initial_Oxigen)
        {
        }


        public override void Breath()
        {
            if (this.Oxygen - Oxigen_Decreases_On_Breath < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= Oxigen_Decreases_On_Breath;
            }
        }
    }
}
