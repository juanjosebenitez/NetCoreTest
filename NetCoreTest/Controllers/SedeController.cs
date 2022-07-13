using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreTest.Models;

namespace NetCoreTest.Controllers
{
    [Produces("application/json")]
    [Route("api/Sede")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class SedeController : Controller
    {
        private readonly ApplicationDbContext context;

        public SedeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Sede> Get() {
            return context.Sede.FromSql("PA_GET_SEDE").ToList();
        }

        [HttpGet("Carrera")]
        public IEnumerable<Carrera> GetCarrera() {

            List<Carrera> lstCarrera = new List<Carrera>();


            using (var command = context.Database.GetDbConnection().CreateCommand()) {
                command.CommandText= "PA_GET_CARRERA";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                context.Database.OpenConnection();

                System.Data.Common.DbDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    Carrera objCarrera = new Carrera();

                    objCarrera.Codigo= result["Codigo"].ToString();
                    objCarrera.Id = Convert.ToInt32(result["Id"]);
                    objCarrera.Nombre = result["Nombre"].ToString();

                    lstCarrera.Add(objCarrera);
                }

                result.Close();

                context.Database.CloseConnection();
            }  

            return lstCarrera;
        }

    }
}