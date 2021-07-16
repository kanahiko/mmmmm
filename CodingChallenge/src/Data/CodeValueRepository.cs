using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Data
{
    public class CodeValueRepository : IRepository
    {
        private readonly ApplicationDbContext _db;
        public CodeValueRepository(ApplicationDbContext db) => _db = db;
        

        /// <summary>
        /// Clears database and then adds entities to it
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void Add(IEnumerable<CodeValue> entities)
        {
            _db.CodeValues.RemoveRange(_db.CodeValues);
            _db.CodeValues.AddRange(entities);
            _db.SaveChanges();            
        }

        public IEnumerable<CodeValue> GetAll()
        {
            return _db.CodeValues.ToList();
        }

        public IEnumerable<CodeValue> Get(int code)
        {
            return _db.CodeValues.Where(a=>a.Code == code).ToList();
        }


    }
}
