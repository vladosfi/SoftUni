﻿using System.Collections.Generic;

namespace Military_Elite.Contacts
{
    public interface ILieutenantGeneral
    {
        ICollection<ISoldier> Privates { get; }
    }
}
