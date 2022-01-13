# Horizon App
Generic Repository Pattern and Unit Of Work Pattern were applied as architecture in the application.
A 1 - 1 relationship was established between the Animal and Feed Visit models.
Serilog was used for log settings and logs were written to Kibana via Elasticsearch running on Docker. Entity Framework Core was used with the code first approach.
Swagger integrated to system.
#### Used Technology
* Asp.Net Core 3.1
* Sqlite
* Elasticsearch, Kibana (Logging) (Url = http://localhost:5601/)
* Docker
* Swagger


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

#### Swagger Url
localhost:[PORT_NUMBER]/swagger

#### Kibana Log Picture
![1](https://user-images.githubusercontent.com/47754791/149210329-f935aae2-8bb9-416e-8725-c10c1aeacae0.PNG)