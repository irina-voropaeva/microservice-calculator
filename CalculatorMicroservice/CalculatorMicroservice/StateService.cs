using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorMicroservice
{
    public class StateService
    {
        public bool SetState(OperationType operationType, NumberType numberType)
        {
            return true;
        }

        public Tuple<OperationType, NumberType> GetState(string userEmail)
        {
            return new Tuple<OperationType, NumberType>(OperationType.Minus, NumberType.Complex);
        }

        public bool DeleteState(string userEmail)
        {
            return true;
        }

    }
}
