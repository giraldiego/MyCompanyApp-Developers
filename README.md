# myCompanyApp
Proyecto para el curso Desarrollo de Software - Ciclo 3 - Grupo 48

Se requiere una aplicación para almacenar información sobre empresas, sus empleados y sus clientes. Ambos se caracterizan por
nombre y edad.

- Los empleados tienen un sueldo bruto, los empleados que son directivos tienen una categoría, así como un conjunto de
empleados subordinados.
- De los clientes además se necesita conocer su teléfono de contacto
- La aplicación necesita mostrar los datos de empleados y clientes.

## Instrucciones de uso

Para hacer funcionar esta aplicació en su entorno local, seguir los siguientes pasos:

1. Clonar la rama main (estable) o devel (en desarrollo) en su local

2. Instalar globalmente los siguientes paquetes en su instalación .NET:

`dotnet tool install --global dotnet-ef`

`dotnet tool update --global dotnet-ef`

3. En la capa Persistencia (carpeta Persistence) instalar los 4 paquetes siguientes:

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

Nota: Si esta en linux, hay un script llamado `install_ef.sh` en esa carpeta

4. En la capa Aplicacion (carpeta ConsoleApp) instalar el siguiente paquete:

`dotnet add package Microsoft.EntityFrameworkCore.Design`

5. Configure el string de conexión a la base de datos de acuerdo a su entorno en el archivo `Persistence/AppRepos/AppDbContext.cs`

```
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=MyCompanyAppDB;user=SA;password=MinTic2021");
        }
```

Para mi caso, el servidor corre en el localhost con las credenciales del SA mostradas en el string.

Para windows, usualmente será el siguiente string:

`@"Data Source=localhost\sqlexpress;Initial Catalog = MyCompanyAppDB;Integrated Security = True"`

6. Asegures de compilar los proyectos de la solución:

`dotnet build`

7. Genere las migraciones a la base de datos y verifique que se haya creado la BD usando el Azure Data manager por ejemplo:

`dotnet ef database update --startup-project ..\ConsoleApp`

Nota: Si esta en Linux, usar `../ConsoleApp` 

8. Correr la aplicación de pruebas desde la carpeta `ConsoleApp`

`dotnet run`

9. Verificar que se hayan creado algunas entidades en la base de datos usando el Azure Data Manager por ejemplo.
10. Correr la webapp desde la carpeta `FrontEnd`

`dotnet run`
11. Enjoy!
