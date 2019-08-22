using System.Collections.Generic;

namespace Military_Elite.Contacts
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}
