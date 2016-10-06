using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                MaterialesGv.DataSource = Session["Dt"];
                MaterialesGv.DataBind();
            }
        }

        public void Limpiar() {
            Razontxt.Text = "";
            Materialtxt.Text = "";
            Cantidadtxt.Text = "";
            MaterialesGv.DataSource = Session["Dt"];
            MaterialesGv.DataBind();
        }

        protected void GuardarBtn_Click(object sender, EventArgs e)
        {
            Razones razon;
            if (Session["Razon"] == null)
                Session["Razon"] = new Razones();

            razon = (Razones)Session["Razon"];


            if (BuscarIdtxt.Text=="") {

                razon.Razon = Razontxt.Text;
                razon.Insertar();
                Limpiar();
            }
            else
            {
                int aux;
                int.TryParse(BuscarIdtxt.Text, out aux);
                razon.RazonId = aux;
                razon.Razon = Razontxt.Text;
                razon.Editar();
                Limpiar();
            }


        }

        public List<Materiales> ObtenerNuevaLista()
        {
            List<Materiales> lista = new List<Materiales>();
            Materiales material = new Materiales();
            lista.Add(material);

            return lista;
        }

        public List<Materiales> ObtenerLista()
        {
            if (Session["Material"] == null)
            {
                return ObtenerNuevaLista();
            }else
            {
                return (List<Materiales>)Session["Material"];
            }
        }

        public List<Materiales> GuardatLista(Materiales material)
        {
            if (Session["Material"] == null)
            {
                List<Materiales> material2 = ObtenerLista();
                material2.Add(material);
                Session["Material"] = material2;
            }else
            {
                List<Materiales> material2 = (List<Materiales>)Session["Material"];
                material2.Add(material);
                Session["Material"] = material2;
            }

            return (List<Materiales>)Session["Material"];
        }

        protected void AgregarBtn_Click(object sender, EventArgs e)
        {
            int aux;
            Razones razon;
            if (Session["Razon"] == null)
                Session["Razon"] = new Razones();

            razon = (Razones)Session["Razon"];
            Materiales material = new Materiales();
            int.TryParse(Cantidadtxt.Text, out aux);

            razon.AgregarMaterial(Materialtxt.Text, aux);
            Session["Razon"] = razon;

            material.Material = Materialtxt.Text;
            material.Cantidad = aux;

            GuardatLista(material);
            MaterialesGv.DataSource = ObtenerLista();
            MaterialesGv.DataBind();
        }

        protected void BuscarIdBtn_Click(object sender, EventArgs e)
        {
            Razones razon = new Razones();
            int aux;
            int.TryParse(BuscarIdtxt.Text, out aux);
            razon.RazonId = aux;
            razon.Buscar(aux);
            Razontxt.Text = razon.Razon;

            foreach(Materiales material in razon.ListaMateriales)
            {
                GuardatLista(material);
            }
            MaterialesGv.DataSource = ObtenerLista();
            MaterialesGv.DataBind();
        }

        protected void EliminarBtn_Click(object sender, EventArgs e)
        {
            Razones razon = new Razones();
            int aux;
            int.TryParse(BuscarIdtxt.Text, out aux);
            razon.RazonId = aux;
            razon.Eliminar();
            Limpiar();
        }

        protected void NuevoBtn_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}