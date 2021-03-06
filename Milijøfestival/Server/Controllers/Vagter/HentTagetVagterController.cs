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




        //Connection til database               
        NpgsqlConnection connection = new NpgsqlConnection("UserID=systembruger; Password = TyQUmK3nz3xMw7Ua; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Henter en liste af vagter (SELECT / Read)
        public async Task<IEnumerable<TagetVagterView>> Get()
        {

            connection.Open();
            var selectallertaget = "SELECT * FROM tagetvagter";
            IEnumerable<TagetVagterView> tagetvagter;

            tagetvagter = await connection.QueryAsync<TagetVagterView>(selectallertaget);

            return tagetvagter.ToList();
        }



    }
}