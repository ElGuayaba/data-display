# Data Display App
Custom ASP.NET Core API, using DDD architechture, Swagger and other tools.

Just a simple data display web API

# To use it:

-Install Docker on your machine

-Run the following commands:
	
	docker pull elguayaba/data-display:latest

	docker run -p 5000:80 -d --name data-display-container data-display:latest

-Go to your browser and navigate to the following address:
	
	http://localhost:5000/index.html

-Use swagger to interact with the endpoints

# Brief

This API takes a particular set of data in csv file and provides a series of endpoints to enable users to interact with it.
One allows the user to list all the data, the second one allows the user to list all the addresses in the data,
and the last one allows the user to search for the people who live in a certain address from the previous list.

To interact with it from a web browser, we use Swagger. I will show the three endpoints and will allow the user do manually send requests to them. It is important to note that the endpoint version is necessary to make the requests, but for this small implementation it will always be equal to 1.

Should I spend more time developing this example I'd create mechanisms to load the data from the csv into a proper database engine, as well as provide it with a more decent UI and extend its functions.