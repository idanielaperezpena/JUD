using Entidades.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class PagedViewModel<T>
    {
        public virtual int ItemsPerPage => 30;
        public virtual int ItemsForCaption => 5;
        public virtual string NameControlSelectedPage { get; private set; }
        public virtual string NameControlPrevNext { get; private set; }
        public virtual int ddlSelectedPage { get; set; }
        public IPager<T> Listado { get; set; }
        public virtual string btnPage { get; set; }

        protected PagedViewModel()
        {
            ddlSelectedPage = 1;
            NameControlSelectedPage = "ddlSelectedPage";
            NameControlPrevNext = "btnPage";
            Listado = new CustomPager<T>();
        }
    }
}