using System.Text;

namespace App
{
    public class Building
    {
        private static int LastId = 0;
        private int _id = 0;
        private int _height = 0;
        private int _floorCount = 0;
        private int _apartmentCount = 0;
        private int _entranceCount = 0;

        public Building(int height, int floorCount, int apartmentCount, int entranceCount)
        {
            _id = GenerateId();
            _height = height;
            _floorCount = floorCount;
            _apartmentCount = apartmentCount;
            _entranceCount = entranceCount;
        }

        public int Id
        {
            get { return _id; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int FloorCount
        {
            get { return _floorCount; }
            set { _floorCount = value; }
        }

        public int ApartmentCount
        {
            get { return _apartmentCount; }
            set { _apartmentCount = value; }
        }

        public int EntranceCount
        {
            get { return _entranceCount; }
            set { _entranceCount = value; }
        }

        public decimal CalculateHeightOfFloor()
        {
            return (decimal) _height / (decimal) _floorCount;
        }

        public int CalculateApartmentOfEntrance()
        {
            return _apartmentCount / _entranceCount;
        }

        public int CalculateApartmentOfFloor()
        {
            return CalculateApartmentOfEntrance() / _floorCount;
        }

        private static int GenerateId()
        {
            return LastId++;
        }

        public override string ToString()
        {
            return $"Id: {_id}, Height {_height}, Floors: {_floorCount}, Apartments: {_apartmentCount}, Entrances: {_entranceCount}";
        }
    }
}