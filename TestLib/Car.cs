using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestLib
{
    public partial class Car
    {
        private static readonly string[] validBrands = new string[] { "Volvo", "Saab" };

        partial void OnBrandChanging(string value)
        {
            if (!validBrands.Contains(value))
            {
                throw new ArgumentException("Illegal brand specified");
            }
        }

        /// <summary>
        /// Retires a car, removing it from the database.
        /// </summary>
        public static bool Retire(string registrationNo)
        {
            using (DBContext dbContext = new DBContext())
            {
                Car car = dbContext.Cars.Where(c => c.RegistrationNumber == registrationNo).SingleOrDefault();

                if (car == null)
                    return false;

                dbContext.Cars.DeleteOnSubmit(car);
                dbContext.SubmitChanges();

                return true;
            }
        }

        private static readonly string connectionString = Properties.Settings.Default.testConnectionString;

        public static int CountCars()
        {
            //using(SqlConnection conn = new SqlConnection(connectionString))
            //using(SqlCommand cmd = conn.CreateCommand())
            //{
            //    conn.Open();
            //    cmd.CommandText = "SELECT COUNT(1) FROM Carsd";

            //    return (int)cmd.ExecuteScalar();
            //}
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                {
                    SqlCommand cmd = conn.CreateCommand();
                    try
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT COUNT(1) FROM Carsd";

                        return (int)cmd.ExecuteScalar();
                    }
                    finally
                    {
                        if (cmd != null)
                            cmd.Dispose();
                    }
                }
            }

        }

    }
}
