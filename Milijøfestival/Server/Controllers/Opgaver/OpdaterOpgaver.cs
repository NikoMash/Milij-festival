using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Milijøfestival.Shared;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Milijøfestival.Server.Controllers.Opgaver
{
    public class OpdaterOpgaver : Controller
    {
        private readonly ILogger<OpdaterOpgaver> _logger;

        public OpdaterOpgaver(ILogger<OpdaterOpgaver> logger)
        {
            _logger = logger;
        }

        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Opdater table vagt colonne ertaget til true 
        public async Task<ActionResult<Opgave>> PutTask(Opgave opdateropgave)
        {

            connection.Open();
            try
            {
                string update = "UPDATE opgave SET opgbeskrivelse = @beskrivelse WHERE opgid = @opgid";
                var opgaveArgumenter = new
                {

                    opgid = opdateropgave.OpgId,
                    beskrivelse = opdateropgave.OpgBeskrivelse,
                   
                };
                await connection.ExecuteAsync(update, opgaveArgumenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(opdateropgave);
        }
    }
}
