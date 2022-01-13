# Horizon App
An application called Horizon, where farmers enter their information, has been developed so that they can track their cows.

* Generic Repository Pattern and Unit Of Work Pattern were applied as architecture in the application. 

* One to one relationship was created between the Animal and Feed Visit models. 

* Serilog was used for log settings and logs were written to Kibana via Elasticsearch running on Docker.

* Entity Framework Core was used with the code first approach. 

* Swagger integrated to system.

* Unit test written with xUnit and Moq

* Filter and Pagination added to list endpoints


#### Used Technology
* Asp.Net Core 3.1
* Sqlite
* Elasticsearch, Kibana (Logging) (Url = http://localhost:5601/ , It need simple configration to monitoring logs on Kibana. https://deep-log-inspection.readthedocs.io/en/latest/user/kibana-logs/)
* Docker
* Swagger
* xUnit
* Moq


#### Setup
* Enter folder path
* Open command
Run:
```sh
docker-compose up -d
```

* To migrate database, we should open Package Manager Console in project and adding first migration with this command but be sure that Default project is Horizon.Data
```sh
add-migration Initial_Migration
```
* After adding migration, if we can see “Migrations” folder in Data layer, that means everything is okay :) Now will update database with this command
```sh
update-database
```

#### Endpoints
![55](https://user-images.githubusercontent.com/47754791/149395769-e8bb94b8-9de9-4005-9478-1c77acf11c9c.PNG)


#### Swagger
localhost:[PORT_NUMBER]/swagger

![image](https://user-images.githubusercontent.com/47754791/149381399-ab4e2844-dd78-48d1-bb41-7ac239b2ac7b.png)

#### Kibana Log Dashboard
 http://localhost:5601/
 
![44](https://user-images.githubusercontent.com/47754791/149395745-06083b1f-5130-421c-af2a-1e7d82974cac.PNG)
