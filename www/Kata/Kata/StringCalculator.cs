namespace Kata
{
    public class StringCalculator
    {
        public int add(string numbers)
        {
            if (numbers == String.Empty)
            {
                return 0;
            }
            int[] splitted = Array.ConvertAll(numbers.Split(','), int.Parse);
            int sum = 0;
            foreach (int number in splitted)
            {
                if (number > 1000)
                {
                    continue;
                }
                sum += number;
            }
            return sum;
        }
    }
}
