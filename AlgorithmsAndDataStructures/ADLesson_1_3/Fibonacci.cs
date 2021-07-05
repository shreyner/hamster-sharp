namespace ADLesson_1_3
{
    public class Fibonacci
    {
        public static int Recursion(int num)
        {
            if (num is 0 or 1)
            {
                return num;
            }

            return Recursion(num - 1) + Recursion(num - 2);
        }
    }
}