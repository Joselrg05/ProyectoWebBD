using med_webb_capa_negocio;
using med_webb_CapaDato.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace med_webb_CapaNegocio
{
    public class pedido_services : crud_services<Pedido>
    {
        private med_webb_database modelo;
        
        public pedido_services(med_webb_database modelo) : base(modelo)
        {
            if (modelo == null)
                this.modelo = new med_webb_database();
            else
                this.modelo = modelo;
        }




    }
}
