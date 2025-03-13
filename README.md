# Simple CRUD API
Hola, una disculpa por la tardanza pero necesitaba documentarme a través de los datos oficiales y recrear la función de un CRUD de PHP  a C#. ¡Espero que puedan ejecutarlo sin problemas! 

## Introducción
Este proyecto es una API REST desarrollada en **ASP.NET Core** utilizando **Minimal APIs**. La API permite realizar operaciones CRUD (
Crear, Leer, Actualizar y Eliminar) sobre una base de datos MySQL.

Está diseñada para manejar información de usuarios, incluyendo sus datos de contacto y datos adicionales relacionados.

## Requisitos para ejecutar el proyecto

### Prerrequisitos

Antes de ejecutar el proyecto, se debe tener instalado lo siguiente:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)

### Configuración de la Base de Datos

1. Crea una base de datos en MySQL con la estructura requerida para `USERS`, `CONTACT_DATA` y `ADDITIONAL_DATA`.
2. Configura la cadena de conexión en el archivo **appsettings.json**:
   
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=your_db_name;user=your_user;password=your_password"
     }
   }
   ```

### Instalación y Ejecución

1. Clona el repositorio:
   ```sh
   git clone https://github.com/AlbertoCancela/simple-crud-csharp
   ```
2. Accede al directorio del proyecto:
   ```sh
   cd simple-crud
   ```
3. Restaura los paquetes y compila el proyecto:
   ```sh
   dotnet restore
   dotnet build
   ```
4. Ejecuta la API:
   ```sh
   dotnet run
   ```
5. La API estará disponible en `http://localhost:5054/api/users`.

## Endpoints de la API

### 1. Obtener todos los usuarios
- **Método:** `GET`
- **URL:** `/api/users`

#### cURL
```sh
curl -X GET "http://localhost:5054/api/users"
```

#### Postman
- Método: `GET`
- URL: `http://localhost:5054/api/users`

---

### 2. Obtener un usuario por ID
- **Método:** `GET`
- **URL:** `/api/users/{id}`

#### cURL
```sh
curl -X GET "http://localhost:5054/api/users/1"
```

#### Postman
- Método: `GET`
- URL: `http://localhost:5054/api/users/1`

---

### 3. Crear un nuevo usuario
- **Método:** `POST`
- **URL:** `/api/users`
- **Cuerpo (JSON):**
  ```json
  {
    "name": "Juan",
    "lastName": "Perez",
    "phoneNumber": "123456789",
    "email": "juan@email.com",
    "data": "Información extra"
  }
  ```

#### cURL
```sh
curl -X POST "http://localhost:5054/api/users" \
     -H "Content-Type: application/json" \
     -d '{"name": "Juan", "lastName": "Perez", "phoneNumber": "123456789", "email": "juan@email.com", "data": "Información extra"}'
```

#### Postman
- Método: `POST`
- URL: `http://localhost:5054/api/users`
- Body: JSON (como se muestra arriba)

---

### 4. Actualizar un usuario
- **Método:** `PUT`
- **URL:** `/api/users/{id}`
- **Cuerpo (JSON):**
  ```json
  {
    "name": "Nuevo Nombre",
    "lastName": "Nuevo Apellido",
    "phoneNumber": "987654321",
    "email": "nuevo@email.com",
    "data": "Nuevo dato"
  }
  ```

#### cURL
```sh
curl -X PUT "http://localhost:5054/api/users/1" \
     -H "Content-Type: application/json" \
     -d '{"name": "Nuevo Nombre", "lastName": "Nuevo Apellido", "phoneNumber": "987654321", "email": "nuevo@email.com", "data": "Nuevo dato"}'
```

#### Postman
- Método: `PUT`
- URL: `http://localhost:5054/api/users/1`
- Body: JSON (como se muestra arriba)

---

### 5. Eliminar un usuario
- **Método:** `DELETE`
- **URL:** `/api/users/{id}`

#### cURL
```sh
curl -X DELETE "http://localhost:5054/api/users/1"
```

#### Postman
- Método: `DELETE`
- URL: `http://localhost:5054/api/users/1`

## Tecnologías utilizadas

- **ASP.NET Core** - Framework backend
- **Entity Framework Core** - ORM para interactuar con MySQL
- **MySQL** - Base de datos relacional
- **cURL / Postman** - Para probar la API

## Notas adicionales
- La API implementa `ReferenceHandler.Preserve` para evitar problemas de serialización cíclica en JSON.
- Se aplica `Cascade Delete` para eliminar registros dependientes automáticamente.
- La API sigue una estructura de Minimal APIs en .NET 8 para simplificar la configuración.

---

### Autor
Alberto Josué Cancela Arredondo

