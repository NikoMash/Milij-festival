using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Milijøfestival.Shared;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Milijøfestival.Server.Controllers.Opgaver
{
    [ApiController]
    [Route("[controller]")]
    public class SletOpgaver : Controller
    {
        private readonly ILogger<SletOpgaver> _logger;

        public SletOpgaver(ILogger<SletOpgaver> logger)
        {
            _logger = logger;
        }

        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        public async Task<ActionResult<Opgave>> PutTask(Opgave opgaveslet)
        {

            connection.Open();
            try
            {
                string sletopgave = "DELETE FROM opgave WHERE opgid=@opgid";
                var opgaveArgumenter = new
                {
                    opgid = opgaveslet.OpgId
                };
                await connection.ExecuteAsync(sletopgave, opgaveArgumenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(opgaveslet);
        }
    }
}
