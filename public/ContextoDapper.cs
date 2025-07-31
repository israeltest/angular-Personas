using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiProductos.Datos
{
    public class ContextoDapper
    {
        private readonly IConfiguration _configuracion;
        private readonly string _cadenaConexion;

        public ContextoDapper(IConfiguration configuracion)
        {
            _configuracion = configuracion;
            _cadenaConexion = _configuracion.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CrearConexion() => new SqlConnection(_cadenaConexion);
    }
}
