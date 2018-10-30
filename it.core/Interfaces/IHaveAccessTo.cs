using System;
using System.Collections.Generic;
using System.Text;

namespace it.core.Interfaces
{
    /// <summary>
    /// Classes decorated with me get to have unfettered access to the Entity T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IHaveAccessTo<T> where T : It<T>, IAmAnEntity, new()
    {
        T ThisEntity { get; set; }
    }
}
