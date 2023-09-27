# TI_flyr

## _Prueba Backend_

**PASOS PARA REVISAR CORRECTAMENTE LA PRUEBA**
1. Clonar este repositorio
2. Crear una base de datos en SQL Server
3. Obtener la cadena de conexión de esta nueva base de datos
4. Esa cadena de conexión debe ser reemplazada en _'appsettings.json'_ como podemos ver a continuación:
   
 ![image](https://github.com/Estefa28/TI_flyr/assets/123497973/b501b8af-c1ec-4e69-aa87-86fab24af993)

5. Realizar actualización de la base de datos en Entity Framework de la siguiente manera: 
* Abrir la consola de administrador de paquetes en Visual Studio
* Seleccionar el proyecto **Newshore.EF** en esta consola
* Correr el siguiente comando: Update-Database
  
  ![image](https://github.com/Estefa28/TI_flyr/assets/123497973/037fac17-c2f9-4408-84d6-38cc51eca705)

6. Correr el proyecto
