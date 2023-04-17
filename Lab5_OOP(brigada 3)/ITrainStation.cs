using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_OOP_brigada_3_
{
    public interface ITrainStation
    {
        ITrainStation Clone();
        string? GetFieldString(string field);
        int GetFieldInt(string field);
        bool GetFieldBool(string field);
    }
}
