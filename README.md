# WeatherApi

This project provides an API to retrieve and store weather data for Moscow.

## Description

WeatherApi is designed to fetch and store information about the temperature in Moscow on a specific date. The project offers two REST endpoints:

### Endpoints

1. **MoskowWeather**
   - **Method**: GET
   - **Path**: `/api/moskowweather`
   - **Request Parameter**: `date` (format: YYYY-MM-DD)
   - **Description**: This request returns the temperature in Moscow for the specified date.

2. **SaveMoskowWeather**
   - **Method**: POST
   - **Path**: `/api/savemoskowweather`
   - **Request Parameter**: `date` (format: YYYY-MM-DD)
   - **Description**: This request saves the temperature value in Moscow for the specified date into a relational database and returns the saved value.

### Requirements

- Developed using .NET7.
- Utilizes Swagger for API interface.
- Authentication is done through BASIC authorization.
- JSON format is used for data exchange.
- Relies on an external service as the data source for weather information.
- Application runs within a Docker container.

## Running the Project

1. Install Docker on your machine.
2. Clone the repository: `git clone https://github.com/danpaf/WeatherApi.git`
3. Navigate to the project directory: `cd WeatherApi`
4. Build the Docker container: `docker build -t weatherapi .`
5. Run the container: `docker run -p 8080:80 weatherapi`

The API will be accessible at: `http://localhost:8080/swagger/index.html`.

## Database

postgres

## Author

This project is created and maintained by DanPaf. 
