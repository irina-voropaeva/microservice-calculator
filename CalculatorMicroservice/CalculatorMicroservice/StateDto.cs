using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorMicroservice
{
    public class StateDto
    {
        public OperationType OperationType { get; set; }
        public NumberType NumberType { get; set; }
    }
}
