﻿namespace MilitaryElite
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission(IMission mission);
    }
}
