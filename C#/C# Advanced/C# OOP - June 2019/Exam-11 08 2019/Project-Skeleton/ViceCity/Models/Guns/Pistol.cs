namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int DefaultBulletsPerBarrel = 10;
        private const int DefaultTotalBullets = 100;

        public Pistol(string name) 
            : base(name, DefaultBulletsPerBarrel, DefaultTotalBullets)
        {
        }

        public override int Fire()
        {
            int shotCounts = 0;

            if (this.BulletsPerBarrel <= 0)
            {
                if (this.TotalBullets >= DefaultBulletsPerBarrel)
                {
                    this.BulletsPerBarrel += DefaultBulletsPerBarrel;
                    this.TotalBullets -= DefaultBulletsPerBarrel;
                }
                else
                {
                    this.BulletsPerBarrel += this.TotalBullets;
                    this.TotalBullets = 0;
                }
            }

            shotCounts = 1;
            
            this.BulletsPerBarrel--;

            return shotCounts;
        }
    }
}
