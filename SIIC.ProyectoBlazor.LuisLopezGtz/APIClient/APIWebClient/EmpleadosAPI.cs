using SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.APIWebClient
{
    public class EmpleadosAPI:HttpClient
    {
        #region Constructor
        public EmpleadosAPI(string URLServer)
        {
            URLServer += (URLServer.EndsWith('/')) ? "api/Empleados/" : "/api/Empleados/";
            BaseAddress = new Uri(URLServer);
        }
        #endregion

        #region Empleado CRUD
        public async Task<List<EmpleadoModel>> GetEmpleadoAsync()
        {
            try
            {
                List<EmpleadoModel> ObjEmpleadosResponse = new List<EmpleadoModel>();
                ObjEmpleadosResponse = await this.GetFromJsonAsync<List<EmpleadoModel>>("ObtenerEmpleados");
                return ObjEmpleadosResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EmpleadoModel>();
                throw;
            }
        }

        public async Task<bool> CreateEmpleadoAsync(EmpleadoModel Empleado)
        {
            try
            {
                var Request = await this.PostAsJsonAsync<EmpleadoModel>("GuardarEmpleado", Empleado);
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

        public async Task<bool> UpdateEmpleadoAsync(EmpleadoModel Empleado)
        {
            try
            {
                var Request = await this.PostAsJsonAsync<EmpleadoModel>("ActualizarEmpleado", Empleado);
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


        public async Task<bool> DeleteEmpleadoAsync(EmpleadoModel Empleado)
        {
            try
            {
                var Request = await this.PostAsJsonAsync<Guid>("EliminarEmpleado", Empleado.Id);
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
