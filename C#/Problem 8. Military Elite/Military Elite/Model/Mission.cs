using Military_Elite.Contacts;
using Military_Elite.Enumerables;

namespace Military_Elite.Model
{
    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State != State.Finished)
            {
                this.State = State.Finished;
            }
        }
    }
}
