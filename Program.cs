using System;

namespace AbilityScoreTester
{
    internal class AbilityScoreCalculator
    {
        public int RollResult = 14;
        public double DivideBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;

        public void CalculateAbilityScore()
        {
            // Результат броска делится на значение поля DivideBy
            double divided = RollResult / DivideBy;

            // AddAmount прибавляется к результату деления
            int added = AddAmount + (int)divided;

            // Если результат слишком мал, использовать значение Minimum
            if (added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastUsedValue">Значение по умолчанию.</param>
        /// <param name="promt">Сообщение, выводимое на консоль</param>
        /// <returns>Прочитанное значение int или значение по умолчанию, если преобразование невозможно.</returns>
        static int ReadInt(int lastUsedValue, string promt)
        {
            Console.Write(promt + $" [{lastUsedValue}]: ");
            string number = Console.ReadLine();
            if (int.TryParse(number, out int result))
            {
               Console.WriteLine("  using value " + result);
               return result;
            }
            else
            {
                Console.WriteLine("  using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }

        static double ReadDouble(double lastUsedValue, string promt)
        {
            Console.Write(promt + $": [{lastUsedValue}]: ");
            string number = Console.ReadLine();
            if (double.TryParse(number, out double result))
            {
                Console.WriteLine("  using value " + result);
                return result;
            }
            else
            {
                Console.WriteLine("  using default value " + lastUsedValue);
                return lastUsedValue;
            }

        }

        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            while (true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated ability score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }          
        }
    }
}
