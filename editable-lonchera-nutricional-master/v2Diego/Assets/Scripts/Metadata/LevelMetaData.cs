using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelMetaData : GameMetaData //LevelMetaData hereda de GameMetaData
{
    public string nombre_nivel;
    public string descripcion_nivel;
    public string correctas;
    public string incorrectas;



	public LevelMetaData(string id_registro, string nombre_nivel) : base(id_registro)
    {
        tipo = "juego";
        this.nombre_nivel = nombre_nivel;
        descripcion_nivel = "Sigue las instrucciones que te da Ñami";
        correctas = "0";
        incorrectas = "0";
}

}


