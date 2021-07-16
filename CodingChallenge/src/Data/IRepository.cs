using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Data
{
    public interface IRepository
    {
        IEnumerable<CodeValue> GetAll();
        IEnumerable<CodeValue> Get(int code);

        void Add(IEnumerable<CodeValue> entities);
    }
}
