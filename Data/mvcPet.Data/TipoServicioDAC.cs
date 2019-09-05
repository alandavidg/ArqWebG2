using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using mvcPet.Entities;

namespace mvcPet.Data
{
    public partial class TipoServicioDAC : DataAccessComponent, IRepository<TipoServicio>
    {
        public TipoServicio Create(TipoServicio tiposervicio)
        {
            const string SQL_STATEMENT = "INSERT INTO TipoServicio ([Nombre]) VALUES(@Nombre); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, tiposervicio.Nombre);
                tiposervicio.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return tiposervicio;
        }

        public List<TipoServicio> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM TipoServicio ";

            List<TipoServicio> result = new List<TipoServicio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoServicio tiposervicio = LoadEspecie(dr);
                        result.Add(tiposervicio);
                    }
                }
            }
            return result;
        }

        public TipoServicio ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM TipoServicio WHERE [Id]=@Id ";
            TipoServicio tiposervicio = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        tiposervicio = LoadEspecie(dr);
                    }
                }
            }
            return tiposervicio;
        }

        public void Update(TipoServicio tiposervicio)
        {
            const string SQL_STATEMENT = "UPDATE TipoServicio SET [Nombre]= @Nombre WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, tiposervicio.Nombre);
                db.AddInParameter(cmd, "@Id", DbType.Int32, tiposervicio.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE TipoServicio WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private TipoServicio LoadEspecie(IDataReader dr)
        {
            TipoServicio tiposervicio = new TipoServicio();
            tiposervicio.Id = GetDataValue<int>(dr, "Id");
            tiposervicio.Nombre = GetDataValue<string>(dr, "Nombre");
            return tiposervicio;
        }
    }
}

