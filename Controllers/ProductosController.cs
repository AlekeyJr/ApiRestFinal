using Microsoft.AspNetCore.Mvc;
using System.Linq;
using pr_web_api_empresa.Models;
namespace pr_web_api_empresa.Controllers{
[Route("api/[controller]")]
    public class productosController : Controller{
        private Conexion dbConexion;
        public productosController(){
            dbConexion = Conectar.Create();
        }
        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConexion.Productos.ToArray());
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id){
            var productos = dbConexion.Productos.SingleOrDefault(a => a.idProducto ==id);
            if (productos !=null){
                return Ok(productos); 
            }else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Productos productos){

            if (ModelState.IsValid){
                dbConexion.Productos.Add(productos);
                dbConexion.SaveChanges();
                return Ok(productos);
            }else{
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody]Productos productos){
            var v_productos = dbConexion.Productos.SingleOrDefault(a => a.idProducto == productos.idProducto);
            if(v_productos !=null && ModelState.IsValid){
                dbConexion.Entry(v_productos).CurrentValues.SetValues(productos);
                dbConexion.SaveChanges();
                return Ok();
            }else{
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            var productos = dbConexion.Productos.SingleOrDefault(a => a.idProducto == id);
            if (productos !=null){
                dbConexion.Productos.Remove(productos);
                dbConexion.SaveChanges();
                 return Ok();
            }else{
                return NotFound();
            }

        }
    }

}