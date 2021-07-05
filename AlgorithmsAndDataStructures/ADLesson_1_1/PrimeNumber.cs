namespace ADLesson_1_1
{
    public class PrimeNumber
    {
        public static bool check(int number)
        {
            var d = 0;
            var i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}