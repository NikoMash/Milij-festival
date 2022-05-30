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
    public class HentKoordinatorer : Controller
    {
        private readonly ILogger<HentKoordinatorer> _logger;
        public HentKoordinatorer(ILogger<HentKoordinatorer> logger)
        {
            _logger = logger;
        }




        //Åben connection til azure server               
        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Henter en liste af koordinatorer (SELECT / Read)
        public async Task<IEnumerable<KoordinatorOversigtView>> Get()
        {

            connection.Open();
            var selectallkoordinatorer = "SELECT * FROM koordinatoroversigt";
            IEnumerable<KoordinatorOversigtView> koordinatorer;
            
            koordinatorer = await connection.QueryAsync<KoordinatorOversigtView>(selectallkoordinatorer);

            return koordinatorer.ToList();
        }



    }
}
