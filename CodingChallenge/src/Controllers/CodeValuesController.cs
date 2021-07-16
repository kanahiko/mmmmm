using CodingChallenge.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text;
using CodingChallenge.Models;
using System;

namespace CodingChallenge.Controllers
{
    [Route("api/codevalues")]
    [ApiController]
    public class CodeValuesController : ControllerBase
    {
        private readonly IRepository _repository;
        public CodeValuesController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all entries
        /// </summary>
        /// <returns>All entries</returns>
        [HttpGet(Name = "GetAll")]
        public ActionResult GetAll()
        {
            return Ok(_repository.GetAll() );
        }

        /// <summary>
        /// Filtered GET.
        /// Only gets entries with specified code
        /// </summary>
        /// <param name="code">specified code</param>
        /// <returns>All entries with specified code</returns>
        [HttpGet("{code}")]
        public ActionResult Get(int code)
        {
            return Ok(  _repository.Get(code));
        }

        /// <summary>
        /// Deserializes JSON and adds them to database.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostAsync()
        {
            List<CodeValue> codeValuesList;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var value = await reader.ReadToEndAsync(); 
                var deserializeOptions = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                    {
                        new JSONMyConverter()
                    }
                };
                try
                {
                    codeValuesList = JsonSerializer.Deserialize<List<CodeValue>>(value, deserializeOptions);
                }catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            _repository.Add(codeValuesList.OrderBy(a => a.Code));
            return CreatedAtAction(nameof(GetAll), "Данные загруженны.");
        }
    }
}
