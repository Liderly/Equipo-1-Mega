<a name="readme-top"></a>

<div align="center">

## Calculo de bonos para técnicos instaladores

Este proyecto fue generado con Angular CLI versión 18.2.0

![Badge in progress](https://img.shields.io/badge/STATUS-DONE-green)

</div>

<summary>Tabla de contenido</summary>

- [Descripcion del proyecto](#descripcion-del-proyecto)
- [Objetivo del proyecto](#objetivo-del-proyecto)
- [Tecnologías utilizadas](#tecnologías-utilizadas)
- [Descripción de componentes](#descripción-de-componentes)
- [Instrucciones para descargar y ejecutar](#instrucciones-para-descargar-y-ejecutar)
- [Solución](#solucion)
- [Demostración del producto](#demostracion-del-producto)
- [Conclusión](#conclusion)
- [Contribuyentes al proyecto](#contribuyentes-al-proyecto)

# Descripcion del proyecto

Este sistema está diseñado para generar reportes semanales sobre las órdenes de trabajo completadas por cada cuadrilla, permitiendo consultar la bonificación económica que obtendrán.

En este sistema, el usuario solo tiene que ingresar el número de la cuadrilla y podrá visualizar las órdenes finalizadas en una semana, junto con la lista de colaboradores, el puntaje alcanzado y la bonificación correspondiente. Además, será posible consultar los detalles de cada orden completada.

El proceso de cálculo de bonos para los técnicos instaladores presenta varios desafíos derivados de la complejidad de las órdenes de trabajo y la distribución de tareas dentro de las cuadrillas. Cada orden de trabajo asignada a una cuadrilla incluye una serie de actividades con diferentes niveles de dificultad, los cuales se reflejan en una cantidad de puntos. El reto principal radica en sumar y distribuir estos puntos correctamente entre los técnicos, lo que afecta directamente el cálculo de sus bonos.

Los puntos asignados a cada trabajo varían según la dificultad, y al final de cada semana se suman los puntos totales para generar los pagos correspondientes. Este proceso actualmente se realiza de forma manual, lo que puede resultar en ineficiencias, errores en los cálculos y una pérdida considerable de tiempo.

Además, la distribución de puntos dentro de la cuadrilla no está especificada claramente, lo que puede generar desigualdades en la compensación de los técnicos. El estado de los servicios del cliente también influye en el cálculo, ya que los puntos solo se validan una vez que el trabajo ha sido completado y el servicio se ha cambiado a "instalado". Esto agrega una capa de complejidad al seguimiento de cada orden de trabajo y su impacto en los bonos.

# Objetivo del proyecto

Generar un reporte semanal que incluya información sobre las órdenes completadas por una cuadrilla, así como detalles de los colaboradores que formaron parte de dicha cuadrilla, su puntaje obtenido y la bonificación económica que recibirán por las órdenes finalizadas.

# Tecnologías utilizadas

- Angular 18
- Tailwind CSS
- C#
- SQL Server

# Descripción de componentes

Este sistema está compuesto por cinco componentes fundamentales, los cuales son:

Login

-> En este punto, el usuario podrá ingresar al sistema utilizando sus credenciales

Dashborad principal

-> En este punto, el usuario tendrá acceso a diversas opciones y podrá elegir la consulta de su preferencia.

Reporte general

-> En este punto,el usuario podrá visualizar los reportes semanales de todas las cuadrillas disponibles. Además, podrá consultar el detalle de cada orden de trabajo completada.

Reporte por cuadrilla

-> En este punto, el usuario podrá consultar el reporte semanal de una cuadrilla específica. Tras seleccionar esta opción, se le mostrará una pantalla en la que deberá ingresar el número de cuadrilla. El sistema generará un reporte con todas las órdenes terminadas durante la semana, el personal que formó parte de la cuadrilla y el bono económico obtenido.

Reporte por empleado

-> En este punto, el usuario podrá consultar el historial de bonos de un colaborador específico. Al seleccionar esta opción, se le pedirá ingresar un número de empleado, y el sistema mostrará un reporte con todos los bonos obtenidos por dicho colaborador.

# Instrucciones para descargar y ejecutar

El primer paso, y el más importante, es clonar el repositorio remoto para ejecutarlo localmente.

```
git clone [URL del repositorio]
```

A continuación, el siguiente paso será instalar las dependencias y módulos necesarios para que el proyecto funcione correctamente.

```
npm install o npm i
```

Para ejecutar la funcionalidad principal del programa, deberás ejecutar el siguiente comando en la terminal:

```
ng serve --open
```

# Solucion

Este proyecto busca ofrecer, mediante una interfaz amigable e intuitiva, un medio ágil y sencillo que permita a cualquier colaborador ingresar su número de cuadrilla y consultar los empleados pertenecientes a ella, así como su respectivo puntaje total y la bonificación lograda durante la semana.

# Demostración del producto

<img src="public/image2.png" alt="Karma" whith="5vw">

<img src="public/image3.png" alt="Karma" whith="5vw">

# Contribuyentes al proyecto

| [<img src="https://avatars.githubusercontent.com/u/116055107?v=4" width=115><br><sub>Montserrat Aguilar Valle</sub>](https://github.com/montsegv-2) | [<img src="https://avatars.githubusercontent.com/u/175365956?v=4" width=115><br><sub>Carlos Aldair Ortiz</sub>](https://github.com/AldairOrtiz-Kanako) | [<img src="https://avatars.githubusercontent.com/u/99229911?v=4" width=115><br><sub>K. Efren Reyes</sub>](https://github.com/EfrenReyesD) | [<img src="https://avatars.githubusercontent.com/u/56852285?v=4" width=115><br><sub>Ruben Almazan</sub>](https://github.com/RubenAlmazan) | [<img src="https://avatars.githubusercontent.com/u/159192032?v=4" width=115><br><sub>Moises Reyes</sub>](https://github.com/MoisesReyesOrea) |
| :-------------------------------------------------------------------------------------------------------------------------------------------------: | :----------------------------------------------------------------------------------------------------------------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------: | :------------------------------------------------------------------------------------------------------------------------------------------: |

<p align="right">(<a href="#readme-top">Volver al inicio</a>)</p>
