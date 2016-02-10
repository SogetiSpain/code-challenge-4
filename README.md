# code-challenge-4
Sogeti Code Challenge de Febrero 2016
=====================================
Desafío #4: Ordenar lista de empleados
-----------------------------------
Fecha límite: **23 de febrero 2016**

Muchas veces es interesante poder ordenar los resultados de una consulta para encontrar lo que queremos de manera rápida o para hacer comparaciones visuales.

Dado el siguiente conjunto de datos:

First Name | Last Name | Position | Separation date
---------- | --------- | -------- | ---------------
John | Johnson | Manager | 2016-12-31
Tou | Xiong | Software Engineer | 2016-10-05
Jacquelyn | Jackson | DBA |  
Michaela | Michaelson | District Manager | 2015-12-09

crea un programa que ordena todos los empleados por el apellido y escribe el resultado por la consola en un formato tabular:
```
    Name                  | Position          | Separation Date
    -----------------------------------------------------------
    Jacquelyn Jackson     | DBA               | 
    John Johnson          | Manager           | 2016-12-31
    Michaela Michaelson   | District Manager  | 2015-12-09
    Tou Xiong             | Software Engineer | 2016-10-05
```
Restricciones
-------------
*  **Se tienen que implementar los tests unitarios de la funcionalidad con MSTest** (el estándar incluído con Visual Studio)
* Vigilar de que el programa resultante esté debidamente encapsulado en clases y métodos públicos y privados
* El código debe ser compatible con Visual Studio 2013 y NET Framework 4.5.2
* La salida del programa debe devolver el nombre completo del empleado (como se ve en el ejemplo) y formatear correctamente la salida para que se parezca a una tabla

Para nota
---------
* Pedir al usuario el criterio de ordenación (apellido, nombre, posición o fecha de separación) y ordenar el resultado de acuerdo con ello
* Usar el servicio REST disponible en http://codechallenge4.azurewebsites.net/api/employees para obtener los empleados. Para ello podéis usar la siguiente clase para deserializar el resultado JSON:
```
  public class Employee
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public DateTime? SeparationDate { get; set; }
  }
```
¿Cómo subir mi código a GitHub?
===============================
En vez de enviar el código a mi correo, tenéis que hacer lo siguiente:
* Hacer un fork de este repositorio (el de SogetiSpain, no el mío personal)
* Crear una carpeta con vuestro nombre
* Crear vuestra solución en esa carpeta
* Hacer _commit_ en vuestro fork
* Hacer un _pull request_ para que lo incluyamos en el repositorio al final del tiempo del desafío

Tenéis una guía de como hacer un fork y pull request en GitHub [aquí](https://help.github.com/articles/fork-a-repo/)



