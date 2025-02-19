# CAT3IDWMbackend
## Instalación

Antes ejecutar el proyecto debes asegurarte de tener instalado el SDK de .Net 8

## Inicio

1. Clona el repositorio en tu dispositivo

```
git clone https://github.com/Inncubux/CAT3IDWMbackend.git

```

2. Restauración de las dependencias del proyecto:

```
dotnet restore
```

3. Verificar que la base de datos este funcionando correctamente, ejecuta el siguiente comando en la terminal de visual studio

```
 dotnet ef database update
```

Si el terminal retorna un error debes ejecutar los siguiente comandos:

```
 dotnet ef database drop
 dotnet ef migrations remove
 dotnet ef migrations add firstMigration -o .\src\Data\Migrations\
```

finalmente para que el proyecto se ejecute debes ingresar el siguiente comando
```
 dotnet run
```

El backen se ejecutara en la siguiente dirección http://localhost:5036
## Variables de entorno

Para la ejecución correcta del programa debes modificar los archivos que se encuentran dentro del proyecto correspondientes a **appsetting.json** y crear un archivo con el siguiente nombre **.env**, posteriormente los archivos deben tener la siguiente estructura


**Para appsetting.json**

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=database.db"
  },
  "Jwt": {
    "Issuer": "url donde se ejecuta el servicio",
    "Audience": "url donde se ejecuta el servicio",
    "signingKey": "key privada",
    "ExpiresInMinutes": 15
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Cloudinary": {
    "CloudName": "nombre de la nube ",
    "ApiKey": "tu api key",
    "ApiSecret": "tu api secret"
  }
}
```

Para **.env** 

```
DATABASE_URL=Data Source=database.db
```


