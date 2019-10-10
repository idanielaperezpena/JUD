using System.Collections.Generic;
using System.Transactions;

namespace Datos
{
    public interface IRepository
    {
        TransactionScope TxScope { get; set; }
    }

    public interface IRepository<T> : IRepository
    {
        T Alta(T pGeneric);
        void Baja(T pGeneric);
        T ObtenerEntidad(T pGeneric);
        List<T> ObtenerListado(T pGeneric);
    }
}
