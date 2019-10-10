using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CustomSelectList<T> : ICustomSelectList<T> where T : ICustomSelectList
    {
        public T this[int index] => _listado.ElementAt(index);

        public string DataValueField { get; private set; }
        public string DataTextField { get; private set; }
        private IEnumerable<T> _listado;

        public CustomSelectList(IEnumerable<T> listado)
        {
            var _type = Activator.CreateInstance<T>();
            DataValueField = _type.DataValueField;
            DataTextField = _type.DataTextField;

            _listado = listado;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _listado.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
