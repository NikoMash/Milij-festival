using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Threading.Tasks;
using Milijøfestival.Shared;
using System;
using Dapper;

namespace Milijøfestival.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SletBruger : Controller
    {
        private readonly ILogger<SletBruger> _logger;

        public SletBruger(ILogger<SletBruger> logger)
        {
            _logger = logger;
        }

        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Slet en vagt (DELETE)
        public async Task<ActionResult<Bruger>> PutTask(Bruger brugerslet)
        {

            connection.Open();
            try
            {
                string sletbruger = "DELETE FROM bruger WHERE brugerid=@brugerid";
                var brugerArgumenter = new
                {
                    brugerid = brugerslet.BrugerId
                };
                await connection.ExecuteAsync(sletbruger, brugerArgumenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(brugerslet);
            
        }
    }
}
