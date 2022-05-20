using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Milijøfestival.Shared
{

    public class HentVagtData : IHentVagtData
    {


       
        //Henter en liste af vagter (SELECT / Read)
        public async Task<IEnumerable<Vagt>> VagtList()
        {
            var selectstedvagter = "SELECT * FROM vagt";
            IEnumerable<Vagt> vagter;
            using (var connection = new NpgsqlConnection("SuperUser"))
            {
                vagter = await connection.QueryAsync<Vagt>(selectstedvagter);
            }
            return vagter.ToList();
        }

    }
}
