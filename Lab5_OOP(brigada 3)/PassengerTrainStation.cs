using System;
using System.Reflection.Metadata.Ecma335;

using Lab5_OOP_brigada_3_;
public class PassengerTrainStation : ITrainStation
{
    public string StationName { get; set; } // Наименование станции
    public int SeatsNumber { get; set; } // Число мест
    public int TicketsSold { get; set; } // Число проданных билетов
    public string Location { get; set; } // Местоположение
    public int TrainsPerDay { get; set; } // Количество поездов в день
    public decimal AverageTicketPrice { get; set; } // Средняя стоимость билета
    public bool HasWiFi { get; set; } // Наличие Wi-Fi на станции

    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public PassengerTrainStation() { }

    /// <summary>
    /// Конструктор с параметром
    /// </summary>
    /// <param name="stationName">Название станции</param>
    public PassengerTrainStation(string stationName)
    {
        this.StationName = stationName;
    }
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="stationName">Название станции</param>
    /// <param name="seatsNumber">Колличество мест</param>
    public PassengerTrainStation(string stationName, int seatsNumber)
    {
        this.StationName = stationName;
        this.SeatsNumber = seatsNumber;
    }
    /// <summary>
    /// Конструктор со всеми параметрами
    /// </summary>
    /// <param name="stationName">Название станции</param>
    /// <param name="seatsNumber">Количество мест</param>
    /// <param name="ticketsSold">Количество проданых билетов</param>
    /// <param name="location">Местоположение</param>
    /// <param name="trainsPerDay">Количество поездов</param>
    /// <param name="averageTicketPrice">Средняя стоимость билета</param>
    /// <param name="hasWiFi">Наличие WiFi</param>
    public PassengerTrainStation(string stationName, int seatsNumber, int ticketsSold, string location, int trainsPerDay, decimal averageTicketPrice, bool hasWiFi)
    {
        this.StationName = stationName;
        this.SeatsNumber = seatsNumber;
        this.TicketsSold = ticketsSold;
        this.Location = location;
        this.TrainsPerDay = trainsPerDay;
        this.AverageTicketPrice = averageTicketPrice;
        this.HasWiFi = hasWiFi;
    }
    /// <summary>
    /// Переопределённый метод .ToString()
    /// </summary>
    /// <returns>
    /// Строку, содержащую все поля класса
    /// </returns>
    public override string ToString()
    {
        return $"Наименование пассажирской станции: {StationName}, " +
            $"Местоположение: {Location}, " +
            $"Количество мест:  {SeatsNumber}, " +
            $"Продано билетов:  {TicketsSold}, " +
            $"Количество поездов в день:  {TrainsPerDay}, " +
            $"Средняя стоимость билета:  {AverageTicketPrice}, " +
            $"Наличие Wi-Fi на станции:  {(HasWiFi ? "Да" : "Нет")}. "
            + "\r\n" ;
    }
   
    

    public ITrainStation Clone()
    {
        return new PassengerTrainStation(StationName, SeatsNumber, TicketsSold, Location, TrainsPerDay, AverageTicketPrice, HasWiFi);
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
            "Число мест" => SeatsNumber,
            "Число проданных билетов" => TicketsSold,
            "Количество поездов в день" => TrainsPerDay,
            "Средняя стоимость билета" => (int)AverageTicketPrice,
            _ => 0, //default
        };
    }

    public bool GetFieldBool(string field)
    {
        return field switch
        {
           "WI-Fi" => HasWiFi,
            _ => false, //default
        };
    }
}