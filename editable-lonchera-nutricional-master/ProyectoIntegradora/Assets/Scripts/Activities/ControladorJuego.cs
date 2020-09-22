﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour {
    public ContadorAlimentos alimentos;
    public ContadorPuntaje contP;
    public Animator ani,transicion;
    public GameObject img, mano;
    public new ControladorAudio audio;
    public Registro registro;
    public ControladorBandera bandera;
    public LevelMetaData levelData;
    public void IrMenu(string nombre)
    {
        // SceneManager.LoadScene(nombre);
        registro.abandonan++;
        audio = FindObjectOfType<ControladorAudio>();
        audio.playClic();
        bandera.niv1 = false;
        bandera.niv2 = false;
        bandera.niv3 = false;
        /*
        alimentos.manzana = 0;
        alimentos.frutilla = 0;
        alimentos.guineo = 0;
        alimentos.mandarina = 0;
        alimentos.uva = 0;
        alimentos.zanahoria = 0;
        alimentos.sanduche = 0;
        alimentos.tortillaverde = 0;
        alimentos.maduroasado = 0;
        alimentos.huevodeoro = 0;
        alimentos.queso = 0;
        alimentos.brocoli = 0;
        alimentos.pepino = 0;
        alimentos.tomate = 0;
        alimentos.leche = 0;
        alimentos.aguacate = 0;*/
        StartCoroutine(Transicion());
        // print("Cambiando a Escena Menu");
    }

    public void GameOver()
    {
        EndLevel("perdido");
        SceneManager.LoadScene("Gameover");
       // print("Has perdido");
    }

    public void Lonchera()
    {
        SceneManager.LoadScene("Lonchera");
        //  print("Cambiando a Escena Lonchera");
    }
    public void Felicitaciones()
    {
        EndLevel("completado");
        SceneManager.LoadScene("Felicitaciones");
        //  print("Cambiando a Escena Lonchera");
    }

    public void conLonchera()
    {
        
        SceneManager.LoadScene("Consejolonchera");

        //  print("Cambiando a Escena Lonchera");
    }

    IEnumerator cargarEscena()
    {
        yield return new WaitForSecondsRealtime(2f);
        mano = GameObject.Find("mano_manzana");
        ani = mano.GetComponent<Animator>();
        ani.SetTrigger("start");
    }

    IEnumerator Transicion()
    {
        //transicion.SetTrigger("end");
        yield return new WaitForSeconds(0.2f);
        EndLevel("abandonado");
        SceneManager.LoadScene("Niveles");
        //SceneManager.LoadScene("Menuinicio");
    }

    // Use this for initialization
    void Start () {
        bandera = FindObjectOfType<ControladorBandera>();
        registro = FindObjectOfType<Registro>();
        alimentos = FindObjectOfType<ContadorAlimentos>();
        contP = FindObjectOfType<ContadorPuntaje>();
        if (SceneManager.GetSceneByName("Juego").isLoaded)
        {
            bandera.tempNombre = "Juego";
            //EndLevel("completado");
            levelData = new LevelMetaData(SessionManager.Instance.nombre_jugador, "Lonchera Básica Activity 1", "Captura alimentos saludable - Lento");
        }
        else if (SceneManager.GetSceneByName("Juego2").isLoaded)
        {
            bandera.tempNombre = "Juego2";
            //EndLevel("completado");
            levelData = new LevelMetaData(SessionManager.Instance.nombre_jugador, "Lonchera Básica Activity 2","Captura alimentos saludable - Medio");
        }
        else if (SceneManager.GetSceneByName("Juego3").isLoaded)
        {
            bandera.tempNombre = "Juego3";
            //EndLevel("completado");
            levelData = new LevelMetaData(SessionManager.Instance.nombre_jugador, "Lonchera Básica Activity 3", "Captura alimentos saludable - Rapido");
        }
        //  savedata.SaveData();
        //  if (contP.bandera == false)
        //  {
        // StartCoroutine(cargarEscena());
        //contP.bandera = true;
        //  }


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(1f);
        // do something
    }

      public void EndLevel(string status)
    {

        levelData.estado = status;
        levelData.fecha_fin = System.DateTime.Now.ToString("yyyy/MM/dd");
        levelData.tiempo_juego = System.Math.Round(Time.timeSinceLevelLoad).ToString();
        levelData.puntaje = contP.puntaje.ToString();
        levelData.correctas = contP.score.ToString();
        levelData.incorrectas = contP.errors.ToString();
        GameStateManager.Instance.AddJsonToList(JsonUtility.ToJson(levelData));
        //GameStateManager.Instance.LoadScene("ActivityHub");
    }
}
