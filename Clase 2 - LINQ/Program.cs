using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosClase2
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {


                //1.- definimos nuestro data source
                dbPruebaCursoEntities db = new dbPruebaCursoEntities();

                //se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar la respuesta de SQL
                db.Database.CommandTimeout = 0;

                //lazy loading 
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;


                #region Consulta con Where
                //var query = from Empleado in db.Empleado
                //            where Empleado.Salario > 2000M
                //            select Empleado;

                //foreach (var item in query)
                //{
                //    Console.Write(item.Nombre + " - " + item.Salario);
                //}

                #endregion


                #region Consulta Join con Where

                //string departamento = Console.ReadLine();


                //var query = from Empleado in db.Empleado
                //            join Departamento in db.Departamento
                //            on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento
                //            where Empleado.Salario > 2000M && Departamento.Departamento1.Contains(departamento)
                //            select new
                //            {
                //                Empleado.Nombre,
                //                Empleado.Salario,
                //                Departamento =  Departamento.Departamento1
                //            };

                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Nombre + " - " + item.Salario + "-" + item.Departamento);
                //}

                #endregion


                #region Consultas Max y Min 

                //var queryCountSalarioMayor2M = (from Empleado in db.Empleado
                //             where Empleado.Salario > 2000M
                //             select Empleado).Count();

                //var queryTotalEmpleados = db.Empleado.Count();

                //var queryCountSalarioMenor5M = db.Empleado.Where(w => w.Salario < 5000).Count();

                //decimal? querySalarioMaximo = db.Empleado.Max(w => w.Salario);

                //var queryPersonaSalarioMaximo = (from Empleado in db.Empleado
                //                                 orderby Empleado.Salario descending
                //                                 select Empleado).First();
                //var queryPersonaSalarioMinimo = from Empleado in db.Empleado
                //                                where Empleado.Salario == db.Empleado.Min(w => w.Salario)
                //                                select Empleado;



                //Console.WriteLine( "Personas con salario mayor a Q2000 = " + queryCountSalarioMayor2M);
                //Console.WriteLine("Número de Empleados = " + queryTotalEmpleados);
                //Console.WriteLine("Personas con salario menor  a Q5000 = " + queryCountSalarioMenor5M);
                //Console.WriteLine("Salario maximo = " + querySalarioMaximo);
                //Console.WriteLine("Persona con Salario Máximo: " + queryPersonaSalarioMaximo.Nombre);
                //Console.WriteLine("Persona con Salario Mínimo: " + queryPersonaSalarioMinimo.First().Nombre);


                #endregion

                #region Consulta Promedio Salarial por Departamento

                //var queryPromedioSalarioPorDepartamento = (from Empleado in db.Empleado
                //                                           join Departamento in db.Departamento
                //                                           on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento

                //                                           group Empleado by Departamento into agrupacion
                //                                           select new
                //                                           {
                //                                               CodigoDepartamento = agrupacion.Key.CodigoDepartamento,
                //                                               agrupacion.Key.Departamento1,
                //                                               Promedio = agrupacion.Average(w => w.Salario)
                //                                           });


                //foreach (var item in queryPromedioSalarioPorDepartamento)
                //{
                //    Console.WriteLine( item.Departamento1 + " = " + item.Promedio);
                //}

                #endregion

                #region Consulta Total Empleado Por Departamento
                //string departamento = Console.ReadLine();

                //var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                //                                           join Departamento in db.Departamento
                //                                           on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento

                //                                           group Empleado by Departamento into agrupacion
                //                                           where agrupacion.Key.Departamento1.Contains(departamento)
                //                                           select new
                //                                           {
                //                                               CodigoDepartamento = agrupacion.Key.CodigoDepartamento,
                //                                               agrupacion.Key.Departamento1,
                //                                               NoEmpleados = agrupacion.Count()
                //                                           });

                //foreach (var item in queryEmpleadoPorDepartamento)
                //{
                //    Console.WriteLine(item.Departamento1 + " = " + item.NoEmpleados);
                //}

                #endregion

                #region Consulta Order By 


                //var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                //                                    orderby Empleado.Salario //descending
                //                                    select Empleado
                //                                   );

                //foreach (var item in queryEmpleadoPorDepartamento)
                //{
                //    Console.WriteLine(item.Nombre + " = " + item.Salario);
                //}

                #endregion

                #region Consulta Take - Skip
                //string departamento = Console.ReadLine();

                //var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                //                                    join Departamento in db.Departamento
                //                                    on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento
                //                                    where Departamento.Departamento1.Contains(departamento)
                //                                    orderby Empleado.Salario descending
                //                                    select Empleado
                //                                   ).Take(4);

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

                //var queryPersonaSalarioMax = (from Empleado in db.Empleado
                //                                where Empleado.Salario == db.Empleado.Max(w => w.Salario)
                //                                select Empleado).FirstOrDefault();

                //if (queryPersonaSalarioMax != null)
                //    Console.WriteLine(queryPersonaSalarioMax.Nombre + " - " + queryPersonaSalarioMax.Salario);

                #endregion


                #region Consulta con Element At
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

                //if (query!=null)
                //{


                //    Console.WriteLine(query.Departamento1 + " - " + query.Nombre + " - " + query.Salario );
                //}


                #endregion

                #region Uso de All and ANY

                // var query = (from Empleado in db.Empleado
                //              select Empleado).ToList().All(w => w.Salario > 3000);

                //Console.WriteLine(query?"Todos los empleados ganan mas de Q3000":"No todos los empleados ganan mas de Q3000");


                // var queryAny = (from Empleado in db.Empleado
                //              select Empleado).ToList().Any(w => w.Salario > 3000);

                // Console.WriteLine(query ? "Algunos empleados ganan mas de Q3000" : "Ninguno de los empleados ganan mas de Q3000");


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


                #region Consulta Compleja

                var consulta = db.Empleado
                                    .GroupBy(x => new
                                    {
                                        x.CodigoDepartamento,
                                        x.Departamento.Departamento1
                                    }).Select(x => new
                                    {
                                        x.Key.CodigoDepartamento,
                                        x.Key.Departamento1,


                                        EmpleadosSalariosMasBajos = db.Empleado
                                            .Where(y => y.CodigoDepartamento == x.Key.CodigoDepartamento)
                                            .Select(y => new
                                            {
                                                y.CodigoEmpleado,
                                                y.Nombre,
                                                y.EmpleadoDireccion.FirstOrDefault().Direccion,
                                                y.Salario
                                            }).OrderByDescending(y => y.Salario).Take(5).ToList(),




                                    }).
                                    Select(x => new
                                    {
                                        CodigoDepartamento = x.CodigoDepartamento == null ? 0 : x.CodigoDepartamento,
                                        Departamento = x.Departamento1 == null ? "No tiene asignación de departamento" : x.Departamento1,
                                        x.EmpleadosSalariosMasBajos,
                                        CodigoEmpleadoSalarioMasAlto = x.EmpleadosSalariosMasBajos.FirstOrDefault().CodigoEmpleado,
                                        EmpleadoSalarioMasAlto = x.EmpleadosSalariosMasBajos.FirstOrDefault().Nombre,


                                    }).ToList();

                foreach (var item in consulta)
                {
                    Console.WriteLine(item.Departamento + ": Salario Mas Alto: " + item.CodigoEmpleadoSalarioMasAlto + " - " + item.EmpleadoSalarioMasAlto);
                    Console.WriteLine("Listado de salarios mas bajos: ");
                    foreach (var itemSalariosMasBajos in item.EmpleadosSalariosMasBajos)
                    {
                        Console.WriteLine(itemSalariosMasBajos.Nombre + "-" + itemSalariosMasBajos.Salario);
                    }
                }

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
