using SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.APIWebClient
{
    public class EmpresasAPI : HttpClient
    {
        #region Constructor
        public EmpresasAPI(string URLServer)
        {
            URLServer += (URLServer.EndsWith('/')) ? "api/Empresas/" : "/api/Empresas/";
            BaseAddress = new Uri(URLServer);
        }
        #endregion

        #region Empresas CRUD
        public async Task<List<EmpresaModel>> GetEmpresasAsync()
        {
            try
            {
                List<EmpresaModel> ObjEmpresasResponse = new List<EmpresaModel>();
                ObjEmpresasResponse = await this.GetFromJsonAsync<List<EmpresaModel>>("ObtenerEmpresas");
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
                var Request = await this.PostAsJsonAsync<EmpresaModel>("GuardarEmpresa", Empresa);
                bool Response = Request.Content.ReadFromJsonAsync<bool>().Result;
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
                var Request = await this.PostAsJsonAsync<EmpresaModel>("ActualizarEmpresa", Empresa);
                bool Response = Request.Content.ReadFromJsonAsync<bool>().Result;
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
                var Request = await this.PostAsJsonAsync<Guid>("EliminarEmpresa", Empresa.Id);
                bool Response = Request.Content.ReadFromJsonAsync<bool>().Result;
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
