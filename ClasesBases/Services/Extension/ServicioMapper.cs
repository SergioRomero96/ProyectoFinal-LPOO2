using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Services.Extension
{
    public class ServicioMapper
    {
        public static IEnumerable<Servicio> ToListServicios(DataTable dt)
        {
            List<Servicio> listServicios = new List<Servicio>(); ;
            
            foreach (DataRow row in dt.Rows)
            {
                Servicio servicio = new Servicio();

                servicio.Ser_Codigo = Convert.ToInt32(row[0]);
                servicio.Aut_Codigo = Convert.ToInt32(row[1]);
                servicio.Ser_FechaHora = Convert.ToDateTime(row[2]);
                servicio.Ter_Codigo_Origen = Convert.ToInt32(row[3]);
                servicio.Ter_Codigo_Destino = Convert.ToInt32(row[4]);
                servicio.Ser_Estado = row[5].ToString();

                listServicios.Add(servicio);
            }
            return listServicios;
        }
        public static Servicio ToService(DataTable dt) {

            Servicio servicio = new Servicio();

            servicio.Ser_Codigo = Convert.ToInt32(dt.Rows[0]["SER_Codigo"]);
            servicio.Aut_Codigo = Convert.ToInt32(dt.Rows[0]["AUT_Codigo"]);
            servicio.Ser_FechaHora = Convert.ToDateTime(dt.Rows[0]["SER_FechaHora"]);
            servicio.Ter_Codigo_Origen = Convert.ToInt32(dt.Rows[0]["TER_Codigo_Origen"]);
            servicio.Ter_Codigo_Destino = Convert.ToInt32(dt.Rows[0]["TER_Codigo_Destino"]);
            servicio.Ser_Estado = dt.Rows[0]["SER_Estado"].ToString();

            return servicio;
        }
    }
}
