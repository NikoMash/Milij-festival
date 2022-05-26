using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Milijøfestival.Shared;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milijøfestival.Server.Controllers.Opgaver
{
    [ApiController]
    [Route("[controller]")]
    public class HentOpgave : Controller
    {
        private readonly ILogger<HentOpgave> _logger;
        public HentOpgave(ILogger<HentOpgave> logger)
        {
            _logger = logger;
        }

        //Connection til database               
        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Henter en liste af vagter (SELECT / Read)
        public async Task<IEnumerable<Opgave>> Get()
        {

            connection.Open();
            var selectallopgaver = "SELECT * FROM opgave";
            IEnumerable<Opgave> opgaver;

            opgaver = await connection.QueryAsync<Opgave>(selectallopgaver);

            return opgaver.ToList();
        }
    }
}
