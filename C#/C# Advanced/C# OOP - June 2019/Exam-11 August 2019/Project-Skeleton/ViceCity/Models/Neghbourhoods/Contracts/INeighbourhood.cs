namespace ViceCity.Models.Neghbourhoods.Contracts
{
    using ViceCity.Models.Players.Contracts;
    using System.Collections.Generic;

    public interface INeighbourhood
    {
        void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers);
    }
}
