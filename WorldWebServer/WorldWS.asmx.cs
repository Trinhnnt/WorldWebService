using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System;

namespace WorldWebServer
{
    /// <summary>
    /// Summary description for WorldWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WorldWS : System.Web.Services.WebService
    {
        private SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WorldDatabase"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        public class Country
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Continent { get; set; }
            public string Region { get; set; }
            public decimal SurfaceArea { get; set; }
            public int Population { get; set; }
            public double LifeExpectancy { get; set; }
            public string GovernmentForm { get; set; }
        }
        public class City
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string CountryCode { get; set; }
            public string District { get; set; }
            public int Population { get; set; }
        }

        [WebMethod]
        public List<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();
            string connectionString = ConfigurationManager.ConnectionStrings["WorldDatabase"].ConnectionString;

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT Code, Name, Continent, Region, SurfaceArea, Population, LifeExpectancy, GovernmentForm FROM Country";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    countries.Add(new Country
                    {
                        Code = reader["Code"].ToString(),
                        Name = reader["Name"].ToString(),
                        Continent = reader["Continent"].ToString(),
                        Region = reader["Region"].ToString(),
                        SurfaceArea = Convert.ToDecimal(reader["SurfaceArea"]),
                        Population = Convert.ToInt32(reader["Population"]),
                        LifeExpectancy = reader["LifeExpectancy"] != DBNull.Value ? Convert.ToDouble(reader["LifeExpectancy"]) : 0,
                        GovernmentForm = reader["GovernmentForm"].ToString()
                    });
                }
            }

            return countries;
        }
        [WebMethod]
        public Country GetCountryByCode(string countryCode)
        {
            Country country = null;
            string connectionString = ConfigurationManager.ConnectionStrings["WorldDatabase"].ConnectionString;

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT Code, Name, Continent, Region, SurfaceArea, Population, LifeExpectancy, GovernmentForm FROM Country WHERE Code = @Code";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Code", countryCode);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    country = new Country
                    {
                        Code = reader["Code"].ToString(),
                        Name = reader["Name"].ToString(),
                        Continent = reader["Continent"].ToString(),
                        Region = reader["Region"].ToString(),
                        SurfaceArea = Convert.ToDecimal(reader["SurfaceArea"]),
                        Population = Convert.ToInt32(reader["Population"]),
                        LifeExpectancy = reader["LifeExpectancy"] != DBNull.Value ? Convert.ToDouble(reader["LifeExpectancy"]) : 0,
                        GovernmentForm = reader["GovernmentForm"].ToString()
                    };
                }
            }

            return country;
        }

        [WebMethod]
        public City GetCityByName(string cityName)
        {
            City city = null;
            string connectionString = ConfigurationManager.ConnectionStrings["WorldDatabase"].ConnectionString;

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ID, Name, CountryCode, District, Population FROM City WHERE Name = @Name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", cityName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    city = new City
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        CountryCode = reader["CountryCode"].ToString(),
                        District = reader["District"].ToString(),
                        Population = Convert.ToInt32(reader["Population"])
                    };
                }
            }

            return city;
        }

        [WebMethod]
        public List<City> GetCitiesByCountry(string countryCode)
        {
            List<City> cities = new List<City>();
            string connectionString = ConfigurationManager.ConnectionStrings["WorldDatabase"].ConnectionString;

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ID, Name, District, Population FROM City WHERE CountryCode = @CountryCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CountryCode", countryCode);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cities.Add(new City
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        District = reader["District"].ToString(),
                        Population = Convert.ToInt32(reader["Population"])
                    });
                }
            }

            return cities;
        }

        [WebMethod]
        public List<Country> GetCountriesByContinent(string continent)
        {
            List<Country> countries = new List<Country>();
            string connectionString = ConfigurationManager.ConnectionStrings["WorldDatabase"].ConnectionString;

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT Code, Name, Region, SurfaceArea, Population, GovernmentForm FROM Country WHERE Continent = @Continent";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Continent", continent);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    countries.Add(new Country
                    {
                        Code = reader["Code"].ToString(),
                        Name = reader["Name"].ToString(),
                        Region = reader["Region"].ToString(),
                        SurfaceArea = Convert.ToDecimal(reader["SurfaceArea"]),
                        Population = Convert.ToInt32(reader["Population"]),
                        GovernmentForm = reader["GovernmentForm"].ToString()
                    });
                }
            }

            return countries;
        }
    }
}
