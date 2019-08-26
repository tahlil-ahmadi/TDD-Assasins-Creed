using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Persistence.EF
{
    public interface IConnectionManager
    {
        string Get();
        void Override(string connectionString);
    }

    public class ConnectionManager : IConnectionManager
    {
        private string _connectionString = "salam";
        public string Get()
        {
            return _connectionString;
        }

        public void Override(string connectionString)
        {
            this._connectionString = connectionString;
        }
    }
}
