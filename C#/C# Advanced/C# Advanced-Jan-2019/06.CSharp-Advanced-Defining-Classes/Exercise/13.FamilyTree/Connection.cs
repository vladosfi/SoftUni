﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _13.FamilyTree
{
    public class Connection
    {
        public Person Parent { get; set; }
        public Person Child { get; set; }


        public Connection(Person parent, Person child)
        {
            this.Parent = parent;
            this.Child = child;
        }
    }
}
