using System.Collections.Generic;

namespace ADLesson_8_1
{
    public class SortHelpers
    {
        public static List<int> BucketSort(List<int> input)
        {
            var numberOfBuckets = 10;
            var result = new List<int>();
            var buckets = new List<List<int>>();

            foreach (var index in input)
            {
                var bucketChoiceIndex = index / numberOfBuckets;

                buckets[bucketChoiceIndex] ??= new List<int>();

                buckets[bucketChoiceIndex].Add(index);
            }

            foreach (var bucket in buckets)
            {
                result.AddRange(BubbleSort(bucket));
            }


            return result;
        }

        public static List<int> BubbleSort(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if (input[i] < input[j])
                    {
                        int target = input[i];
                        input[i] = input[j];
                        input[j] = target;
                    }
                }
            }

            return input;
        }
    }
}