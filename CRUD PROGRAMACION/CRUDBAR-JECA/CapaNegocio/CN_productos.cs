using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarProd (string nombre, string desc, string precio, string cantidad, string estado)
        {
            objetoCD.Insertar(nombre, desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad), Convert.ToInt32(estado));

        }

        public void EditarProd(string nombre, string desc, string precio, string cantidad, string estado, string id)
        {
            objetoCD.Editar(nombre,desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad), Convert.ToInt32(estado), Convert.ToInt32(id));
        }

        public void EliminarProd(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
