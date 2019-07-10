using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Clase_3_EFManejoInformacion.Modelo;

namespace EjemplosClase3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Instanciamos el contexto de Entity Framework
                BBDDLocalClase3Entities db = new BBDDLocalClase3Entities();

                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;
                #region Lazy Loading
                LazyLoading();
                #endregion

                #region Operaciones en base de datos
                //OperacionesDB();
                #endregion

                #region Transacciones
                //Transacciones();
                #endregion

                #region Objetos de BBDD en EF
                ObjetosDB();
                #endregion

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        static void LazyLoading()
        {
            try
            {
                //Instanciamos el contexto de Entity Framework
                BBDDLocalClase3Entities db = new BBDDLocalClase3Entities();

                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;
                #region Lazy Loading

                #region Consulta Con Lazy Loading

                Console.WriteLine("\n");
                List<Departamento> ListaDepartamento = db.Departamento.ToList();
                foreach (Departamento item in ListaDepartamento)
                {
                    Console.WriteLine(item.Departamento1);
                    foreach (Empleado itemE in item.Empleado)
                    {
                        Console.WriteLine(" " + itemE.Nombre);
                    }
                }
                #endregion

                #region Consulta Sin Lazy Loading

                Console.WriteLine("\n");
                BBDDLocalClase3Entities db2 = new BBDDLocalClase3Entities();
                db2.Configuration.LazyLoadingEnabled = false;
                db2.Configuration.ProxyCreationEnabled = false;
                List<Departamento> ListaDepartamento2 = db2.Departamento.ToList();
                foreach (Departamento item2 in ListaDepartamento2)
                {
                    Console.WriteLine(item2.Departamento1);
                    foreach (Empleado itemE2 in item2.Empleado)
                    {
                        Console.WriteLine(" " + itemE2.Nombre);
                    }
                }
                #endregion

                #region Consulta Con Lazy Loading - Solo campos necesarios

                Console.WriteLine("\n");
                var ListaDepartamento3 = db.Departamento.Select(x =>
                    new
                    {
                        CodigoDepartamento = x.CodigoDepartamento,
                        Departamento1 = x.Departamento1,
                        Empleado = x.Empleado.Select(c => new {
                            CodigoEmpleado = c.CodigoEmpleado,
                            Nombre = c.Nombre
                        })
                    }
                ).ToList();
                foreach (var item3 in ListaDepartamento3)
                {
                    Console.WriteLine(item3.Departamento1);
                    foreach (var itemE3 in item3.Empleado)
                    {
                        Console.WriteLine(" " + itemE3.Nombre);
                    }
                }
                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        static void OperacionesDB()
        {
            try
            {
                //Instanciamos el contexto de Entity Framework
                BBDDLocalClase3Entities db = new BBDDLocalClase3Entities();

                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;

                #region Operaciones en base de datos

                #region EF - Insert

                //Insertar 1 registro
                Departamento newDepartamento = new Departamento();
                newDepartamento.Departamento1 = "Fabrica";
                db.Departamento.Add(newDepartamento);
                db.SaveChanges();
                Console.WriteLine("***********INSERT 1 REGISTRO*************");
                var ListaDepartamentoInsert1 = db.Departamento.Select(x =>
                    new
                    {
                        CodigoDepartamento = x.CodigoDepartamento,
                        Departamento1 = x.Departamento1
                    }
                ).ToList();
                foreach (var item in ListaDepartamentoInsert1)
                {
                    Console.WriteLine(item.Departamento1);
                }

                //Insertar varios registros
                //db.Configuration.AutoDetectChangesEnabled = false;
                for (int x = 1; x <= 5; x++)
                {
                    Departamento newDepartamentoVarios = new Departamento();
                    newDepartamentoVarios.Departamento1 = "Depto A" + x.ToString();
                    db.Departamento.Add(newDepartamentoVarios);
                    //db.SaveChanges(); //Lo vuelve lento
                }
                db.SaveChanges();
                Console.WriteLine("***********INSERT VARIOS REGISTROS*************");
                var ListaDepartamentoInsertV = db.Departamento.Select(x =>
                    new
                    {
                        CodigoDepartamento = x.CodigoDepartamento,
                        Departamento1 = x.Departamento1
                    }
                ).ToList();
                foreach (var item in ListaDepartamentoInsertV)
                {
                    Console.WriteLine(item.Departamento1);
                }

                //Insertar lista de registros
                IList<Departamento> newListaDepartamentos = new List<Departamento>() {
                        new Departamento() { Departamento1 = "Depto B1" },
                        new Departamento() { Departamento1 = "Depto B2" },
                        new Departamento() { Departamento1 = "Depto B3" },
                        new Departamento() { Departamento1 = "Depto B4" },
                        new Departamento() { Departamento1 = "Depto B5" }
                };
                db.Departamento.AddRange(newListaDepartamentos);
                db.SaveChanges();
                Console.WriteLine("***********INSERT LIST*************");
                var ListaDepartamentoInsert = db.Departamento.Select(x =>
                    new
                    {
                        CodigoDepartamento = x.CodigoDepartamento,
                        Departamento1 = x.Departamento1
                    }
                ).ToList();
                foreach (var item in ListaDepartamentoInsert)
                {
                    Console.WriteLine(item.Departamento1);
                }

                #endregion

                #region EF - Update
                //Editar 1 registro
                Departamento updDepartamento = db.Departamento.Where(x => x.Departamento1 == "Depto B1").FirstOrDefault();
                if (updDepartamento != null)
                {
                    updDepartamento.Departamento1 = "Depto B1 - Act";
                    db.SaveChanges();
                }

                Console.WriteLine("***********UPDATE 1 REGISTRO*************");
                var ListaDepartamentoUpdate1 = db.Departamento.Select(x =>
                    new
                    {
                        CodigoDepartamento = x.CodigoDepartamento,
                        Departamento1 = x.Departamento1
                    }
                ).ToList();
                foreach (var item in ListaDepartamentoUpdate1)
                {
                    Console.WriteLine(item.Departamento1);
                }

                //Editar varios registros
                List<Departamento> ListaDepartamentos = db.Departamento.Where(x => x.Departamento1.Contains("Depto A")).ToList();
                int Contador = 0;
                foreach (Departamento item in ListaDepartamentos)
                {
                    Contador++;
                    item.Departamento1 = "Depto C" + Contador.ToString();
                }
                db.SaveChanges();

                Console.WriteLine("***********UPDATE VARIOS REGISTROS*************");
                var ListaDepartamentoUpdate = db.Departamento.Select(x =>
                    new
                    {
                        CodigoDepartamento = x.CodigoDepartamento,
                        Departamento1 = x.Departamento1
                    }
                ).ToList();
                foreach (var item in ListaDepartamentoUpdate)
                {
                    Console.WriteLine(item.Departamento1);
                }

                #endregion

                #region EF - Delete
                //Eliminar 1 registro
                Departamento delDepartamento = db.Departamento.Where(x => x.Departamento1 == "Depto B2").FirstOrDefault();
                if (delDepartamento != null)
                {
                    db.Departamento.Remove(delDepartamento);
                    db.SaveChanges();
                }

                Console.WriteLine("***********DELETE 1 REGISTRO*************");
                var ListaDepartamentoDelete1 = db.Departamento.Select(x =>
                    new
                    {
                        CodigoDepartamento = x.CodigoDepartamento,
                        Departamento1 = x.Departamento1
                    }
                ).ToList();
                foreach (var item in ListaDepartamentoDelete1)
                {
                    Console.WriteLine(item.Departamento1);
                }

                //Eliminar lista de registros
                List<Departamento> ListaDepartamentosDel = db.Departamento.Where(x => x.Departamento1.Contains("Depto C")).ToList();
                db.Departamento.RemoveRange(ListaDepartamentosDel);
                db.SaveChanges();

                Console.WriteLine("***********DELETE*************");
                var ListaDepartamentoDelete = db.Departamento.Select(x =>
                    new
                    {
                        CodigoDepartamento = x.CodigoDepartamento,
                        Departamento1 = x.Departamento1
                    }
                ).ToList();
                foreach (var item in ListaDepartamentoDelete)
                {
                    Console.WriteLine(item.Departamento1);
                }
                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        static void Transacciones()
        {
            try
            {
                //Instanciamos el contexto de Entity Framework
                BBDDLocalClase3Entities db = new BBDDLocalClase3Entities();

                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;
                Console.WriteLine("***********ANTES DE TRANSACCION*************");
                var ListaPaisA = db.Pais.Select(x =>
                    new
                    {
                        CodigoPais = x.CodigoPais,
                        Descripcion = x.Descripcion
                    }
                ).ToList();
                Console.WriteLine("***********PAIS*************");
                foreach (var item in ListaPaisA)
                {
                    Console.WriteLine(item.CodigoPais.ToString() + " - " + item.Descripcion);
                }

                var ListaDeptoA = db.Depto.Select(x =>
                    new
                    {
                        CodigoDepto = x.CodigoDepto,
                        Descripcion = x.Descripcion
                    }
                ).ToList();
                Console.WriteLine("***********DEPARTAMENTO*************");
                foreach (var item in ListaDeptoA)
                {
                    Console.WriteLine(item.CodigoDepto.ToString() + " - " + item.Descripcion);
                }

                var ListaMunicipioA = db.Municipio.Select(x =>
                    new
                    {
                        CodigoMunicipio = x.CodigoMunicipio,
                        Descripcion = x.Descripcion
                    }
                ).ToList();
                Console.WriteLine("***********MUNICIPIO*************");
                foreach (var item in ListaMunicipioA)
                {
                    Console.WriteLine(item.CodigoMunicipio.ToString() + " - " + item.Descripcion);
                }

                #region Transacciones
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Pais newPais = new Pais() { Descripcion = "Pais nuevo" };
                        db.Pais.Add(newPais);

                        //Correcto
                        //Depto newDepto = new Depto() { CodigoPais = newPais.CodigoPais, Descripcion = "Depto nuevo" };
                        //db.Depto.Add(newDepto);

                        //Con error
                        Depto newDepto = new Depto() { CodigoPais = 10, Descripcion = "Depto nuevo" };
                        db.Depto.Add(newDepto);

                        Municipio newMunicipio = new Municipio() { CodigoDepto = newDepto.CodigoDepto, Descripcion = "Municipio nuevo" };
                        db.Municipio.Add(newMunicipio);

                        db.SaveChanges();

                        dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.InnerException.Message);
                        Console.WriteLine(ex.InnerException.InnerException.Message);
                        dbTransaction.Rollback();
                    }
                }
                Console.WriteLine("***********DESPUES DE TRANSACCION*************");
                var ListaPais = db.Pais.Select(x =>
                    new
                    {
                        CodigoPais = x.CodigoPais,
                        Descripcion = x.Descripcion
                    }
                ).ToList();
                Console.WriteLine("***********PAIS*************");
                foreach (var item in ListaPais)
                {
                    Console.WriteLine(item.CodigoPais.ToString() + " - " +item.Descripcion);
                }

                var ListaDepto = db.Depto.Select(x =>
                    new
                    {
                        CodigoDepto = x.CodigoDepto,
                        Descripcion = x.Descripcion
                    }
                ).ToList();
                Console.WriteLine("***********DEPARTAMENTO*************");
                foreach (var item in ListaDepto)
                {
                    Console.WriteLine(item.CodigoDepto.ToString() + " - " + item.Descripcion);
                }

                var ListaMunicipio = db.Municipio.Select(x =>
                    new
                    {
                        CodigoMunicipio = x.CodigoMunicipio,
                        Descripcion = x.Descripcion
                    }
                ).ToList();
                Console.WriteLine("***********MUNICIPIO*************");
                foreach (var item in ListaMunicipio)
                {
                    Console.WriteLine(item.CodigoMunicipio.ToString() + " - " + item.Descripcion);
                }
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        static void ObjetosDB()
        {
            try
            {
                //Instanciamos el contexto de Entity Framework
                BBDDLocalClase3Entities db = new BBDDLocalClase3Entities();

                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;

                Console.WriteLine("***********OBJETOS DB*************");
                #region Objetos de BBDD en EF

                #region Consumo de procedimiento
                List<PPaisDeptoMunicipioListar_Result> ListaSP = db.PPaisDeptoMunicipioListar(1).ToList();
                Console.WriteLine("***********PROCEDIMIENTO*************");
                foreach (PPaisDeptoMunicipioListar_Result item in ListaSP)
                {
                    Console.WriteLine(item.CodigoPais.ToString() + " - " + item.DescPais + "; " + item.CodigoDepto + " - " + item.DescDepto + "; " + item.CodigoMunicipio + " - " + item.DescMunicipio + "; " );
                }
                #endregion

                #region Consumo de función
                List<FEmpleadoDepartamento_Result> ListaF = db.FEmpleadoDepartamento(1).ToList();
                Console.WriteLine("***********FUNCION*************");
                foreach (FEmpleadoDepartamento_Result item in ListaF)
                {
                    Console.WriteLine(item.CodigoEmpleado.ToString() + " - " + item.Nombre + "; " + item.CodigoDepartamento + " - " + item.Departamento);
                }
                #endregion

                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }
}
