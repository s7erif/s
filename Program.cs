using System;
using Npgsql;

class Program
{
    static void Main()
    {
        string connectionString = "Host=db.rinsjmqotzldueufercb.supabase.co;Database=postgres;Username=postgres;Password=YOUR_PASSWORD;SSL Mode=Require;Trust Server Certificate=true";

        try
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            Console.WriteLine("✅ Connected to Supabase Database.\n");

            using var cmd = new NpgsqlCommand("SELECT * FROM donors;", conn);
            using var reader = cmd.ExecuteReader();

            Console.WriteLine("📋 List of Donors:\n");

            while (reader.Read())
            {
                Console.WriteLine($"🩸 Name: {reader["full_name"]}");
                Console.WriteLine($"🎂 DOB: {reader["dob"]}");
                Console.WriteLine($"🚻 Gender: {reader["gender"]}");
                Console.WriteLine($"📍 Governorate: {reader["governorate"]}");
                Console.WriteLine($"🆔 National ID: {reader["national_id"]}");
                Console.WriteLine(new string('-', 40));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error: " + ex.Message);
        }
    }
}
