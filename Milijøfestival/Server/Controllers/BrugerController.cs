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
    public class BrugerController : Controller
    {
        private readonly ILogger<BrugerController> _logger;

        public BrugerController(ILogger<BrugerController> logger)
        {
            _logger = logger;
        }
        // Forbinder til databasen
        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        // Forbinder med Razorpage og henter intastet data
        public async Task<ActionResult<Bruger>> PutTask(Bruger nybruger)
        {

            connection.Open();
            try
            {
                // laver quiry for at indsætte intastet data i databasen
                string opretbruger = "INSERT INTO bruger (navn, telefonnr, email, fødselsdato, rolleid) VALUES (@navn, @telefonnr, @email, @fødselsdato, @rolleid)";
                var brugerArgumenter = new
                {
                    navn = nybruger.Navn,
                    telefonnr = nybruger.TelefonNr,
                    email = nybruger.Email,
                    fødselsdato = nybruger.Fødselsdato,
                    rolleid = nybruger.RolleId
                };
                await connection.ExecuteAsync(opretbruger, brugerArgumenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(nybruger);
        }
    }
}