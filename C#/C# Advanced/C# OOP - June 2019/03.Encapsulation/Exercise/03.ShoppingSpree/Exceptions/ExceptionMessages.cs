namespace ShoppingSpree.Exceptions
{
    public static class ExceptionMessages
    {
        public static readonly string NullOrEmptyNameException = "Name cannot be empty";

        public static readonly string MoneyCannotBeNegativeException = "Money cannot be negative";

        public static readonly string CannotAffordAProductException = "{0} can't afford {1}";
    }
}
