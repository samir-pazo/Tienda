using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class DataContext
    {

        protected string ConnectionString { get; set; }

        public DataContext()
        {
            //entre comillas colocamos el nombre de la cadena de conexion a utilixzar 
            //que se especifica en el archivo app.config de la capa PRESENTACION
            ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionTienda"].ConnectionString;
        }

    }
}
