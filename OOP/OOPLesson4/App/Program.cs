using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var building = new Building(height: 200, floorCount: 100, apartmentCount: 200, entranceCount: 2);

            Console.WriteLine(
                "Building: {0}\nHeight floor: {1},\nApartments of floor: {2},\nApartments of Entrance {3}",
                building,
                building.CalculateHeightOfFloor(),
                building.CalculateApartmentOfFloor(),
                building.CalculateApartmentOfEntrance()
            );
        }
    }
}