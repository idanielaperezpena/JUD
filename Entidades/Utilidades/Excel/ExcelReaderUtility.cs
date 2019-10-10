using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utilidades
{
    public class ExcelReaderUtility
    {
        private string _Sheet;
        private string _IdentityName;
        private string _connectionString;

        public ExcelReaderUtility(string pRutaArchivo, string pNombreHoja)
        {
            _IdentityName = "Id";
            _connectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=No;IMEX=1';", pRutaArchivo);
            _Sheet = pNombreHoja;
        }

        public void Read(DataTable pData)
        {
            var lIdentityCol = new DataColumn(_IdentityName, typeof(long));
            lIdentityCol.AutoIncrement = true;
            lIdentityCol.AutoIncrementSeed = 0;
            pData.Columns.Add(lIdentityCol);

            using (var lConnection = new OleDbConnection(_connectionString))
            {
                lConnection.Open();
                var lSchema = lConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var lSheet = (string.IsNullOrWhiteSpace(_Sheet) ? lSchema.Rows[0]["TABLE_NAME"].ToString() : _Sheet + "$").Replace('.', '#');

                using (var lCommand = new OleDbCommand())
                {
                    lCommand.CommandText = "Select * from [" + lSheet + "] ";
                    lCommand.Connection = lConnection;

                    using (var lAdapter = new OleDbDataAdapter())
                    {
                        lAdapter.SelectCommand = lCommand;
                        lAdapter.Fill(pData);
                        pData.TableName = lSheet;
                    }
                }
            }

            pData.Rows[0].Delete();
            pData.AcceptChanges();
        }
    }
}
