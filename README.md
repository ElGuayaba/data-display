# netcore-template
Custom ASP.NET Core API, DDD template with EF Core, Scrutor, etc.

Simple data display web API

To use it:

-Install Docker on your machine

-Run the following commands:
	
	```docker pull elguayaba/data-display:latest```

	```docker run -p 5000:80 -d --name data-display-container data-display:latest```

-Go to your browser and navigat to the following address:
	
	```http://localhost:5000/index.html```

-Use swagger to interact with the endpoints