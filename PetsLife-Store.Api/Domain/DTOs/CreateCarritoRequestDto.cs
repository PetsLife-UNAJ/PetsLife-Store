using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CreateCarritoRequestDto
    {
        public int CompradorId { get; set; }
        public List<int> Productos { get; set; }
    }
}
