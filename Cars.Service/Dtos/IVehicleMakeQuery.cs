using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Service.Dtos
{
    public interface IVehicleMakeQuery
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Search { get; set; }
        public string Sort { get; set; }
    }

}
