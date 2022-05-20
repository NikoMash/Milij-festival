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


        
        
        //Henter en liste af vagter (SELECT / Read)
        [HttpGet]
        public async Task<IEnumerable<Vagt>> Get()
        {
            NpgsqlConnection connection = new NpgsqlConnection("SuperUser");
            connection.Open();
            var selectstedvagter = "SELECT * FROM vagt";
            IEnumerable<Vagt> vagter = null;
            /*using (connection)
            {*/
                 vagter = await connection.QueryAsync<Vagt>(selectstedvagter);
            //}
            return vagter.ToList();
        }


    }
}
