namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int Initial_Damage_Points = 120;
        private const int Initial_Health_Points = 5;

        public TrapCard(string name)
            : base(name, Initial_Damage_Points, Initial_Health_Points)
        {
        }
    }
}