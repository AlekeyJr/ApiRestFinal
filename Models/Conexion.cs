using Microsoft.EntityFrameworkCore;
namespace pr_web_api_empresa.Models{
class Conexion : DbContext{
    public Conexion (DbContextOptions<Conexion> options) : base(options){}
    public DbSet<Productos> Productos {get;set;}
}
class Conectar{
    private const string cadenaConexion="server=proyectofinalapi.mysql.database.azure.com;port=3306;database=dbempresa;userid=WebApi@proyectofinalapi;pwd=Web@p1F1n@l";
    public static Conexion Create(){
        var constructor = new DbContextOptionsBuilder<Conexion>();
        constructor.UseMySQL(cadenaConexion);
        var cn = new Conexion(constructor.Options);
        return cn;

    }

}
}