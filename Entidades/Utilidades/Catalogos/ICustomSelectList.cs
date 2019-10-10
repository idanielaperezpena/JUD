using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ICustomSelectList
    {
        string DataValueField { get; }
        string DataTextField { get; }
    }

    public interface ICustomSelectList<out T> : ICustomSelectList, IEnumerable<T>, IEnumerable
    {
        T this[int index] { get; }
    }
}
