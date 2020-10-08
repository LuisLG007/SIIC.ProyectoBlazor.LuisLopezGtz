using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.Models;
using SIIC.ProyectoBlazor.LuisLopezGtz.Bussines_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisLopezGtz.Pages.Empresas
{
    public partial class Empresas
    {
        protected override async Task OnInitializedAsync()
        {
            await GetEmpresasAsync();
        }

        #region Resources
        public List<EmpresaModel> ListEmpresas { get; set; } = new List<EmpresaModel>();
        public EmpresaModel ObjEmpresa { get; set; } = new EmpresaModel();

        public string TitleModal { get; set; }
        public string BgMHeader { get; set; }
        public string BtnSave { get; set; }
        #endregion


        #region Inject
        [Inject]
        private EmpresasBL EmpresasBL { get; set; }
        [Inject]
        SweetAlertService Swal { get; set; }
        #endregion

        #region Bussines Layer Functions
        public async Task GetEmpresasAsync()
        {
            ListEmpresas = await EmpresasBL.GetEmpresasAsync();
        }

        public async Task CreateEmpresaAsync()
        {           
            bool Response = await EmpresasBL.CreateEmpresaAsync(ObjEmpresa);
            if (Response)
            {
                await Alert("Nueva empresa guardada", "Acción realizada con exito", true);
            }
            else
            {
                await Alert("Opps...", "Ocurrio un error", false);
            }
        }
        public async Task UpdateEmpresaAsync()
        {           
            bool Response = await EmpresasBL.UpdateEmpresaAsync(ObjEmpresa);
            if (Response)
            {
                await Alert("Empresa actualizada", "Acción realizada con exito", true);
            }
            else
            {
                await Alert("Opps...", "Ocurrio un error", false);
            }

        }
        public async Task DeleteEmpresaAsync(EmpresaModel Empresa)
        {
            await EmpresasBL.DeleteEmpresaAsync(Empresa);
            await GetEmpresasAsync();
        }
        #endregion



        #region Extras
        private async Task ResetEmpresa()
        {
            ObjEmpresa = new EmpresaModel();
            await GetEmpresasAsync();
        }
        private void UpdateEmpresa(EmpresaModel Empresa)
        {
            ObjEmpresa = Empresa;
            TitleModal = "Actualizar Empresa";
            BgMHeader = "bg-primary";
            BtnSave = "btn-primary";
        }     
        
        private void CreateEmpresa()
        {
            TitleModal = "Agregar Nueva Empresa";
            BgMHeader = "bg-success";
            BtnSave = "btn-success";
        }

        public async Task SaveChanges()
        {
            if (ObjEmpresa.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                await CreateEmpresaAsync();
                await ResetEmpresa();
            }
            else
            {
                await UpdateEmpresaAsync();
                await ResetEmpresa();
            }                      
        }


        public async Task AlertAsyncDelete(EmpresaModel Empresa)
        {
            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Desea eliminar a " + Empresa.RazonSocial + "?",
                Text = "Esta acción es irreversible",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "Eliminar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                await DeleteEmpresaAsync(Empresa);
                await Swal.FireAsync(
                  "Eliminado",
                  "La acción se realizó con exitó",
                  SweetAlertIcon.Success
                  );
            }
        }

        public async Task Alert(String Title, string SubTitle, bool Type)
        {
            if (Type)
            {
                await Swal.FireAsync(
                Title,
                SubTitle,
                SweetAlertIcon.Success
                );
            }
            else
            {
                await Swal.FireAsync(
               Title,
               SubTitle,
               SweetAlertIcon.Error
               );
            }
        }
        #endregion
    }
}
