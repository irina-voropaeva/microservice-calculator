using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace CalculatorMicroservice
{
    public class CalculatorService
    {
        public Tuple<double, double?> Calculate(NumberType type,
            OperationType operation,
            double real1,
            double imaginary1,
            double real2,
            double imaginary2)
        {
            return type switch
            {
                NumberType.Real => new Tuple<double, double?>(DoOperation(real1, real2, operation), null),
                NumberType.Complex => new Tuple<double, double?>(DoOperation(real1, real2, operation),
                    DoOperation(imaginary1, imaginary2, operation)),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public double DoOperation(double number1, double number2, OperationType operation)
        {
            return operation switch
            {
                OperationType.Plus => number1 + number2,
                OperationType.Minus => number1 - number2,
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };
        }
    }
}
