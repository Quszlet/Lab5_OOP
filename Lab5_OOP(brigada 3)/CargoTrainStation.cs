using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_OOP_brigada_3_
{
    public class CargoTrainStation :ITrainStation
    {
        // Название станции
        public string? StationName { get; set; }

        // Местоположение станции
        public string? Location { get; set; }

        // Код станции
        public int StationCode { get; set; }

        // Количество перегонов
        public int NumberOfSegments { get; set; }

        // Количество путей
        public int NumberOfTracks { get; set; }

        // Вместимость хранилища грузов в тоннах
        public decimal CargoStorageCapacity { get; set; }

        // Наличие кранов для погрузки/выгрузки
        public bool HasCranes { get; set; }

        public CargoTrainStation() { }

        public CargoTrainStation(string stationName)
        {
            this.StationName = stationName;
        }

        public CargoTrainStation(string? stationName, string? location, int stationCode, int numberOfSegments, int numberOfTracks, decimal cargoStorageCapacity, bool hasCranes) : this(stationName)
        {
            StationName = stationName;
            Location = location;
            StationCode = stationCode;
            NumberOfSegments = numberOfSegments;
            NumberOfTracks = numberOfTracks;
            CargoStorageCapacity = cargoStorageCapacity;
            HasCranes = hasCranes;
        }

        public override string ToString()
        {
            return $"Наименование грузовой станции: {StationName}, " +
                $"Местоположение: {Location}, " +
                $"Код станции:  {StationCode}, " +
                $"Количество перегонов:  {NumberOfSegments}, " +
                $"Количество путей:  {NumberOfTracks}, " +
                $"Вместимость хранилища грузов в тоннах:  {CargoStorageCapacity}, " +
                $"Наличие кранов для погрузки/выгрузки:  {(HasCranes ? "Да" : "Нет")}. "
                + "\r\n";
        }

        public ITrainStation Clone()
        {
            return new CargoTrainStation(StationName, Location, StationCode, NumberOfSegments, NumberOfTracks, CargoStorageCapacity, HasCranes);
        }

        /// <summary>
        /// Метод, возвращающий числовые значения полей
        /// </summary>
        /// <param name="fieldName">Название поля</param>
        /// <returns>
        /// Значение поля приведённое в int 
        /// </returns>
        public string? GetFieldString(string field)
        {
            return field switch
            {
                "Название станции" => StationName,
                "Местоположение" => Location,
                _ => "", //default
            };
        }

        public int GetFieldInt(string field)
        {
            return field switch
            {
                "Код станции" => StationCode,
                "Кол-во перегонов" => NumberOfSegments,
                "Кол-во путей" => NumberOfTracks,
                "Вместимость хранилища" => (int)CargoStorageCapacity,
                _ => 0, //default
            };
        }

        public bool GetFieldBool(string field)
        {
            return field switch
            {
                "Краны" => HasCranes,
                _ => false, //default
            };
        }
    }
}
