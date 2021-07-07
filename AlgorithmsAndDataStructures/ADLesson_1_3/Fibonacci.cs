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

        public static int Loop(int num)
        {
            if (num is 0 or 1) return num;

            var fb1 = 1;
            var fb2 = 1;

            for (int i = 2; i < num; i++)
            {
                var sum = fb1 + fb2;

                fb1 = fb2;
                fb2 = sum;
            }

            return fb2;
        }
    }
}