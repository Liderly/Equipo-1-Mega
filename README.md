# Hackathon-mega
## Descripción General

Bienvenido. Este repositorio cuenta con un proyecto full stack acerca de una aplicación para llevar el control del calculo de puntos y bonos para técnicos instaladores de Megacable, desarrollado durante el reto de Hackathon de Mega, el stack de tecnologias utilizadas fue Angular v18, ASP.NET Core 8 (webapi), Microsoft SQL Server 2022.  
Este proyecto fue desarrollado por un equipo de 5 personas.  

El proyecto está diseñado para ejecutarse localmente, proporcionando una experiencia completa de desarrollo tanto para el frontend como para el backend.

## Estructura del Repositorio

```plaintext
hackathon-proyecto/
│
├── frontend/                     # Código fuente del frontend (Angular)
│   ├── src/                      # Componentes, servicios, y módulos de Angular
│   ├── README.md                 # Instrucciones específicas del frontend
│
├── backend/                      # Código fuente del backend (API .NET)
│   ├── src/                      # Controladores, modelos y servicios de la API
│   ├── README.md                 # Instrucciones específicas del backend
│
├── docs/                         # Documentación adicional del proyecto
│   ├── frontend-docs/            # Documentación específica del frontend
│   ├── backend-docs/             # Documentación específica del backend
│   └── architecture.md           # Descripción de la arquitectura del proyecto
│
├── .gitignore                    # Archivos y carpetas a ignorar por Git
├── README.md                     # Documentación general del proyecto (este archivo)
```


### Objetivo
El objetivo es .  

## 2. Requerimientos técnicos:
### Para visualizar el contenido del codigo es necesario tener instalado:  
GIT: Debe tener Instalado GIT.  
SQL Server: En este caso la aplicación se conecta a una base de datos local realizada en SQL Server.  

## 3. ¿Cómo ejecutar la aplicación?

### Clonando el proyecto y ejecutandolo desde Microsoft Visual Basic 6.0 (Desarrollador)
-- Clona el repositorio con el comando:  ```git clone https://github.com/MoisesReyesOrea/HubDeLectura.git```  
-- Desde Microsoft Visual basic 6.0 abre el proyecto en 'Open project'  
-- Este repositorio no contiene el archivo con las variables de entorno de las credenciales de la base de datos SQL Server, para eso debes crear un archivo 'module'  
(ej: ModuleEnvirontmentVariable.bas) dentro del proyecto en la carpeta 'Modules' en ese archivo ingresa las credenciales de tu DB, datos necesarios:

Public Const providerDB As String = "SQLOLEDB"  
Public Const sourceDB As String = "Nombre del servidor de tu base de datos"  
Public Const nameDB As String = "Nombre de tu base de datos"  
Public Const userIdDB As String = "tu usuario"  
Public Const passDB As String = "tu contraseña"  
Public Const connectionData As String = "Provider=" + providerDB + ";Data Source=" + sourceDB + ";Initial Catalog=" + nameDB + ";User ID=" + userIdDB + ";Password=" + passDB + ";"  

-- Corre la aplicacion   

## 4. Explicación

**NOTA: Los archivos de la BD estan en este mismo repositorio en la carpeta 'DB_SQL_Server', [DB_SQL_Server](DB_SQL_Server)**  

## 5. Proceso de desarrollo

### Detalles



# Contribuyentes al proyecto

| [<img src="https://avatars.githubusercontent.com/u/116055107?v=4" width=115><br><sub>Montserrat Aguilar Valle</sub>](https://github.com/montsegv-2) | [<img src="https://avatars.githubusercontent.com/u/175365956?v=4" width=115><br><sub>Carlos Aldair Ortiz</sub>](https://github.com/AldairOrtiz-Kanako) | [<img src="https://avatars.githubusercontent.com/u/99229911?v=4" width=115><br><sub>K. Efren Reyes</sub>](https://github.com/EfrenReyesD) | [<img src="https://avatars.githubusercontent.com/u/56852285?v=4" width=115><br><sub>Ruben Almazan</sub>](https://github.com/RubenAlmazan) | [<img src="https://avatars.githubusercontent.com/u/159192032?v=4" width=115><br><sub>Moises Reyes</sub>](https://github.com/MoisesReyesOrea) |
| :-------------------------------------------------------------------------------------------------------------------------------------------------: | :----------------------------------------------------------------------------------------------------------------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------: | :------------------------------------------------------------------------------------------------------------------------------------------: |
