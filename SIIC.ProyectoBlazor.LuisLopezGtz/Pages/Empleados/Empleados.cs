using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.Models;
using SIIC.ProyectoBlazor.LuisLopezGtz.Bussines_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisLopezGtz.Pages.Empleados
{
    public partial class Empleados
    {
        protected override async Task OnInitializedAsync()
        {
            await GetEmpleadoAsync();
        }

        #region Resources
        public List<EmpleadoModel> ListEmpleados { get; set; } = new List<EmpleadoModel>();
        public EmpleadoModel ObjEmpleado { get; set; } = new EmpleadoModel();

        public string TitleModal { get; set; }
        public string BgMHeader { get; set; }
        public string BtnSave { get; set; }
        #endregion

        #region Bussines Layer Inject
        [Inject]
        private EmpleadosBL EmpladosBL { get; set; }
        #endregion

        #region Bussines Layer Functions
        public async Task GetEmpleadoAsync ()
        {
            ListEmpleados = await EmpladosBL.GetEmpleadosAsync();
        }
        public async Task CreateEmepladoAsync()
        {
            await EmpladosBL.CreateEmpleadosAsync(ObjEmpleado);
            await AlertSucces("Nuevo empleado guardado");
        }

        public async Task UpdateEmpleadoAsync()
        {
            await EmpladosBL.UpdateEmpleadosAsync(ObjEmpleado);
            await AlertSucces("Empleado se ha actualizado");
        }
        public async Task DeleteEmpleadoAsync(EmpleadoModel Empleado)
        {
            await EmpladosBL.DeleteEmpleadosAsync(Empleado);
            await GetEmpleadoAsync();
        }
        #endregion

        #region Object Temporal
        private async Task ResetEmpleado()
        {
            ObjEmpleado = new EmpleadoModel();
            await GetEmpleadoAsync();
        }
        private void UpdateEmpleado(EmpleadoModel Empleado)
        {
            ObjEmpleado = Empleado;
            TitleModal = "Actualizar Empleado";
            BgMHeader = "bg-primary";
            BtnSave = "btn-primary";
        }

        private void CreateEmpleado()
        {
            TitleModal = "Agregar Nuevo Empleado";
            BgMHeader = "bg-success";
            BtnSave = "btn-success";
        }

        public async Task SaveChanges()
        {
            if (ObjEmpleado.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                await CreateEmepladoAsync();
                await ResetEmpleado();

            }
            else
            {
                await UpdateEmpleadoAsync();
                await ResetEmpleado();
            }
        }

        public async Task AlertAsyncDelete(EmpleadoModel Empleado)
        {
            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Desea eliminar a "+ Empleado.Nombre + "?",
                Text = "Esta acción es irreversible",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "Eliminar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                await DeleteEmpleadoAsync(Empleado);
                await Swal.FireAsync(
                  "Eliminado",
                  "La acción se realizó con exitó",
                  SweetAlertIcon.Success
                  );
            }           
        }

        public async Task AlertSucces(String Title)
        {
            await Swal.FireAsync(
                Title,
                "La acción se realizó con exitó",
                SweetAlertIcon.Success
                );
        }

        #endregion
    }
}