namespace FoodShortage
{
    public interface ICitizen : IBuyer
    {
        string Name { get; }

        int Age { get; }
    }
}
