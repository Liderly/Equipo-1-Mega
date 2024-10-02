# HackathonMegaEquipo1-Backend webapi ASP.NET Core 8

## Clona el proyecto
git clone https://github.com/MoisesReyesOrea/HackathonMegaEquipo1-Backend.git  

y abrir en VS Code.  

## Ejecuta en terminal los comandos  

Descarga paquetes de NuGet  
``dotnet restore``

Compila el proyecto para generar los archivos necesarios  
``dotnet build``

Ejecuta el proyecto  
``dotnet run``

## Abrir en navegador la dirección  
http://localhost:{PuertoLocal}/swagger  
Ejemplo: http://localhost:5295/swagger  


## APIs para consultar desde frontend si el servidor backend está corriendo de manera local  

### API para obtener todas las cuadrillas con sus puntos y bonos  
http://localhost:{PuertoLocal}/api/puntosallcuadrillas  
Ejemplo: http://localhost:5295/api/puntosallcuadrillas  

### API para obtener datos de una cuadrilla en especifico mediante su número de cuadrilla  
http://localhost:{PuertoLocal}/api/puntoscuadrilla/#Cuadrilla  
Ejemplo: http://localhost:5295/api/puntoscuadrilla/1  

### API para obtener datos de un técnico instalador en especifico mediante su número de empleado  
http://localhost:{PuertoLocal}/api/puntostecnico/#Tecnico  
Ejemplo: http://localhost:5295/api/puntostecnico/719477  

