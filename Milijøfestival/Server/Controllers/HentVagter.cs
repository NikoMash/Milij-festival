using Dapper;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

    }
}
