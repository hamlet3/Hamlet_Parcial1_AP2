using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Razones : ClaseMaestra
    {
        public int RazonId { get; set; }
        public string Razon { get; set; }
        public List<Materiales> ListaMateriales = new List<Materiales>();

        public Razones() { }

        public void AgregarMaterial(string material, int cantidad) {
            ListaMateriales.Add(new Materiales(material, cantidad));
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retornar;
            object identity;
            try
            {
                identity = conexion.ObtenerValor(String.Format("Insert into Razones(Razon) Values('{0}') Select @@identity", this.Razon));
                int.TryParse(identity.ToString(), out retornar);
                foreach(Materiales material in ListaMateriales)
                {
                    conexion.Ejecutar(String.Format("Insert into Materiales(RazonId, Material, Cantidad) Values({0},'{1}',{2})", retornar, material.Material, material.Cantidad));
                }
            }catch(Exception ex) { throw ex; }

            return retornar > 0;
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retornar = false;
            try
            {
                retornar=conexion.Ejecutar(String.Format("Update Razones set Razon = '{0}' where RazonId ={1}", this.Razon, this.RazonId));
                
                conexion.Ejecutar(String.Format("Delete from Materiales where RazonId ={0}", this.RazonId));

                foreach (Materiales material in ListaMateriales) {
                    conexion.Ejecutar(String.Format("Insert into Materiales(RazonId, Material, Cantidad) Values ({0},'{1}',{2})",this.RazonId, material.Material, material.Cantidad));
                }
            }catch(Exception ex) { throw ex; }
            return retornar;

        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retornar = false;
            try
            {
                retornar = conexion.Ejecutar(String.Format("Delete from Materiales where RazonId={0}",this.RazonId+";"+"Delete Razones where RazonId="+this.RazonId));
            }catch(Exception ex) { throw ex; }

            return retornar;
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable MaterialDt = new DataTable();

            dt = conexion.ObtenerDatos(String.Format("Select * from Razones where RazonId ="+IdBuscado));
            if (dt.Rows.Count > 0)
            {
                this.RazonId = (int)dt.Rows[0]["RazonId"];
                this.Razon = dt.Rows[0]["Razon"].ToString();

                MaterialDt = conexion.ObtenerDatos(String.Format("Select * from Materiales where RazonId ="+IdBuscado));

                foreach (DataRow row in MaterialDt.Rows) {
                    AgregarMaterial(row["Material"].ToString(),(int)row["Cantidad"]);
                }
                
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listar(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenar = "";
            if (Orden.Equals(""))
                ordenar = "Order by " + Orden;

            return conexion.ObtenerDatos(String.Format("Select " + Campos + " from Razones where " + Condicion + ordenar));
        }
    }
}
