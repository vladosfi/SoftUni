using _03BarracksFactory.Contracts;

using System;

namespace P03_BarraksWars.Core.InputCommands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IUnitFactory unitFactory;
        private IRepository repository;

        protected Command(string[] data, IUnitFactory unitFactory, IRepository repository)
        {
            this.data = data;
            this.unitFactory = unitFactory;
            this.repository = repository;
        }

        protected string[] Data => this.data;

        protected IUnitFactory UnitFactory => this.unitFactory;
        protected IRepository Repository => this.repository;

        public abstract string Execute();
    }
}
