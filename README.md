# API REST Midas
Api Venta y Stock de Productos con Net Core 6

## Ventas y stock.
Un almacén de barrio necesita llevar un registro básico de sus ventas y un control del
stock de sus productos.
* Crear una API REST en net core 6. Usar Controllers.
* Conectarse a una base de datos SQL Server
* Utilizar Entity Framework (EF), con el modo Code First para crear las tablas en
la BD. Se necesitan (como mínimo) tablas para Productos y Tipos de
Productos (Golosina, Bebidas, Art. Limpieza, etc.). Queda a criterio del
postulante tablas adicionales.
* Desarrollar un CRUD básico para los productos y sus ventas. Ej. Crear un
nuevo producto, obtener 1 o todos los productos con su ‘Tipo’, actualizar precio
de X producto, registrar una nueva venta, cancelar/borrar una venta.
* Obtener listado de ventas de una fecha determinada.
* Obtener el importe total de las ventas de una fecha determinada.
* Obtener stock actual de todos los productos.
* Obtener stock de 1 ‘Tipo de Producto’.
## Consideraciones:
* Por razones de simplicidad el ‘actualizar un precio’ reemplaza al precio anterior
(sin fechas de vigencias).
* No es necesario considerar diferentes ‘Formas de Pago’. Todo será
considerado como ventas en efectivo.
* Al crear un producto, registrar el ‘Stock Inicial’ a partir del cual será calculado el
resto del stock.
* Se valorará la utilización de LINQ en la lógica. No usar comandos/scripts SQL.
* Se valorará el uso de ‘Buenas Prácticas’ en la solución armada.
