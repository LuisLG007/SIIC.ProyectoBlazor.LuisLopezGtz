using SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.APIWebClient;
using SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisLopezGtz.Bussines_Layer
{
    public class EmpresasBL
    {
        #region Constructor
        EmpresasAPI EmpresasAPI;
        public EmpresasBL(EmpresasAPI _EmpresasApi)
        {
            this.EmpresasAPI = _EmpresasApi;
        }
        #endregion

        #region Functions BL
        public async Task<List<EmpresaModel>> GetEmpresasAsync()
        {
            try
            {
                List<EmpresaModel> ObjEmpresasResponse = new List<EmpresaModel>();
                ObjEmpresasResponse = await this.EmpresasAPI.GetEmpresasAsync();
                return ObjEmpresasResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EmpresaModel>();
                throw;
            }
        }

        public async Task<bool> CreateEmpresaAsync(EmpresaModel Empresa)
        {
            try
            {
                bool Response = await this.EmpresasAPI.CreateEmpresaAsync(Empresa);
                return Response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        public async Task<bool> UpdateEmpresaAsync(EmpresaModel Empresa)
        {
            try
            {
                bool Response = await this.EmpresasAPI.UpdateEmpresaAsync(Empresa);
                return Response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        public async Task<bool> DeleteEmpresaAsync(EmpresaModel Empresa)
        {
            try
            {
                bool Response = await this.EmpresasAPI.DeleteEmpresaAsync(Empresa);
                return Response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }
        #endregion
    }
}
