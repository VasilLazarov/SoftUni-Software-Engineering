using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models.InterFaces
{
    public interface IAddRemoveCollection : IAddCollection
    {
        string Remove();
    }
}
