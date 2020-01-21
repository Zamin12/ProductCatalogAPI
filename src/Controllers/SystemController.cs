using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using ProductCatalogAPI.Model;

namespace ProductCatalogAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ProductCatalogContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public SystemController(ProductCatalogContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        // Get system info
        // GET: api/System
        [HttpGet]
        public ActionResult<string> GetSystemInfo()
        {
            var info = new
            {
                Version = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion,
                ServerTime = DateTime.Now,
                AspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process),
                Environment.MachineName,
                _environment.EnvironmentName,
                _dbContext.Database.ProviderName
            };

            return JsonConvert.SerializeObject(info, Formatting.Indented);
        }

        // Get status of API
        // GET: api/status
        [HttpGet("status")]
        public ActionResult GetStatus()
        {
            return Ok();
        }

        // Get status of sql server
        // GET: api/sql
        [HttpGet("sql")]
        [ProducesResponseType(503)]
        public ActionResult GetSqlServerStatus()
        {
            try
            {
                return _dbContext.Database.Exists() ? Ok() : StatusCode(503);
            }
            catch
            {
                return StatusCode(503);
            }
        }


    }

    public static class DatabaseFacadeExtensions
    {
        public static bool Exists(this DatabaseFacade source)
        {
            return source.GetService<IRelationalDatabaseCreator>().Exists();
        }
    }
}