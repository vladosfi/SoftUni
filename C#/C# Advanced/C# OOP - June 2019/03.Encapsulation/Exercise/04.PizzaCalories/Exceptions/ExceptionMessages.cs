namespace PizzaCalories.Exceptions
{
    public static class ExceptionMessages
    {
        public static string DoughWeightOutOfRangeException = "Dough weight should be in the range [1..200].";

        public static string InvalidTypeOfDoughException = "Invalid type of dough.";

        public static string InvalidTypeOfToppingException = "Cannot place {0} on top of your pizza.";

        public static string InvalidValueOfToppingWeightException = "{0} weight should be in the range [1..50].";

        public static string InvalidPizzaNameException = "Pizza name should be between 1 and 15 symbols.";

        public static string ToppingOutOfRangeException = "Number of toppings should be in range [0..10].";
    }
}
