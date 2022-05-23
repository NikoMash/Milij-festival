using Dapper;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Milijøfestival.Shared;
using System.Linq;

namespace Milijøfestival.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HentTagetVagter : Controller
    {
        private readonly ILogger<HentTagetVagter> _logger;
        public HentTagetVagter(ILogger<HentTagetVagter> logger)
        {
            _logger = logger;
        }




        //Åben connection til azure server               
        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Henter en liste af vagter (SELECT / Read)
        public async Task<IEnumerable<Vagt>> Get()
        {

            connection.Open();
            var selectallertaget = "SELECT * FROM tagetvagter WHERE ertaget = true";
            IEnumerable<Vagt> tagetvagter;

            tagetvagter = await connection.QueryAsync<Vagt>(selectallertaget);

            return tagetvagter.ToList();
        }



    }
}