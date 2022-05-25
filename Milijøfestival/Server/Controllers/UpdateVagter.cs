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
    public class UpdateVagter : Controller
    { 
            private readonly ILogger<UpdateVagter> _logger;

            public UpdateVagter(ILogger<UpdateVagter> logger)
            {
                _logger = logger;
            }

            NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

            //Opdater table vagt colonne ertaget til true 
            public async Task<ActionResult<Vagt>> PutTask(Vagt updatevagt)
            {

                connection.Open();
                try
                {
                    string update = "UPDATE vagt SET sted = @sted, opgid =  @opgid, afdeling =  @afdeling, starttid = @starttid, sluttid = @sluttid WHERE vagtid = @vagtid";
                    var vagtArgumenter = new
                    {
                        
                        vagtid = updatevagt.VagtId,
                        sted = updatevagt.Sted,
                        opgid = updatevagt.OpgId,
                        afdeling = updatevagt.Afdeling,
                        startid = updatevagt.StartTid,
                        sluttid = updatevagt.SlutTid
                    };
                    await connection.ExecuteAsync(update, vagtArgumenter);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                return Ok(updatevagt);
            }
        
    }
}
