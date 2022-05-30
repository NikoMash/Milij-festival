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
    public class VagtController : Controller
    {
        private readonly ILogger<VagtController> _logger;

        public VagtController(ILogger<VagtController> logger)
        {
            _logger = logger;
        }

        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Lave en vagt (Create/INSERT)
        public async Task<ActionResult<Vagt>> PutTask(Vagt nyvagt)
        {

            connection.Open();
            try
            {
                string opretvagt = "INSERT INTO vagt (starttid, sluttid, afdeling, sted, opgid) VALUES (@starttid, @sluttid, @afdeling, @sted, @opgid)";
                var vagtArgumenter = new
                {
                    starttid = nyvagt.StartTid,
                    sluttid = nyvagt.SlutTid,
                    afdeling = nyvagt.Afdeling,
                    sted = nyvagt.Sted,
                    opgid = nyvagt.OpgId
                };
                await connection.ExecuteAsync(opretvagt, vagtArgumenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(nyvagt);  
        }
    }
}
