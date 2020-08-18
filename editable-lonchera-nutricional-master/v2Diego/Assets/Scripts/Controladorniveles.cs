using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controladorniveles : MonoBehaviour {

    public Registro registro;
    public ControladorBandera bandera;
    public AudioSource sourceNiveles, audioClic;
    public ContadorPuntaje puntaje;
    public ContadorAlimentos ali;
    // Use this for initialization

    // Update is called once per frame

    public void IrNivel1()
    {
        bandera.tempNombre = "Juego";
        //  registro.clicJugar++;
        puntaje.puntaje = 0;
        audioClic.Play();
        StartCoroutine(Transicion("Juego"));
       
    }

    public void IrNivel2()
    {
        puntaje.puntaje = 0;
        bandera.tempNombre = "Juego2";
        //  registro.clicJugar++;
        audioClic.Play();
        StartCoroutine(Transicion("Juego2"));
      
    }

    public void IrNivel3()
    {
        puntaje.puntaje = 0;
        //  registro.clicJugar++;
        bandera.tempNombre = "Juego3";
        audioClic.Play();
        StartCoroutine(Transicion("Juego3"));
        
    }

    public void conLonchera()
    {
        audioClic.Play();
        SceneManager.LoadScene("Consejolonchera");

        //  print("Cambiando a Escena Lonchera");
    }

    public void IrMenu()
    {
        audioClic.Play();
        puntaje.puntaje = 0;
        StartCoroutine(Transicion("Menuinicio"));
    }


    public void Salir()
    {
        audioClic.Play();
        Application.Quit();
    }

    public void IrTutorial(string nombre)
    {
        audioClic.Play();
        SceneManager.LoadScene(nombre);
    }


    // Use this for initialization
    void Start()
    {
        bandera = FindObjectOfType<ControladorBandera>();
        puntaje = FindObjectOfType<ContadorPuntaje>();
        //   registro = FindObjectOfType<Registro>();

        ali = FindObjectOfType<ContadorAlimentos>();
 
       if ((ali.manzana*50 + ali.frutilla*25 + ali.guineo*50 + ali.mandarina*50 + ali.uva * 25 + ali.zanahoria * 50
              + ali.brocoli * 25 + ali.pepino * 50 + ali.tomate * 50 + ali.aguacate * 50 >= 100) &&
              (ali.maduroasado*50 + ali.sanduche * 50 + ali.tortillaverde * 50 >= 100)&&
              (ali.queso * 50 + ali.huevodeoro * 50 + ali.leche * 50 >= 100) && (bandera.niv1==true && bandera.niv2 == true && bandera.niv3 == true))
          {
            GameObject.Find("Bonus").GetComponent<Button>().enabled = true;
            GameObject.Find("Bonus").GetComponent<Image>().enabled = true;
            GameObject.Find("efecto").GetComponent<ParticleSystem>().Play();

        }
          else
          {
            GameObject.Find("Bonus").GetComponent<Image>().enabled = false;
            GameObject.Find("Bonus").GetComponent<Button>().enabled = false;
            GameObject.Find("efecto").GetComponent<ParticleSystem>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Transicion(string scene)
    {
        //transicion.SetTrigger("end");
        yield return new WaitForSeconds(0.1f);
        /*if (scene == "Juego")
        {
          
            SceneManager.LoadScene(scene);
        }*/

        if (scene == "Juego")
        {
            SceneManager.LoadScene(scene);
        }

        else if (scene == "Juego2")
        {
            SceneManager.LoadScene(scene);

        }
        else if (scene == "Juego3")
        {
            SceneManager.LoadScene(scene);

        }
        else if (scene == "Menuinicio")
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
