namespace _04.Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        public string Browsing(string site)
        {
            foreach (var symbol in site)
            {
                if (char.IsDigit(symbol))
                {
                    return $"Invalid URL!";
                }
            }

            return $"Browsing: {site}!";            
        }

        public string Calling(string phoneNumber)
        {
            foreach (var symbol in phoneNumber)
            {
                if (char.IsLetter(symbol))
                {
                    return "Invalid number!";
                }
            }
            return $"Calling... {phoneNumber}";
        }
    }
}
