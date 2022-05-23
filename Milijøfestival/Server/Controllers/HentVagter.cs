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
    public class HentVagter : Controller
    {
        private readonly ILogger<HentVagter> _logger;
        public HentVagter(ILogger<HentVagter> logger)
        {
            _logger = logger;
        }




        //Åben connection til azure server               
        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");
                    
        //Henter en liste af vagter (SELECT / Read)
        public async Task<IEnumerable<Vagt>> Get()
        {

            connection.Open();           
            var selectallvagter = "SELECT * FROM vagt WHERE ertaget = false";
            IEnumerable<Vagt> vagter;
            
            vagter = await connection.QueryAsync<Vagt>(selectallvagter);
           
            return vagter.ToList();
        }

        

    }
}
