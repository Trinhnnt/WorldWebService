using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using WorldClient.WorldWS;

namespace WorldClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Button "GetAllCities"
        {
            try
            {
                // Tạo client để gọi Web Service
                WorldWSSoapClient client = new WorldWSSoapClient();

                // Gọi phương thức GetAllCountries
                var countries = client.GetAllCountries();

                // Hiển thị toàn bộ thông tin trong DataGridView
                dataGridView1.DataSource = countries.Select(country => new
                {
                    country.Code,
                    country.Name,
                    country.Continent,
                    country.Population,
                    
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Error");
            }
        }


        private void button2_Click(object sender, EventArgs e) // Button "GetCountryByCode"
        {
            try
            {
                // Tạo client để gọi Web Service
                WorldWSSoapClient client = new WorldWSSoapClient();

                // Lấy mã quốc gia từ TextBox
                string countryCode = textBox1.Text.Trim();

                // Gọi phương thức GetCountryByCode
                var country = client.GetCountryByCode(countryCode);

                // Hiển thị thông tin quốc gia trong DataGridView
                if (country != null)
                {
                    dataGridView1.DataSource = new List<object>
            {
                new
                {
                    country.Code,
                    country.Name,
                    Continent = country.Continent,
                    country.Population,
                    country.SurfaceArea,
                    country.LifeExpectancy
                }
            };
                }
                else
                {
                    MessageBox.Show("Không tìm thấy quốc gia với mã đã nhập!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Error");
            }
        }
        private void button3_Click(object sender, EventArgs e) // Button "GetCityByName"
        {
            try
            {
                // Tạo client để gọi Web Service
                WorldWSSoapClient client = new WorldWSSoapClient();

                // Lấy tên thành phố từ TextBox
                string cityName = textBox2.Text.Trim();

                // Gọi phương thức GetCityByName
                var city = client.GetCityByName(cityName);

                // Hiển thị thông tin thành phố trong DataGridView
                if (city != null)
                {
                    dataGridView1.DataSource = new List<object>
                    {
                        new
                        {
                        city.Name,
                        city.CountryCode,
                        city.District,
                        city.Population
                        }
                    };
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thành phố với tên đã nhập!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Error");
            }
        }




        private void button4_Click(object sender, EventArgs e) // Button "GetAllCitiesByCountry"
        {
            try
            {
                // Tạo client để gọi Web Service
                WorldWSSoapClient client = new WorldWSSoapClient();

                // Lấy mã quốc gia từ TextBox
                string countryCode = textBox1.Text.Trim();

                // Gọi phương thức GetAllCitiesByCountry
                var cities = client.GetCitiesByCountry(countryCode);

                // Hiển thị toàn bộ thông tin thành phố trong DataGridView
                if (cities != null && cities.Length > 0)
                {
                    dataGridView1.DataSource = cities.Select(city => new
                    {
                        Name = city.Name,
                        CountryCode = city.CountryCode,
                        District = city.District,
                        Population = city.Population
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Không có thành phố nào cho mã quốc gia này!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Error");
            }
        }

        private void button5_Click(object sender, EventArgs e) // Button "GetCountriesByContinent"
        {
            try
            {
                // Tạo client để gọi Web Service
                WorldWSSoapClient client = new WorldWSSoapClient();

                // Lấy tên châu lục từ TextBox
                string continent = textBox3.Text.Trim();

                // Gọi phương thức GetCountriesByContinent
                var countries = client.GetCountriesByContinent(continent);

                // Hiển thị toàn bộ thông tin quốc gia trong DataGridView
                if (countries != null && countries.Length > 0)
                {
                    dataGridView1.DataSource = countries.Select(country => new
                    {
                        country.Code,
                        country.Name,
                        country.Continent,
                        country.Population,
                        country.SurfaceArea,
                        country.LifeExpectancy
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy quốc gia nào cho châu lục này!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Error");
            }
        }

    }
}





