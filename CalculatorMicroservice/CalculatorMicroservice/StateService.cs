using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace CalculatorMicroservice
{
    public class StateService
    {
        public bool SetState(string userEmail, OperationType operationType, NumberType numberType)
        {
            var state = new StateDto() { OperationType = operationType, NumberType = numberType };
            var stateJson = JsonConvert.SerializeObject(state);
            return WriteToFile(userEmail, stateJson);
        }

        public StateDto GetState(string userEmail)
        {
            var result = ReadFromFile(userEmail);
            if (result != null)
            {
                return JsonConvert.DeserializeObject<StateDto>(result);
            } else
            {
                return null;
            }
        }

        public void DeleteState(string userEmail)
        {
            string fileName = @$"C:\CalculatorStates\{userEmail}_state.txt";
            DeleteFile(fileName);
        }

        private bool WriteToFile(string email, string stateJson)
        {
            string fileName = @$"C:\CalculatorStates\{email}_state.txt";

            try
            {
                DeleteFile(fileName);

                using (FileStream fs = File.Create(fileName))
                {
                    byte[] stateByte = new UTF8Encoding(true).GetBytes(stateJson);
                    fs.Write(stateByte, 0, stateByte.Length);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string ReadFromFile(string userEmail)
        {
            try
            {
                var fileName = @$"C:\CalculatorStates\{userEmail}_state.txt";
                var result = new StringBuilder();
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        result.Append(s);
                    }
                }
                return result.ToString();
            } catch (Exception)
            {
                return null;
            }
        }

        private void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

    }
}
