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
        
        public async Task<IEnumerable<Vagt>> Get()
        {
            NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");
            connection.Open();

            //Henter en liste af vagter (SELECT / Read)
            var selectallvagter = "SELECT * FROM vagt";
            IEnumerable<Vagt> vagter;
            using (connection)
            
                 vagter = await connection.QueryAsync<Vagt>(selectallvagter);
           
            return vagter.ToList();
        }

        //Opret en vagt (Create)
        public async Task Add(Vagt vagt)
        {
            NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");
            connection.Open();
            string opretvagt = "INSERT INTO vagt (starttid, sluttid, sted, opgid) VALUES (@starttid, @sluttid, @sted, @opgid)";
            var vagtArgumenter = new
            {
                starttid = vagt.StartTid,
                sluttid = vagt.SlutTid,
                sted = vagt.Sted,
                opgid = vagt.OpgId
            };
            await connection.ExecuteAsync(opretvagt, vagtArgumenter); 
        }

    }
}
