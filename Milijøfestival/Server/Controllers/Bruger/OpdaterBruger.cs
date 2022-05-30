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
    public class OpdaterBruger : Controller
    {
        private readonly ILogger<OpdaterBruger> _logger;

        public OpdaterBruger(ILogger<OpdaterBruger> logger)
        {
            _logger = logger;
        }

        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Opdater table vagt colonne ertaget til true 
        public async Task<ActionResult<Bruger>> PutTask(Bruger opdaterbruger)
        {

            connection.Open();
            try
            {
                string update = "UPDATE bruger SET navn = @navn, telefonnr = @telefonnr, email = @email, fødselsdato = @fødselsdato, rolleid = @rolleid WHERE brugerid = @brugerid";
                var brugerArgumenter = new
                {
                    brugerid = opdaterbruger.BrugerId,
                    navn = opdaterbruger.Navn,
                    telefonnr = opdaterbruger.TelefonNr,
                    email = opdaterbruger.Email,
                    fødselsdato = opdaterbruger.Fødselsdato,
                    rolleid = opdaterbruger.RolleId
                };
                await connection.ExecuteAsync(update, brugerArgumenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(opdaterbruger);
        }
    }
}
