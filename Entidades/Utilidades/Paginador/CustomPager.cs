using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utilidades
{
    public class CustomPager<T> : IPager<T>
    {
        protected IEnumerable<T> Listado { get; set; }

        public int ItemCount { get; protected set; }
        public int ItemsPerPage { get; protected set; }
        public int PageCount { get; protected set; }
        public int ItemsForCaption { get; protected set; }
        public bool HasPages { get; protected set; }
        public bool HasCaption { get; protected set; }
        public int SelectedPage { get; protected set; }
        public bool IsEmpty { get; protected set; }
        public T this[int index] => Listado.ElementAt(index);

        public CustomPager()
        {
            Listado = Enumerable.Empty<T>();
        }

        public CustomPager(IEnumerable<T> listado)
        {
            Listado = listado;
        }

        public CustomPager(IEnumerable<T> listado, int paginaActual, int itemsPorPagina, int minItemsParaInfo)
        {
            ItemCount = listado.Count();
            ItemsPerPage = itemsPorPagina;
            PageCount = (int)Math.Ceiling((decimal)ItemCount / ItemsPerPage);
            ItemsForCaption = minItemsParaInfo;
            HasPages = PageCount > 1;
            HasCaption = ItemCount >= ItemsForCaption;
            IsEmpty = ItemCount == 0;
            SelectedPage = paginaActual;

            Paginar(listado);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Listado.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected virtual void Paginar(IEnumerable<T> listado)
        {
            if (SelectedPage > PageCount)
                SelectedPage = 1;

            Listado = listado.Skip((SelectedPage - 1) * ItemsPerPage)
                    .Take(ItemsPerPage);
        }
    }
}
