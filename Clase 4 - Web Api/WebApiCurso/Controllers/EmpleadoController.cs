using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCurso.Models;
namespace WebApiCurso.Controllers
{
    public class EmpleadoController : ApiController
    {
        BBDDLocalEntities db;

        public EmpleadoController()
        {
            db = new BBDDLocalEntities();
        }
        
        
        
        /// <summary>
        /// Consulta por código Empleado  
        /// </summary>
        /// <returns></returns>
        /// 

            [HttpGet]
            [Route("Api/Empleado/{id:int}")]
        public IHttpActionResult Get(int id )
        {
            try
            {
                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;

                //Lazy Loading
                //db.Configuration.LazyLoadingEnabled = false;
                //db.Configuration.ProxyCreationEnabled = false;

                //consulta 
                var listadoEmpleado = (from Empleado 
                                       in db.Empleado
                                        where Empleado.CodigoEmpleado == id 
                                       select Empleado).ToList();

                if (listadoEmpleado!=null)
                {
                    return Ok(listadoEmpleado);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                return InternalServerError(ex.GetBaseException());
            }
        }



        /// <summary>
        /// Listado simple de la entidad 
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpGet]
        [Route("Api/Empleado/")]
        public IHttpActionResult Get()
        {
            try
            {
                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;

                //Lazy Loading
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;

                //consulta 
                var listadoEmpleado = (from Empleado in db.Empleado select Empleado).ToList();

                if (listadoEmpleado != null)
                {
                    return Ok(listadoEmpleado);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                return InternalServerError(ex.GetBaseException());
            }
        }

        /// <summary>
        /// ¿ Cómo puedo obtener las personas con salarios mayores a Q2000? SELECT CON CONDICIONES
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Api/Empleado/SalarioMayorA/{valor}")]
        public IHttpActionResult GetBySalarioMayorA(int valor)
        {
            try
            {
                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;

                //Lazy Loading
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;

                //consulta 
                var querySyntaxConsultaSimple = (from Empleado in db.Empleado
                                                 where Empleado.Salario > valor 
                                                 select Empleado).ToList();

                if (querySyntaxConsultaSimple != null)
                {
                    return Ok(querySyntaxConsultaSimple);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                return InternalServerError(ex.GetBaseException());
            }
        }


        /// <summary>
        /// Obtener total empleado por departamento 
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Api/Empleado/TotalDepartamento/{departamento}")]
        public IHttpActionResult GetByTotalPorDepartamento(string departamento)
        {
            try
            {
                //Se le asigna un valor en segundos, si se le asigna 0 entonces obligamos a EF a esperar indefinidamente la respuesta de SQL
                db.Database.CommandTimeout = 0;

                //Lazy Loading
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;

                //consulta 
                var queryEmpleadoPorDepartamento = (from Empleado in db.Empleado
                                                    join Departamento in db.Departamento
                                                    on Empleado.CodigoDepartamento equals Departamento.CodigoDepartamento

                                                    group Empleado by Departamento into agrupacion
                                                    where agrupacion.Key.Departamento1.Contains(departamento)
                                                    select new
                                                    {
                                                        CodigoDepartamento = agrupacion.Key.CodigoDepartamento,
                                                        agrupacion.Key.Departamento1,
                                                        NoEmpleados = agrupacion.Count()
                                                    }).ToList();

                if (queryEmpleadoPorDepartamento != null)
                {
                    return Ok(queryEmpleadoPorDepartamento);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                return InternalServerError(ex.GetBaseException());
            }
        }
    }
}
