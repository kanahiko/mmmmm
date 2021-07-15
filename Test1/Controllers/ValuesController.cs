using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test1.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        
        public ValuesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetCodeValues")]
        public ActionResult <IEnumerable> GetCodeValues()
        {
            var codes = _db.CodeValue.AsEnumerable().Select((item, ind) =>
                      new { index = (ind + 1), code= item.code, value=item.Value }).ToList();
            return Ok(new { data = codes });
        }

        [HttpGet("{moreThan}")]
        public ActionResult<IEnumerable> GetCodeValues(int moreThan)
        {
            var codes = _db.CodeValue.Where(a => a.code > moreThan).AsEnumerable().Select((item, ind) =>
                      new { index=(ind+1), code = item.code, value = item.Value }).ToList();
            if (codes!= null)
            {
                return NotFound();
            }
            return Ok(new { data = codes });
        }
        //---------

        [HttpPost]
        public ActionResult<IEnumerable> PostCodeValues(IEnumerable<Dictionary<string,string>> json)
        {
            List<CodeValue> codes = DeserializeJSON.DeserializeToCodeValue(json);
            codes = codes.OrderBy(a => a.code).ToList();
            if (codes.Count() > 0)
            {
                _db.CodeValue.RemoveRange(_db.CodeValue);
                _db.CodeValue.AddRange(codes);
                _db.SaveChanges();
            }
            else
            {
                return NoContent();
            }
            return CreatedAtRoute(nameof(GetCodeValues), codes);
        }
    }
}