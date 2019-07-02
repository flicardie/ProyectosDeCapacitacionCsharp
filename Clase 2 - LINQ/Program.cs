using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemplosClase2.Modelo;
using System.Data.Entity;

namespace EjemplosClase2
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //1.- Instanciamos el contexto de Entity Framework
                BBDDLocalEntidades db = new BBDDLocalEntidades();

                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;

                //Lazy Loading
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;

                #region Beneficios en general de LINQ
                
                #region Combinación de cadenas con y sin LINQ

                // Si quisieramos combinar todas estas cadenas en una sala sin LINQ hariamos lo siguiente

                string[] paises = { "India", "US", "UK", "Canada", "Australia" };

                #region Sin LINQ Unión de cadenas

                //string resultadoSinLINQ = string.Empty;
                //for (int i = 0; i < paises.Length; i++)
                //{
                //    resultadoSinLINQ = resultadoSinLINQ + paises[i] + ", ";
                //}

                //int lastIndexSinLINQ = resultadoSinLINQ.LastIndexOf(",");
                //resultadoSinLINQ = resultadoSinLINQ.Remove(lastIndexSinLINQ);

                //Console.WriteLine(resultadoSinLINQ);

                #endregion

                #region Con LINQ

                // Si quisieramos combinar todas estas cadenas en una sala sin LINQ hariamos lo siguiente

                //string result = paises.Aggregate((a, b) => a + ", " + b);

                #endregion

                #endregion

                #region Multiplicación de todos los números con y sin LINQ

                // Si quisieramos multiplicar todos estos números

                int[] Numbers = { 2, 3, 4, 5 };

                #region Sin LINQ 

                int result = 1;
                foreach (int i in Numbers)
                {
                    result = result * i;
                }

                Console.WriteLine(result);

                #endregion

                #region Con LINQ

                int resultado = Numbers.Aggregate((a, b) => a * b);

                Console.WriteLine(resultado);

                #endregion

                #endregion


                #endregion

                #region Consulta con Where

                //#region Query Syntax

                //var querySyntaxConsultaSimple = (from Empleado in db.Empleado
                //            where Empleado.Salario > 2000M
                //            select Empleado).ToList();

                //foreach (var item in querySyntaxConsultaSimple)
                //{
                //    Console.WriteLine(item.Nombre + " - " + item.Salario);
                //}


                //#endregion

                //#region Method Syntax

                //var queryMethodSyntaxConsultaSimple = db.Empleado
                //                .Where(x => x.Salario > 2000M)
                //                .Select(x => new
                //                {
                //                    x.Nombre,
                //                    x.Salario
                //                }).ToList();

                //foreach (var item in queryMethodSyntaxConsultaSimple)
                //{
                //    Console.WriteLine(item.Nombre + " - " + item.Salario);
                //}

                //#endregion

                #endregion

                #region Consulta Join con Where




                #region Query Syntax

                //string departamento = Console.ReadLine();

                //var querySyntax = (from Empleado in db.Empleado
                //             join Departamento in db.Departamento
                //             on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento
                //             where Empleado.Salario > 2000M && Departamento.Departamento1.Contains(departamento)
                //             select new
                //             {
                //                 Empleado.Nombre,
                //                 Empleado.Salario,
                //                 Departamento = Departamento.Departamento1
                //             }).ToList();


                //foreach (var item in querySyntax)
                //{
                //    Console.WriteLine(item.Nombre + " - " + item.Salario + "-" + item.Departamento);
                //}

                #endregion

                #region Method Syntax

                //string departamento = Console.ReadLine();

                //var methodSyntax = db.Empleado.Join(db.Departamento
                //    , EmpleadoTP => EmpleadoTP.CodigoDepartamento
                //    , DepartamentoTF => DepartamentoTF.CodigoDepartamento,
                //    (EmpleadoTP, DepartamentoTF) => new
                //    {
                //        EmpleadoTP.Nombre,
                //        EmpleadoTP.Salario,
                //        Departamento = DepartamentoTF.Departamento1

                //    }).Where(x => x.Salario > 2000M && x.Departamento.Contains(departamento)).ToList();


                //foreach (var item in methodSyntax)
                //{
                //    Console.WriteLine(item.Nombre + " - " + item.Salario + "-" + item.Departamento);
                //}

                #endregion



                #endregion

                #region Consultas Max y Min 

                #region Query Syntax

                //var queryCountSalarioMayor2M = (from Empleado in db.Empleado
                //                                where Empleado.Salario > 2000M
                //                                select Empleado).Count();

                //var queryTotalEmpleados = (from Empleado in db.Empleado select Empleado).Count();

                //var queryCountSalarioMenor5M = (from Empleado in db.Empleado where Empleado.Salario < 5000 select Empleado).Count();

                //decimal? querySalarioMaximo = (from Empleado in db.Empleado select Empleado.Salario).Max();

                //var queryPersonaSalarioMaximo = (from Empleado in db.Empleado
                //                                 orderby Empleado.Salario descending
                //                                 select Empleado).FirstOrDefault();

                //var queryPersonaSalarioMinimo = (from Empleado in db.Empleado
                //                                where Empleado.Salario == db.Empleado.Min(w => w.Salario)
                //                                select Empleado).FirstOrDefault();

                #endregion

                #region Method Syntax

                //var queryCountSalarioMayor2M = db.Empleado.Where(x => x.Salario > 2000M).Count();

                //var queryTotalEmpleados = db.Empleado.Count();

                //var queryCountSalarioMenor5M = db.Empleado.Where(w => w.Salario < 5000).Count();

                //decimal? querySalarioMaximo = db.Empleado.Max(w => w.Salario);

                //var queryPersonaSalarioMaximo = db.Empleado.OrderByDescending(x => x.Salario).FirstOrDefault();

                //var queryPersonaSalarioMinimo = db.Empleado.OrderBy(x => x.Salario).FirstOrDefault();




                #endregion

                //Console.WriteLine("Personas con salario mayor a Q2000 = " + queryCountSalarioMayor2M);
                //Console.WriteLine("Número de Empleados = " + queryTotalEmpleados);
                //Console.WriteLine("Personas con salario menor  a Q5000 = " + queryCountSalarioMenor5M);
                //Console.WriteLine("Salario maximo = " + querySalarioMaximo);
                //Console.WriteLine("Persona con Salario Máximo: " + queryPersonaSalarioMaximo.Nombre);
                //Console.WriteLine("Persona con Salario Mínimo: " + queryPersonaSalarioMinimo.Nombre);


                #endregion

                #region Consulta Promedio Salarial por Departamento

                #region Query Syntax

                //var queryPromedioSalarioPorDepartamento = (from Empleado in db.Empleado
                //                                           join Departamento in db.Departamento
                //                                           on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento

                //                                           group Empleado by Departamento into agrupacion
                //                                           select new
                //                                           {
                //                                               CodigoDepartamento = agrupacion.Key.CodigoDepartamento,
                //                                               agrupacion.Key.Departamento1,
                //                                               Promedio = agrupacion.Average(w => w.Salario)
                //                                           }).ToList();

                #endregion

                #region Method Syntax

                //var queryPromedioSalarioPorDepartamento = db.Empleado.Join(db.Departamento
                //    , EmpleadoTP => EmpleadoTP.CodigoDepartamento
                //    , DepartamentoTF => DepartamentoTF.CodigoDepartamento,
                //    (EmpleadoTP, DepartamentoTF) => new
                //    {
                //        Empleado = EmpleadoTP,
                //        Departamento = DepartamentoTF

                //    }).ToList()
                //    .GroupBy(x => x.Departamento)
                //    .Select(x => new
                //    {
                //        x.Key.CodigoDepartamento,
                //        x.Key.Departamento1,
                //        Promedio = x.Average(y => y.Empleado.Salario)

                //    }).ToList();



                #endregion


                //foreach (var item in queryPromedioSalarioPorDepartamento)
                //{
                //    Console.WriteLine(item.Departamento1 + " = " + item.Promedio);
                //}

                #endregion

                #region Consulta Total Empleado Por Departamento


                #region Query Syntax

                //string departamento = Console.ReadLine();

                //var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                //                                    join Departamento in db.Departamento
                //                                    on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento

                //                                    group Empleado by Departamento into agrupacion
                //                                    where agrupacion.Key.Departamento1.Contains(departamento)
                //                                    select new
                //                                    {
                //                                        CodigoDepartamento = agrupacion.Key.CodigoDepartamento,
                //                                        agrupacion.Key.Departamento1,
                //                                        NoEmpleados = agrupacion.Count()
                //                                    }).ToList();

                #endregion

                #region Method Syntax

                //string departamento = Console.ReadLine();

                //var queryEmpleadoPorDepartamento = db.Empleado.Join(db.Departamento
                //    , EmpleadoTP => EmpleadoTP.CodigoDepartamento
                //    , DepartamentoTF => DepartamentoTF.CodigoDepartamento,
                //    (EmpleadoTP, DepartamentoTF) => new
                //    {
                //        Empleado = EmpleadoTP,
                //        Departamento = DepartamentoTF

                //    })
                //    .Where(x => x.Departamento.Departamento1.Contains(departamento) )
                //    .GroupBy(x => x.Departamento)
                //    .Select(x => new
                //    {
                //        x.Key.CodigoDepartamento,
                //        x.Key.Departamento1,
                //        NoEmpleados = x.Count()

                //    }).ToList();

                #endregion

                //foreach (var item in queryEmpleadoPorDepartamento)
                //{
                //    Console.WriteLine(item.Departamento1 + " = " + item.NoEmpleados);
                //}

                #endregion

                #region Consulta Order By 

                #region Query Syntax

                //var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                //                                    orderby Empleado.Salario //descending
                //                                    select Empleado
                //                                   ).ToList();

                #endregion

                #region Method Syntax

                //var queryEmpleadoPorDepartamento = db.Empleado.OrderBy(x => x.Salario).Select(x => x);

                #endregion

                //foreach (var item in queryEmpleadoPorDepartamento)
                //{
                //    Console.WriteLine(item.Nombre + " = " + item.Salario);
                //}


                #endregion

                #region Consulta Take - Skip

                #region Query Syntax

                //string departamento = Console.ReadLine();

                //var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                //                                    join Departamento in db.Departamento
                //                                    on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento
                //                                    where Departamento.Departamento1.Contains(departamento)
                //                                    orderby Empleado.Salario descending
                //                                    select Empleado
                //                                   ).Take(4).ToList();

                #endregion

                #region Method Syntax

                //string departamento = Console.ReadLine();

                //var queryEmpleadoPorDepartamento = db.Empleado.Join(db.Departamento
                //    , EmpleadoTP => EmpleadoTP.CodigoDepartamento
                //    , DepartamentoTF => DepartamentoTF.CodigoDepartamento,
                //    (EmpleadoTP, DepartamentoTF) => new
                //    {
                //        Empleado = EmpleadoTP,
                //        Departamento = DepartamentoTF

                //    })
                //    .Where(x => x.Departamento.Departamento1.Contains(departamento))

                //    .Select(x => x.Empleado)
                //    .Take(4)
                //    .ToList();


                #endregion


                //foreach (var item in queryEmpleadoPorDepartamento)
                //{
                //    Console.WriteLine(item.Nombre + " = " + item.Salario);
                //}

                //var query = (from Empleado in db.Empleado
                //             join Departamento in db.Departamento
                //                                   on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento
                //             where Departamento.Departamento1.Contains(departamento)
                //             orderby Empleado.Salario descending
                //            select Empleado
                //                                   ).Skip(2).First();

                //Console.WriteLine(query.Nombre + " = " + query.Salario);




                #endregion

                #region Consulta con FirstOrDefault

                #region Query Syntax

                //var queryPersonaSalarioMax = (from Empleado in db.Empleado
                //                                where Empleado.Salario == db.Empleado.Max(w => w.Salario)
                //                                select Empleado).FirstOrDefault();

                #endregion

                #region Method Syntax

                //var queryPersonaSalarioMax = db.Empleado.Where(x => x.Salario == db.Empleado.Max(w => w.Salario)).FirstOrDefault();

                #endregion



                //if (queryPersonaSalarioMax != null)
                //    Console.WriteLine(queryPersonaSalarioMax.Nombre + " - " + queryPersonaSalarioMax.Salario);

                #endregion


                #region Consulta con Element At

                #region Query Syntax
                //string departamento = Console.ReadLine();

                //var query = (from Empleado in db.Empleado
                //            join Departamento in db.Departamento
                //            on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento
                //            where Departamento.Departamento1.Contains(departamento)

                //            select new
                //            {
                //                Departamento.CodigoDepartamento,
                //                Departamento.Departamento1,
                //                Empleado.Nombre,
                //                Empleado.Salario
                //            }).ToList().ElementAtOrDefault(2);

                #endregion

                #region Method Syntax

                //string departamento = Console.ReadLine();

                //var query = db.Empleado.Join(db.Departamento
                //    , EmpleadoTP => EmpleadoTP.CodigoDepartamento
                //    , DepartamentoTF => DepartamentoTF.CodigoDepartamento,
                //    (EmpleadoTP, DepartamentoTF) => new
                //    {
                //        Empleado = EmpleadoTP,
                //        Departamento = DepartamentoTF

                //    })
                //    .Where(x => x.Departamento.Departamento1.Contains(departamento))

                //    .Select(x => new
                //    {
                //        x.Departamento.CodigoDepartamento,
                //        x.Departamento.Departamento1,
                //        x.Empleado.Nombre,
                //        x.Empleado.Salario
                //    })
                //    .ToList().ElementAtOrDefault(2);


                #endregion

                //if (query!=null)
                //{


                //    Console.WriteLine(query.Departamento1 + " - " + query.Nombre + " - " + query.Salario );
                //}


                #endregion

                #region Uso de All and ANY

                #region Query and Methos Syntax

                // var query = (from Empleado in db.Empleado
                //              select Empleado).ToList().All(w => w.Salario > 3000);

                //Console.WriteLine(query?"Todos los empleados ganan mas de Q3000":"No todos los empleados ganan mas de Q3000");


                // var queryAny = (from Empleado in db.Empleado
                //              select Empleado).ToList().Any(w => w.Salario > 3000);

                // Console.WriteLine(query ? "Algunos empleados ganan mas de Q3000" : "Ninguno de los empleados ganan mas de Q3000");


                #endregion


                #endregion

                #region Consulta por lista de código de Empleado


                //List<int> listadoDeEmpleados = new List<int>{ 1, 4, 6, 8, 9 };
                //var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                //                                    where listadoDeEmpleados.Contains(Empleado.CodigoEmpleado)
                //                                    select Empleado
                //                                   );

                //foreach (var item in queryEmpleadoPorDepartamento)
                //{
                //    Console.WriteLine(item.Nombre + " = " + item.Salario);
                //}
                #endregion
                #region Consulta para obtener IGSS

                // Uso del comando LET

                //var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                //                                    let IGSS = Empleado.Salario * 0.0483M
                //                                    select new
                //                                    {
                //                                        Empleado.Nombre,
                //                                        Empleado.Salario, 
                //                                        IGSS,
                //                                        SalarioFinal = Empleado.Salario-IGSS
                //                                    }
                //                                   );

                //foreach (var item in queryEmpleadoPorDepartamento)
                //{
                //    Console.WriteLine(item.Nombre + " -" + item.Salario +" - "+item.IGSS+" - "+ item.SalarioFinal);
                //}
                #endregion

                #region Consulta para Empleados sin departamento 

                // Para hacer LEFT JOIN es más fácil con Query Syntax

                //var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                //                                    join D in db.Departamento
                //                                    on Empleado.CodigoDepartamento equals D.CodigoDepartamento into leftDepartamento
                //                                    from Departamento in leftDepartamento.DefaultIfEmpty()
                //                                    where Empleado.CodigoDepartamento == null
                //                                    select new
                //                                    {
                //                                        Empleado.Nombre,
                //                                        Empleado.Salario,
                //                                        Departamento = Departamento == null ? "Sin asignar" : Departamento.Departamento1
                //                                    }
                //                                   );

                //foreach (var item in queryEmpleadoPorDepartamento)
                //{
                //    Console.WriteLine(item.Nombre + " -" + item.Salario + " - " + item.Departamento);
                //}
                #endregion

                #region Trabajando con Fechas



                // En LINQ to Entity, no podemos utilizar los métodos disponibles para el trabajo con fechas, por ejemplo lo siguiente da error, en LINQ to Objects no tendriamos ese problema

                //var query = db.Empleado.
                //    Select(x => new
                //    {

                //        Empleado = x.Nombre,
                //        Fecha = x.Fecha,
                //        FechaRestando5Dias = x.Fecha.Value.AddDays(-5).Date,
                //        AñoAgregado = x.Fecha.Value.AddYears(10)
                //    }).ToList();



                /* Para ello, disponemos de la clase DbFunctions, que nos permite realizar lo anterior sin errores
                 * Ejemplo https://hernandgr.wordpress.com/2015/07/21/tip-clase-dbfunctions-usando-funciones-canonicas-linq-to-entities-en-c-sharp/
                 */

                var queryConDbFunctions = db.Empleado.
                 Select(x => new
                 {
                     Empleado = x.Nombre,
                     Fecha = x.Fecha,
                     FechaRestando5Dias = DbFunctions.AddDays(x.Fecha.Value, -5),
                     AñoAgregado = DbFunctions.AddYears(x.Fecha, 10).Value

                 }).ToList();

                #endregion

                #region Ejemplo uso de LIKE

                /* Se pueden serguir los siguientes enlaces como apoyo
                 * https://www.cjorellana.net/2012/06/like-en-entity-framework.html
                 */

                var ejemploCadenaLike = "ar";

                
                /* Todos los empleados que contienen la cadena ar
                 * SELECT * FROM Empleado WHERE Nombre like '%ar%'
                 */

                var matchesEjemplo1 = (from m in db.Empleado
                                       where m.Nombre.Contains(ejemploCadenaLike)
                                       select m).ToList();

                /* Todos los empleados que empiezan con la cadena ar
                 * SELECT * FROM Empleado WHERE Nombre like '%ar'
                 */

                var matchesEjemplo2 = (from m in db.Empleado
                                       where m.Nombre.ToLower().StartsWith(ejemploCadenaLike)
                                       select m).ToList();

                /* Todos los empleados que finalizan con la cadena
                 * SELECT * FROM Empleado WHERE Nombre like 'ar%'
                 */

                var matchesEjemplo3 = (from m in db.Empleado
                                       where m.Nombre.ToLower().EndsWith(ejemploCadenaLike)
                                       select m).ToList();

                /* Todos los empleados que empiezan con la letra t y finalizan con la letra s
                 * SELECT * FROM Empleado WHERE Nombre like 't%s'
                 */

                var matchesEjemplo4 = (from m in db.Empleado
                                       where m.Nombre.ToLower().StartsWith("t") && m.Nombre.ToLower().EndsWith("s")
                                       select m).ToList();


                #endregion

                #region Consulta Compleja



                //var consulta = db.Empleado
                //                    .GroupBy(x => new
                //                    {
                //                        x.CodigoDepartamento,
                //                        x.Departamento.Departamento1
                //                    }).Select(x => new
                //                    {
                //                        x.Key.CodigoDepartamento,
                //                        x.Key.Departamento1,


                //                        EmpleadosSalariosMasBajos = db.Empleado
                //                            .Where(y => y.CodigoDepartamento == x.Key.CodigoDepartamento)
                //                            .Select(y => new
                //                            {
                //                                y.CodigoEmpleado,
                //                                y.Nombre,
                //                                y.EmpleadoDireccion.FirstOrDefault().Direccion,
                //                                y.Salario
                //                            }).OrderByDescending(y => y.Salario).Take(5).ToList(),




                //                    }).
                //                    Select(x => new
                //                    {
                //                        CodigoDepartamento = x.CodigoDepartamento == null ? 0 : x.CodigoDepartamento,
                //                        Departamento = x.Departamento1 == null ? "No tiene asignación de departamento" : x.Departamento1,
                //                        x.EmpleadosSalariosMasBajos,
                //                        CodigoEmpleadoSalarioMasAlto = x.EmpleadosSalariosMasBajos.FirstOrDefault().CodigoEmpleado,
                //                        EmpleadoSalarioMasAlto = x.EmpleadosSalariosMasBajos.FirstOrDefault().Nombre,


                //                    }).ToList();

                //foreach (var item in consulta)
                //{
                //    Console.WriteLine(item.Departamento + ": Salario Mas Alto: " + item.CodigoEmpleadoSalarioMasAlto + " - " + item.EmpleadoSalarioMasAlto);
                //    Console.WriteLine("Listado de salarios mas bajos: ");
                //    foreach (var itemSalariosMasBajos in item.EmpleadosSalariosMasBajos)
                //    {
                //        Console.WriteLine(itemSalariosMasBajos.Nombre + "-" + itemSalariosMasBajos.Salario);
                //    }
                //}

                #endregion



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
