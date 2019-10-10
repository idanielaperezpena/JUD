using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IPager
    {
        int ItemCount { get; }
        int PageCount { get; }
        int ItemsPerPage { get; }
        int ItemsForCaption { get; }
        bool HasPages { get; }
        bool HasCaption { get; }
        int SelectedPage { get; }
        bool IsEmpty { get; }
    }

    public interface IPager<out T> : IPager, IEnumerable<T>, IEnumerable
    {
        T this[int index] { get; }
    }
}
