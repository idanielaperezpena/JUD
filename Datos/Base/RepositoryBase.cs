using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace Datos
{
    public abstract class RepositoryBase : IRepository
    {
        protected DatabaseContext _context;
        public TransactionScope TxScope { get => _context.TransactionScope; set => _context.TransactionScope = value; }

        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }

        protected IDataReader ObtenerDataReader(string pStored, params object[] pParametros)
        {
            return _context.ObtenerDataReader(pStored, pParametros);
        }
        protected void Ejecutar(string pStored, params object[] pParametros)
        {
            _context.Ejecutar(pStored, pParametros);
        }
        protected T ObtenerPrimero<T>(IDataReader reader)
        {
            return _context.ObtenerPrimero<T>(reader);
        }
        protected T ObtenerPrimero<T>(string pStored, params object[] pParametros)
        {
            return _context.ObtenerPrimero<T>(pStored, pParametros);
        }
        protected List<T> ObtenerLista<T>(IDataReader reader)
        {
            return _context.ObtenerLista<T>(reader);
        }
        protected List<T> ObtenerLista<T>(string pStored, params object[] pParametros)
        {
            return _context.ObtenerLista<T>(pStored, pParametros);
        }
    }

    public abstract class RepositoryBase<T> : RepositoryBase, IRepository<T>
    {
        public RepositoryBase(DatabaseContext context) : base(context) { }

        public abstract T ObtenerEntidad(T pGeneric);
        public abstract T Alta(T pGeneric);
        public abstract void Baja(T pGeneric);
        public abstract List<T> ObtenerListado(T pGeneric);

        protected T ObtenerPrimero(IDataReader reader)
        {
            return _context.ObtenerPrimero<T>(reader);
        }
        protected T ObtenerPrimero(string pStored, params object[] pParametros)
        {
            return _context.ObtenerPrimero<T>(pStored, pParametros);
        }
        protected List<T> ObtenerLista(IDataReader reader)
        {
            return _context.ObtenerLista<T>(reader);
        }
        protected List<T> ObtenerLista(string pStored, params object[] pParametros)
        {
            return _context.ObtenerLista<T>(pStored, pParametros);
        }
    }
}
