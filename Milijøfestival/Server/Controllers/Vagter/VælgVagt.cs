using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Milijøfestival.Shared;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Milijøfestival.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VælgVagt : Controller
    {
        private readonly ILogger<VælgVagt> _logger;

        public VælgVagt(ILogger<VælgVagt> logger)
        {
            _logger = logger;
        }

        NpgsqlConnection connection = new NpgsqlConnection("UserID=systembruger; Password = TyQUmK3nz3xMw7Ua; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Opdater table vagt colonne ertaget til true 
        public async Task<ActionResult<Vagt>> PutTask(Vagt vagttaget)
        {

            connection.Open();
            try
            {
                string updatevagt = "UPDATE vagt SET ertaget = true WHERE vagtid=@vagtid";
                var vagtArgumenter = new
                {
                    vagtid = vagttaget.VagtId
                };
                await connection.ExecuteAsync(updatevagt, vagtArgumenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(vagttaget);  
        }
    }
}