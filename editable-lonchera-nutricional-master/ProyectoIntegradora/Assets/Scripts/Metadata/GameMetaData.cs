using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class GameMetaData {

    public string tipo;
    public string id_registro;

    public string nombre_juego;
    public string descripcion_juego;
    public string nombre_capitulo;
    public string descripcion_capitulo;
    public string nombre_historia;

    public string fecha_inicio;         //":"2018/01/31",
    public string fecha_fin;            //":"2018/01/31",

    public string tiempo_juego;         //en segundos
    public string estado;               //completado o abandonado


    public GameMetaData(string id_registro)
    {
        this.id_registro = id_registro;

        nombre_juego = SessionManager.Instance.nombre_juego;
        descripcion_juego = "Nami Nam";
        nombre_capitulo = "Primera parte";
        descripcion_capitulo = "En Nami Nam, los ninos aprenderan sobre alimentos saludables y sobre una lonchera balanceada";
        nombre_historia = "Historia-Nami Nam";

        fecha_inicio = System.DateTime.Now.ToString("yyyy/MM/dd");

        estado = "abandonado";
    }

}
