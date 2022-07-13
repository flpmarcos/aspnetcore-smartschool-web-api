
# AspNetCoreWebAPI

## Docker
### Compose
`docker compose up -d`

### Docker Hub - flpmarcos

https://hub.docker.com/r/flpmarcos/smartschoolwebapi_smartschool

### Manual
Build
`docker build -t smartshool .`

Run
`docker run -d -p 5000:80 --name smartshool smartshool`

## Mysql

### Manual
Criar Volume
`docker volume create smartschooldb`

Run
`docker container run -d --name mysql -p 3306:3306 -v smartschooldb:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=lalaland -e bind-address:0.0.0.0 -e MYSQL_PASSWORD=lalaland -e MYSQL_ROOT_HOST=% mysql:5.7`

## Dotnet Runtime mode
`dotnet watch run`


## Migration
### Mysql


Init

`dotnet ef migrations script`

Add

`dotnet ef migrations add initMySql`

Update

`dotnet ef database update`

### Path = Exibir > Outras Janelas > Console do gerenciador de pacotes
```
# VS 2022
# Cria migration
add-Mgration init

# Update migration
Update-Database
```