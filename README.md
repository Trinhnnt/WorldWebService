1. Yêu cầu đề bài:
- Give the world database script as attachment, import it to database then create an application for discovering the database.
- On server side: create SOAP services to expose the data as the following description.
+ Get all countries from database.
+ Get country by country code.
+ Get city by name.
+ Get all cities of a specific country.
+ Get all contries of a continent.
Client side: Create a windows form application for invoking the server side services.
2. Hướng dẫn chạy chương trình
+ Bước 1: Kết nối database ![image](https://github.com/user-attachments/assets/490e8754-8a13-4d9a-a6f8-7ff5b7d265e9)
  - Sử dụng connectionString.
+ Bước 2: Triển khai Server Side trong Web Service (Web Service (ASMX)).
  - Tạo class định nghĩa city và country.
  - Thêm các phương thức:
    + GetAllCountries(): Lấy toàn bộ các quốc gia trong database.
    + GetCountryByCode(string countryCode): Lấy quốc gia thông qua mã quốc gia.
    + GetCityByName(string cityName): Lấy thành phố dựa theo tên.
    + GetCitiesByCountry(string countryCode): Lấy toàn bộ thành phố trong một quốc gia dựa vào mã quốc gia.
    + GetCountriesByContinent(string continent): Lấy toàn bộ quốc gia trong một châu lục dựa vào tên châu lục.
+ Bước 3: Chạy webservice ![image](https://github.com/user-attachments/assets/791632e0-d9b4-487f-8c22-08799ea8b044)
+ Bước 4: Triển khai Client Side.
  - Tạo winform. Thiết kế UI ![image](https://github.com/user-attachments/assets/03b38c47-abcf-423e-a8d7-077e391ba8b3)
+ Bước 5: Kết nối web serivce bằng cách add Service reference ![image](https://github.com/user-attachments/assets/dfc75215-42cc-456e-8ef8-67f83c98e210)
  - Thêm mã sử lý các sự kiện cho các button.
3. Kết quả truy vấn.
+ Get all countries from database.![image](https://github.com/user-attachments/assets/c1c4ec33-a14c-4ac8-9d3b-06e008fade24)
+ Get country by country code.![image](https://github.com/user-attachments/assets/43ad6a1f-ac51-477b-aa97-ab8ffc8f7fbd)
+ Get city by name.![image](https://github.com/user-attachments/assets/c872df15-0ba4-4e31-8e01-888c3b84f341)
+ Get all cities of a specific country.![image](https://github.com/user-attachments/assets/83cbfbf0-db61-4293-9314-90fe88811371)
+ Get all contries of a continent.![image](https://github.com/user-attachments/assets/5fde48dd-395a-4d49-866b-43b525c7e0df)
