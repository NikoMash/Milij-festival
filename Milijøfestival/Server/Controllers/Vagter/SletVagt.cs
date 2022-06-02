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
    public class SletVagt : Controller
    {
        private readonly ILogger<SletVagt> _logger;

        public SletVagt(ILogger<SletVagt> logger)
        {
            _logger = logger;
        }

        NpgsqlConnection connection = new NpgsqlConnection("UserID=systembruger; Password = TyQUmK3nz3xMw7Ua; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Slet en vagt (DELETE)
        public async Task<ActionResult<Vagt>> PutTask(Vagt vagtslet)
        {

            connection.Open();
            try
            {
                string sletvagt = "DELETE FROM vagt WHERE vagtid=@vagtid";
                var vagtArgumenter = new
                {
                    vagtid = vagtslet.VagtId
                };
                await connection.ExecuteAsync(sletvagt, vagtArgumenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(vagtslet);
        }
    }
}

