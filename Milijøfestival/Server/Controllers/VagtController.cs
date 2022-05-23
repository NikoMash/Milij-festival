using Dapper;
using Microsoft.AspNetCore.Mvc;
using Milijøfestival.Shared;
using Npgsql;
using System.Threading.Tasks;

namespace Milijøfestival.Server.Controllers
{
    public class VagtController : Controller
    {
        NpgsqlConnection connection = new NpgsqlConnection("UserID=postgres; Password = Kulturkongerne2022; Host = milijofestival.postgres.database.azure.com; Port = 5432; Database = milijofestival; ");

        public async Task Add(Vagt nyvagt)
        {

            connection.Open();
            string opretvagt = "INSERT INTO vagt (starttid, sluttid, afdeling, sted, opgid) VALUES (@starttid, @sluttid, @afdeling, @sted, @opgid)";
            var vagtArgumenter = new
            {
                starttid = nyvagt.StartTid,
                sluttid = nyvagt.SlutTid,
                afdeling = nyvagt.Afdeling,
                sted = nyvagt.Sted,
                opgid = nyvagt.OpgId
            };
            await connection.ExecuteAsync(opretvagt, vagtArgumenter);
        }
    }
}
