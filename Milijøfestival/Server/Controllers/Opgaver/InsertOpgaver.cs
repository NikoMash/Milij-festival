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
    public class InsertOpgaver : Controller
    {
        private readonly ILogger<InsertOpgaver> _logger;

        public InsertOpgaver(ILogger<InsertOpgaver> logger)
        {
            _logger = logger;
        }

        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");
        public async Task<ActionResult<Opgave>> PutTask(Opgave nyopg)
        {

            connection.Open();
            try
            {
                string opretopgave = "INSERT INTO opgave (opgbeskrivelse) VALUES (@opgbeskrivelse)";
                var opgaveArgumenter = new
                {
                    opgbeskrivelse = nyopg.OpgBeskrivelse,
                  
                };
                await connection.ExecuteAsync(opretopgave, opgaveArgumenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(nyopg);
        }
    
}
}
