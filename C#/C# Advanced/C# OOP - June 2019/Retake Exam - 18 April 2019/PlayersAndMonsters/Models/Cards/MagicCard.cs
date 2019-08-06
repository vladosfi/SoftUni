namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int Initial_Damage_Points = 5;
        private const int Initial_Health_Points = 80;

        public MagicCard(string name) 
            : base(name, Initial_Damage_Points, Initial_Health_Points)
        {
        }
    }
}
