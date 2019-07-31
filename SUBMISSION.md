Flights Solution
The solution contains 3 projects:

•	Flights.API

•	Flights.BLL

•	Flights.DAL

Flights.DAL

DAL is the Data access layer of the solution. It is using the entity framework DB first to connect to the DB. The DB is sql server.

Flights.BLL

BLL is the business logic of the project. The main logic is written in the FindRoute.cs which is basically creates a graph of all the nodes in the route table and keep track of the visited nodes and uses a recursive method to return the shortest path between the origin and destination node.
RoutingBLL gets the routes from the DB and returns the shortest path between the given params.

Flights.API

API is the WCF REST service application which gets the shortest method from the given params by calling the BLL.

Running Instructions:
1.	Create a Database in SQL server called Flights and restore the Flights.bak which is located in FlightsDB folder
2.	Open the Flights.sln located in Flights in the visual studio 2017 or greater
3.	Update FlightsEntities connection strings in the solution with your sql sever name, userId and password
4.	Build the entire solution
5.	Right click on the Flights.API project and start a new instance
6.	Call http://localhost:56312/FlightsREST.svc/GetRoute/?Origin=YYZ&Destination=YVR either from the browser or Postman 
