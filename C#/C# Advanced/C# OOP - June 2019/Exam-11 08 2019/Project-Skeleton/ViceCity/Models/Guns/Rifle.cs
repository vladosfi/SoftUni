namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int DefaultBulletsPerBarrel = 50;
        private const int DefaultTotalBullets = 500;

        public Rifle(string name)
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

            if (this.BulletsPerBarrel >= 5)
            {
                shotCounts = 5;
            }
            else
            {
                shotCounts = this.BulletsPerBarrel;
            }

            this.BulletsPerBarrel -= shotCounts;

            return shotCounts;
        }
    }
}
