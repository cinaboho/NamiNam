using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controladormenu : MonoBehaviour {

    public Animator transicion;
    public ControladorBandera bandera;
    public Registro registro;
  //  public saveData savedata;

    public AudioSource sourceHome,audioClicr;

    public void IrEscenaJugar()
    {
        registro.clicJugar++;
        audioClicr.Play();
       // bandera.tempNombre = "Juego";
        StartCoroutine(Transicion("Cargaconsejo"));
       // SceneManager.LoadScene("Cargaconsejo");
    }

    public void Salir()
    {
        audioClicr.Play();
        Application.Quit();
    }

    public void IrTutorial(string nombre)
    {
        audioClicr.Play();
        StartCoroutine(Transicion("Video"));
    }

    public void Mute()
    {
        audioClicr.Play();
        AudioListener.pause = true;
        AudioListener.volume = 0;
    }

    public void IrEscenaCreditos()
    {
        registro.clicCreditos++;
        audioClicr.Play();
        StartCoroutine(Transicion("Creditos"));
    }

    // Use this for initialization
    void Start () {
        //StartCoroutine(cargarEscena());
        bandera = FindObjectOfType<ControladorBandera>();
        registro = FindObjectOfType<Registro>();
       // savedata = FindObjectOfType<saveData>();
      //  savedata.SaveData();
       // sourceHome.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator Transicion(string scene)
    {
        //transicion.SetTrigger("end");
        yield return new WaitForSeconds(0.1f);
        /*if (scene == "Juego")
        {
          
            SceneManager.LoadScene(scene);
        }*/

        if (scene == "Creditos")
        {
            SceneManager.LoadScene(scene);
        }

        else if (scene == "Cargaconsejo")
        {
            SceneManager.LoadScene(scene);
        }
        else if (scene == "Video")
        {
            SceneManager.LoadScene(scene);
        }
    }

    IEnumerator cargarEscena()
    {
        yield return new WaitForSecondsRealtime(2f);


        // mano = GameObject.Find("mano_manzana");
        //ani = mano.GetComponent<Animator>();
        //ani.SetTrigger("start");
    }


}
