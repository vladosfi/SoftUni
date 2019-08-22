using System.Collections.Generic;

namespace Military_Elite.Contacts
{
    public interface ILieutenantGeneral
    {
        List<IPrivate> Privates { get; }
    }
}
