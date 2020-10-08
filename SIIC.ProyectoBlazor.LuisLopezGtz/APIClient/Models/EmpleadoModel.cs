using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.Models
{
    public class EmpleadoModel
    {
        public Guid Id { get; set; }
        public Nullable<Guid> IdEmpresa { get; set; }
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
