using SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.APIWebClient;
using SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisLopezGtz.Bussines_Layer
{
    public class EmpleadosBL
    {
        #region Constructor
        EmpleadosAPI EmpleadosAPI;
        public EmpleadosBL(EmpleadosAPI _EmpleadosAPI)
        {
            this.EmpleadosAPI = _EmpleadosAPI;
        }
        #endregion

        #region Functions BL
        public async Task<List<EmpleadoModel>> GetEmpleadosAsync()
        {
            try
            {
                List<EmpleadoModel> ObjEmpleadosResponse = new List<EmpleadoModel>();
                ObjEmpleadosResponse = await this.EmpleadosAPI.GetEmpleadoAsync();
                return ObjEmpleadosResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EmpleadoModel>();
                throw;
            }
        }

        public async Task<bool> CreateEmpleadosAsync(EmpleadoModel Empleado)
        {
            try
            {
                bool Response = await this.EmpleadosAPI.CreateEmpleadoAsync(Empleado);
                return Response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        public async Task<bool> UpdateEmpleadosAsync(EmpleadoModel Empleado)
        {
            try
            {
                bool Response = await this.EmpleadosAPI.UpdateEmpleadoAsync(Empleado);
                return Response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        public async Task<bool> DeleteEmpleadosAsync(EmpleadoModel Empleado)
        {
            try
            {
                bool Response = await this.EmpleadosAPI.DeleteEmpleadoAsync(Empleado);
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
