using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceOrganizer
{
    public class NonDatabaseFunctions
    {
        public string CapitalizeFirstThreeLetters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            int count = 0;
            var result = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) && count < 3)
                {
                    result[i] = char.ToUpper(input[i]);
                    count++;
                }
                else
                {
                    result[i] = input[i];
                }
            }

            return new string(result);
        }
    }
}
