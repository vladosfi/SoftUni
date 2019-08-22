using Military_Elite.Enumerables;

namespace Military_Elite.Contacts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
