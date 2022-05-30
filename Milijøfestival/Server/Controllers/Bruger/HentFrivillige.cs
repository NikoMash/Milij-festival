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
    public class HentFrivillige : Controller
    {
        private readonly ILogger<HentFrivillige> _logger;
        public HentFrivillige(ILogger<HentFrivillige> logger)
        {
            _logger = logger;
        }




        //Åben connection til azure server               
        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        //Henter en liste af frivillige (SELECT / Read)
        public async Task<IEnumerable<FrivilligOversigtView>> Get()
        {

            connection.Open();
            var selectallfrivillige = "SELECT * FROM frivilligoversigt";
            IEnumerable<FrivilligOversigtView> frivillige;

            frivillige = await connection.QueryAsync<FrivilligOversigtView>(selectallfrivillige);

            return frivillige.ToList();
        }



    }
}
