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


        private readonly SqlConnectionConfiguration _configuration;
        public HentVagtData(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Henter en liste af vagter (Select / Read)
        public async Task<IEnumerable<Vagt>> VagtList()
        {
            var selectstedvagter = "Select sted FROM vagt";
            IEnumerable<Vagt> vagter;
            using (var connection = new NpgsqlConnection("SuperUser"))
            {
                vagter = await connection.QueryAsync<Vagt>(selectstedvagter);
                /*
            ("spVagt_GetAll", commandType: CommandType.StoredProcedure);
                */
            }
            return vagter.ToList();
        }

    }
}
