﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace practask29th
{
    public class SqlHelper
    {
        private const string _connectionString = @"Server=DESKTOP-R4EGFJU\SQLEXPRESS;Database = alinino;Trusted_Connection=true";
        public static async Task<DataTable> GetDatas(string query)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            DataTable dt = new DataTable();
            using SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.Fill(dt);
            await connection.CloseAsync();
            return dt;
        }
        public static async Task<int> Exec(string query)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            using SqlCommand command = new SqlCommand(query, connection);
            int result = await command.ExecuteNonQueryAsync();
            await connection.CloseAsync();
            return result;
        }
    }
}
