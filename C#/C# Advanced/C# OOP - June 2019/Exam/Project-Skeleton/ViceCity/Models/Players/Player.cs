﻿using System;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player's name cannot be null or a whitespace!");
                }
                this.name = value;
            }
        }
        public bool IsAlive => this.lifePoints > 0;

        //•	GunRepository - IRepository<Gun>
        //o   Generic repository of all player's guns
        public IRepository<IGun> GunRepository { get; private set; }

        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            int decreasedPoints = this.lifePoints - points;

            if (decreasedPoints< 0)
            {
                this.LifePoints = 0;
            }

            this.LifePoints = decreasedPoints;
        }
    }
}
