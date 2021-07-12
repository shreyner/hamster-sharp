namespace ADLesson_2_2
{
    public class Search
    {
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            var min = 0;
            var max = inputArray.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return -1;
        }
    }
}