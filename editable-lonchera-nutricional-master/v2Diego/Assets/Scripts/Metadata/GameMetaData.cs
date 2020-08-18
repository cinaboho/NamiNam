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

    public string fecha_inicio;
    public string fecha_fin;

    public string tiempo_juego;
    public string estado;


    public GameMetaData(string id_registro)
    {
        this.id_registro = id_registro;

        nombre_juego = SessionManager.Instance.nombre_juego;
        descripcion_juego = "bla bla";
        nombre_capitulo = "Lonchera Nutricional";
        descripcion_capitulo = "bla bla";
        nombre_historia = "Lonchera Nutricional";

        fecha_inicio = System.DateTime.Now.ToString("yyyy/MM/dd");

        estado = "abandonado";
    }

}
