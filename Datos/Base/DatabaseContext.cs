using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace Datos
{
    public class DatabaseContext : DatabaseProviderFactory
    {
        private Database _database;

        public DatabaseContext()
        {
            _database = Create("DbContext");
        }

        /// <summary>
        /// Utilizada para generar un bloque transaccional de BD, todas las instrucciones del bloque pertenecen a la misma transacción.
        /// <remarks>Es responsabilidad del Desarrollador utilizarlo dentro de un bloque using.</remarks>
        /// </summary>
        public TransactionScope TransactionScope { get; set; }
        /// <summary>
        /// Realiza la ejecución del comando a través de ExecuteNonQuery
        /// </summary>
        /// <param name="pStored">Nombre del Stored Procedure a ejecutar</param>
        /// <returns>Número de filas afectadas</returns>
        protected int Ejecutar(string pStored)
        {
            return Ejecutar(pStored, null);
        }
        /// <summary>
        /// Realiza la ejecución del comando a través de ExecuteNonQuery
        /// </summary>
        /// <param name="pCommand">Comando personalizado a ejecutar, es responsabilidad del método padre llamar su método Dispose</param>
        /// <returns>Número de filas afectadas</returns>
        protected int Ejecutar(DbCommand pCommand)
        {
            return _database.ExecuteNonQuery(pCommand);
        }
        /// <summary>
        /// Realiza la ejecución del comando a través de ExecuteNonQuery
        /// </summary>
        /// <param name="pStored">Nombre del Stored Procedure a ejecutar</param>
        /// <param name="pParametros">Valores de los parametros del Stored Procedure</param>
        /// <returns>Número de filas afectadas</returns>
        public int Ejecutar(string pStored, params object[] pParametros)
        {
            using (var lCommand = ObtenerCommand(pStored, pParametros))
            {
                return Ejecutar(lCommand);
            }
        }
        /// <summary>
        /// Realiza la ejecución del comando para obtener el Resultset a leer
        /// </summary>
        /// <param name="pStored">Nombre del Stored Procedure a ejecutar</param>
        /// <param name="pParametros">Valores de los parametros del Stored Procedure</param>
        /// <returns>El IDataReader con el resultado generado</returns>
        public IDataReader ObtenerDataReader(string pStored, params object[] pParametros)
        {
            using (var lCommand = ObtenerCommand(pStored, pParametros))
            {
                return ObtenerDataReader(lCommand);
            }
        }
        /// <summary>
        /// Realiza la ejecución del comando para obtener el Resultset a leer
        /// </summary>
        /// <param name="pCommand">Comando personalizado a ejecutar, es responsabilidad del método padre llamar su método Dispose</param>
        /// <returns>El IDataReader con el resultado generado</returns>
        protected IDataReader ObtenerDataReader(DbCommand pCommand)
        {
            return _database.ExecuteReader(pCommand);
        }
        /// <summary>
        /// Genera el DbCommand para un Stored Procedure
        /// </summary>
        /// <param name="pStored">Nombre del Stored Procedure a ejecutar</param>
        /// <param name="pParametros">Valores de los parametros del Stored Procedure</param>
        /// <returns>El DbCommand personalizado</returns>
        protected DbCommand ObtenerCommand(string pStored, object[] pParametros = null)
        {
            if (pParametros == null || pParametros.Length == 0)
                return _database.GetStoredProcCommand(pStored);
            else
                return _database.GetStoredProcCommand(pStored, pParametros);
        }
        /// <summary>
        /// Prepara los parametros necesarios para la ejecución del comando
        /// </summary>
        /// <param name="pCommand">Comando personalizado a ejecutar</param>
        /// <param name="pNombre">Nombre del Parametro</param>
        /// <param name="pTipo">Tipo de Parametro</param>
        /// <param name="pValor">Valor del Parametro</param>

        private bool IsBuiltIn<T>()
        {
            var lTipo = typeof(T);

            return lTipo.IsPrimitive || lTipo.IsEnum || lTipo == typeof(string) || lTipo == typeof(decimal) ||
                lTipo == typeof(DateTime) || (lTipo.IsGenericType && lTipo.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        private T RowToObject<T>(IDataReader pReader, PropertyInfo[] properties)
        {
            var newObj = Activator.CreateInstance<T>();

            for (var idx = 0; idx < pReader.FieldCount; idx++)
            {
                var property = properties.SingleOrDefault(p => p.Name == pReader.GetName(idx));

                if (property != null && pReader[idx] != DBNull.Value)
                    property.SetValue(newObj, pReader[idx]);
            }

            return newObj;
        }

        private T RowToBasic<T>(IDataReader pReader, int idxPropiedad = 0)
        {
            if (pReader[idxPropiedad] == DBNull.Value || string.IsNullOrWhiteSpace(pReader[idxPropiedad].ToString()))
                return default(T);

            if (typeof(T).IsEnum)
                return (T)Enum.Parse(typeof(T), pReader[idxPropiedad].ToString());

            var converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)converter.ConvertFrom(pReader[idxPropiedad].ToString());
        }

        public T ObtenerPrimero<T>(IDataReader pReader)
        {
            if (IsBuiltIn<T>())
            {
                if (pReader.Read())
                    return RowToBasic<T>(pReader);
            }
            else
            {
                var properties = typeof(T).GetProperties();

                if (pReader.Read())
                    return RowToObject<T>(pReader, properties);
            }

            return default(T);
        }

        protected T ObtenerPrimero<T>(DbCommand pCommand)
        {
            using (var lReader = ObtenerDataReader(pCommand))
            {
                return ObtenerPrimero<T>(lReader);
            }
        }

        protected T ObtenerPrimero<T>(string pStored)
        {
            return ObtenerPrimero<T>(pStored, null);
        }

        public T ObtenerPrimero<T>(string pStored, params object[] pParametros)
        {
            using (var lReader = ObtenerDataReader(pStored, pParametros))
            {
                return ObtenerPrimero<T>(lReader);
            }
        }

        public List<T> ObtenerLista<T>(IDataReader pReader)
        {
            var lResultado = new List<T>();

            if (IsBuiltIn<T>())
            {
                while (pReader.Read())
                    lResultado.Add(RowToBasic<T>(pReader));
            }
            else
            {
                var properties = typeof(T).GetProperties();

                while (pReader.Read())
                    lResultado.Add(RowToObject<T>(pReader, properties));
            }

            return lResultado;
        }

        protected List<T> ObtenerLista<T>(DbCommand pCommand)
        {
            using (var lReader = ObtenerDataReader(pCommand))
            {
                return ObtenerLista<T>(lReader);
            }
        }

        protected List<T> ObtenerLista<T>(string pStored)
        {
            return ObtenerLista<T>(pStored, null as object);
        }

        public List<T> ObtenerLista<T>(string pStored, params object[] pParametros)
        {
            using (var lReader = ObtenerDataReader(pStored, pParametros))
            {
                return ObtenerLista<T>(lReader);
            }
        }
    }
}
