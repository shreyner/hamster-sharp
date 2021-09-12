using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsManager.Models;

namespace MetricsManager.Repositories
{
    public class AgentRepository
    {
        public AgentRepository()
        {
        }

        public List<AgentInfo> GetAll()
        {
            using var connection = new SQLiteConnection("Data source=metrics.db");
            connection.Open();

            using var command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Agents";

            var list = new List<AgentInfo>();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new AgentInfo(
                        id: reader.GetInt32(0),
                        agentAddress: new Uri(reader.GetString(1))
                    )
                );
            }

            return list;
        }
    }
}