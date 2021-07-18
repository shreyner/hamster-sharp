using System;
using System.Collections;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ADLesson_3_1
{
    public struct PointClassFloat
    {
        public float X;
        public float Y;
    }

    public struct PointStructFloat
    {
        public float X;
        public float Y;
    }

    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }

    public class CalculateDistance
    {
        public static float PointDistanceClassFloat(PointClassFloat pointOne, PointClassFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceStructFloat(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceStructFloatWithOutSqrt(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
    }

    public class BenchmarkPointDistance
    {
        public Random random = new Random();

        public object[][] NumbersPointClassFloats() =>
            Enumerable.Range(0, 2).Select(i => new object[]
            {
                new PointClassFloat
                    {X = (float) random.NextDouble(), Y = (float) random.NextDouble()},
                new PointClassFloat
                    {X = (float) random.NextDouble(), Y = (float) random.NextDouble()}
            }).ToArray();

        [Benchmark]
        [ArgumentsSource(nameof(NumbersPointClassFloats))]
        public float pointDistanceStructFloat(PointClassFloat pointOne, PointClassFloat pointTwo) =>
            CalculateDistance.PointDistanceClassFloat(pointOne, pointTwo);

        public object[][] NumbersPointStructFloat() =>
            Enumerable.Range(0, 2).Select(i => new object[]
            {
                new PointStructFloat
                    {X = (float) random.NextDouble(), Y = (float) random.NextDouble()},
                new PointStructFloat
                    {X = (float) random.NextDouble(), Y = (float) random.NextDouble()}
            }).ToArray();

        [Benchmark]
        [ArgumentsSource(nameof(NumbersPointStructFloat))]
        public float pointDistanceStructFloat(PointStructFloat pointOne, PointStructFloat pointTwo) =>
            CalculateDistance.PointDistanceStructFloat(pointOne, pointTwo);


        public object[][] NumbersPointStructDouble() =>
            Enumerable.Range(0, 2).Select(i => new object[]
            {
                new PointStructDouble()
                    {X = random.NextDouble(), Y = random.NextDouble()},
                new PointStructDouble()
                    {X = random.NextDouble(), Y = random.NextDouble()}
            }).ToArray();

        [Benchmark]
        [ArgumentsSource(nameof(NumbersPointStructDouble))]
        public double pointDistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo) =>
            CalculateDistance.PointDistanceStructDouble(pointOne, pointTwo);

        public object[][] NumbersPointStructFloatWithOutSqrt() =>
            Enumerable.Range(0, 2).Select(i => new object[]
            {
                new PointStructFloat()
                    {X = (float) random.NextDouble(), Y = (float) random.NextDouble()},
                new PointStructFloat()
                    {X = (float) random.NextDouble(), Y = (float) random.NextDouble()}
            }).ToArray();

        [Benchmark]
        [ArgumentsSource(nameof(NumbersPointStructFloatWithOutSqrt))]
        public float pointDistanceStructFloatWithOutSqrt(PointStructFloat pointOne, PointStructFloat pointTwo) =>
            CalculateDistance.PointDistanceStructFloatWithOutSqrt(pointOne, pointTwo);
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(BenchmarkPointDistance));
        }
    }
}