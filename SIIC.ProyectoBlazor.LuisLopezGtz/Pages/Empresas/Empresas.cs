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


        #region Bussines Layer Inject
        [Inject]
        private EmpresasBL EmpresasBL { get; set; }
        #endregion

        #region Bussines Layer Functions
        public async Task GetEmpresasAsync()
        {
            ListEmpresas = await EmpresasBL.GetEmpresasAsync();
        }

        public async Task CreateEmpresaAsync()
        {
            await EmpresasBL.CreateEmpresaAsync(ObjEmpresa);            
            await GetEmpresasAsync();
        }
        public async Task UpdateEmpresaAsync()
        {
            await EmpresasBL.UpdateEmpresaAsync(ObjEmpresa);
            ResetEmpresa();
            await GetEmpresasAsync();
        }
        public async Task DeleteEmpresaAsync(EmpresaModel Empresa)
        {
            await EmpresasBL.DeleteEmpresaAsync(Empresa);
            await GetEmpresasAsync();
        }
        #endregion



        #region Extras
        private void ResetEmpresa()
        {
            ObjEmpresa = new EmpresaModel();
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
                ResetEmpresa();
            }
            else
            {
                await UpdateEmpresaAsync();
                ResetEmpresa();
            }                      
        }
        #endregion
    }
}
