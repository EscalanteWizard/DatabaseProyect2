using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Usuario usuario){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registro_profesor_grupo";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@periodo",System.Data.SqlDbType.int).Value=profesor_grupo.numero_periodo;
        comando.Parameters.Add("@anho_periodo",System.Data.SqlDbType.int).Value=profesor_grupo.anho_periodo;
        comando.Parameters.Add("@nombre_materia",System.Data.SqlDbType.varchar,50).Value=profesor_grupo.nombre_materia;
        comando.Parameters.Add("@grado",System.Data.SqlDbType.int).Value=profesor_grupo.grado;
        comando.Parameters.Add("@grupo",System.Data.SqlDbType.varchar,50).Value=profesor_grupo.grupo;
        comando.Parameters.Add("@profesor",System.Data.SqlDbType.int).Value=profesor_grupo.profesor;
        comando.ExecuteNonQuery();
        conexion.Close(); //cierre de la conexión
    }
}