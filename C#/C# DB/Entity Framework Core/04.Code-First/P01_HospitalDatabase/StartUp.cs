namespace P01_HospitalDatabase
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            var db = new HospitalContext();
            //db.Database.Migrate()
        }
    }
}
