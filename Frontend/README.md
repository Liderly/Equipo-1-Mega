<a name="readme-top"></a>

<div align="center">

## Calculo de bonos para técnicos instaladores 👨🏻‍🔧🛜

Este proyecto fue generado con Angular CLI versión 18.2.0

![Badge in progress](https://img.shields.io/badge/STATUS-DONE-green)

</div>

<summary>Tabla de contenido</summary>

- [Descripcion del proyecto](#descripcion-del-proyecto)
- [Objetivo del proyecto](#objetivo-del-proyecto)
- [Tecnologías utilizadas](#tecnologías-utilizadas)
- [Descripción de componentes](#descripción-de-componentes)
- [Instrucciones para descargar y ejecutar](#instrucciones-para-descargar-y-ejecutar)
- [Demostración del producto](#demostración-del-producto)
- [Solución](#solución)
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
- JSPDF html2canvas

# Descripción de componentes

> Este sistema está compuesto por cinco componentes fundamentales, los cuales son:

**Login**

En este punto, el usuario podrá ingresar al sistema utilizando sus credenciales

**Pantalla de inicio**

En este punto, el usuario tendrá acceso a diversas opciones y podrá elegir la consulta de su preferencia.

**Reporte general**

En este punto,el usuario podrá visualizar los reportes semanales de todas las cuadrillas disponibles. Además, podrá consultar el detalle de cada orden de trabajo completada.

**Reporte por cuadrilla**

En este punto, el usuario podrá consultar el reporte semanal de una cuadrilla específica. Tras seleccionar esta opción, se le mostrará una pantalla en la que deberá ingresar el número de cuadrilla. El sistema generará un reporte con todas las órdenes terminadas durante la semana, el personal que formó parte de la cuadrilla y el bono económico obtenido.

**Reporte por empleado**

En este punto, el usuario podrá consultar el historial de bonos de un colaborador específico. Al seleccionar esta opción, se le pedirá ingresar un número de empleado, y el sistema mostrará un reporte con todos los bonos obtenidos por dicho colaborador.

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

# Demostración del producto

**Login**, el login cuenta con validaciones lo cual impide el inicio de sesión sino se llena correctamente alguno de los campos.

<img width="1440" alt="LoginValidation" src="https://github.com/user-attachments/assets/4d45debc-5125-4f87-a337-ca1e33ad869f">

Una vez que se llenan correctamente las cajas de texto se habilita el botón de "Iniciar sesión"

<img width="1440" alt="LoginUser" src="https://github.com/user-attachments/assets/a451b16b-1dad-468b-b652-651b1ef2819a">

**Pantalla de inicio**, donde el usuario podrá elegir la consulta que deseé

<img width="1440" alt="home2" src="https://github.com/user-attachments/assets/ff5ff9ea-f455-417d-9e4e-baf4b24824c8">

**Reporte general**, aqui se visualiza el contenido general, enlistando las cuadrillas existentes.

<img width="1440" alt="verCuadrillas" src="https://github.com/user-attachments/assets/c2afce17-1b40-488b-8f3e-1a2aaadcf1e4">

En esta vista se despliega el contenido general por cuadrilla, es decir Lista de empleados y ordenes que pertenecen a esta cuadrilla.

<img width="1440" alt="reporteCuadrilla" src="https://github.com/user-attachments/assets/92276eac-73f1-48aa-9531-5ed3464fb948">

En esta parte de "Ver Detalle" se muestra mas a detalle de la orden que se deseé consultar.

<img width="1440" alt="verDetalleCuadrilla" src="https://github.com/user-attachments/assets/0296be17-916a-436a-b496-dd633bd7796e">

**Reporte por cuadrilla** en este apartado de busqueda con cuadrilla tenemos la vista en la cual podemos escribir el numero de cuadrilla que se desea consultar.

<img width="1440" alt="busquedaCuadrilla" src="https://github.com/user-attachments/assets/32800a70-c2b9-4b91-8a10-b07ee6807361">

Una vez que se da clic en buscar, se arroja la información unicamente de la cuadrilla que se solicitó.

<img width="1440" alt="resultadoCuadrilla" src="https://github.com/user-attachments/assets/37dad8b0-163b-42cd-b8dd-ed0013f51e8b">

Al seleccionar la cuadrilla mostrada, se muestra los detalles de esta cuadrilla al igual como se hace en la sección de /reporte-general, solo que en este apartado se introdujo el botón de **Generar PDF** el cual nos descarga automaticamente en el ordenador el pdf con la vista de los detalles de la cuadrilla.

<img width="1440" alt="DetalleCuadrilla" src="https://github.com/user-attachments/assets/2807bc11-415c-407e-b8d1-5a7179435b7b">

**Reporte por empleado** aqui se muestra un cuadro de busqueda por numero de empleado

<img width="1440" alt="busquedaEmpleado" src="https://github.com/user-attachments/assets/2efa7ed9-8636-435b-ac01-0bcbb6ba27e8">

Después se muestra la información correspondiente al empleado que se desea buscar

<img width="1440" alt="mostrarEmpleado" src="https://github.com/user-attachments/assets/ec900a0a-aa9c-4463-ac86-9d40e79d7ff8">

Al igual que la busqueda por cuadrilla se muestra un botón para descargar el reporte por empleado

<img width="1440" alt="TrabajosEmpleado" src="https://github.com/user-attachments/assets/b64f6b0a-a820-42a8-9311-494595bfc52f">


# Solución

Este proyecto busca ofrecer, mediante una interfaz amigable e intuitiva, un medio ágil y sencillo que permita a cualquier colaborador ingresar su número de cuadrilla y consultar los empleados pertenecientes a ella, así como su respectivo puntaje total y la bonificación lograda durante la semana.

# Contribuyentes al proyecto

| [<img src="https://avatars.githubusercontent.com/u/116055107?v=4" width=115><br><sub>Montserrat Aguilar Valle</sub>](https://github.com/montsegv-2) | [<img src="https://avatars.githubusercontent.com/u/175365956?v=4" width=115><br><sub>Carlos Aldair Ortiz</sub>](https://github.com/AldairOrtiz-Kanako) | [<img src="https://avatars.githubusercontent.com/u/99229911?v=4" width=115><br><sub>K. Efren Reyes</sub>](https://github.com/EfrenReyesD) | [<img src="https://avatars.githubusercontent.com/u/56852285?v=4" width=115><br><sub>Ruben Almazan</sub>](https://github.com/RubenAlmazan) | [<img src="https://avatars.githubusercontent.com/u/159192032?v=4" width=115><br><sub>Moises Reyes</sub>](https://github.com/MoisesReyesOrea) |
| :-------------------------------------------------------------------------------------------------------------------------------------------------: | :----------------------------------------------------------------------------------------------------------------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------: | :------------------------------------------------------------------------------------------------------------------------------------------: |

<p align="right">(<a href="#readme-top">Volver al inicio</a>)</p>
