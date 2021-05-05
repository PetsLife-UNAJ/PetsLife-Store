using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Queries
{
    public interface ICarritoQuery
    {
        public ResponseGetCarritoById GetCarritoById(int id);
    }
}
