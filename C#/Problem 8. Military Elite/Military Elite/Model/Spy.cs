using Military_Elite.Model.Spys.Contracts;

namespace Military_Elite.Model.Spys
{
    public class Spy : ISpy
    {
        public Spy(int codeNumber)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }
    }
}
