using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using Milijøfestival.Shared;

namespace Milijøfestival.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HentBruger : Controller
    {
        private readonly ILogger<HentBruger> _logger;

        public HentBruger(ILogger<HentBruger> logger)
        {
            _logger = logger;
        }
        // Forbinder til databasen
        NpgsqlConnection connection = new NpgsqlConnection("UserID=systembruger; Password = TyQUmK3nz3xMw7Ua; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Henter en liste af brugere (SELECT / Read)
        public async Task<IEnumerable<Bruger>> Get()
        {

            connection.Open();
            var selectallbruger = "SELECT * FROM bruger";
            IEnumerable<Bruger> bruger;

            bruger = await connection.QueryAsync<Bruger>(selectallbruger);

            return bruger.ToList();
        }

    }
}

