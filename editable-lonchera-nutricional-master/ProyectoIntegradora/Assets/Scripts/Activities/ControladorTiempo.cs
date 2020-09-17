using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorTiempo : MonoBehaviour {
    [SerializeField] public Text tiempoText;
    [SerializeField] public float tiempo= 0.0f;
    public ControladorJuego juego;
    public ControladorBandera bandera;
    // public Consejolonchera cLon;
    //public ContadorPuntaje contP;
    public ContadorAlimentos ali;
    public Color red;
    public Animator animtiempo;
    public bool comenzar = false;

    // Use this for initialization
    void Start () {
        bandera = FindObjectOfType<ControladorBandera>();
        //tiempoText.text = tiempo.ToString("f");
        /*  contP = FindObjectOfType<ContadorPuntaje>();
          if (contP.bandera == false)
          {*/
        StartCoroutine(Esperar(2f));
           /* contP.bandera = true;
        }
        else
        {
            comenzar = true;
            StartCoroutine(Esperar(5f));
        }*/
           
        animtiempo = tiempoText.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (comenzar == true){

            if (tiempo <= 0)
            {
                tiempo = 0f;
                tiempoText.text = "00:00";
                StartCoroutine(Transicion());
            }
            else
            {

                // print(tiempo);
                // tiempo = Mathf.Round(tiempo);
                if (Convert.ToInt32(tiempo) <= 5f && Convert.ToInt32(tiempo) >= 0f)
                {
                    animtiempo.SetTrigger("tiempolimite");
                    // print(Convert.ToInt32(tiempo));
                    tiempoText.color = red;

                }

                tiempo -= Time.deltaTime;
                // tiempo = tiempo-1f;
                if (Convert.ToInt32(tiempo) > 9)
                {
                    tiempoText.text ="00:" +tiempo.ToString("0");
                }
                else
                {
                    tiempoText.text = "00:0" + tiempo.ToString("0");
                }
              
              
            }
        }
      


    }

    IEnumerator Esperar(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        comenzar = true;
    }

    public void incrementarTiempo()
    {
        tiempo += 2f;
       // tiempoText.text = tiempo.ToString("f");
        print("incrementando --"+ tiempo);
        //print("valor "+ tiempo);
    }

    public void restarTiempo()
    {
        tiempo -= 7f;

        if (tiempo <= 0)
        {
            tiempo = 0f;
            juego = FindObjectOfType<ControladorJuego>();
            juego.GameOver();
        }
        else
        {
            print("Restando --" + tiempo);
        }
        
    }
    public void restarTiempo(int num)
    {
        tiempo -= num;

        if (tiempo <= 0)
        {
            tiempo = 0f;
            juego = FindObjectOfType<ControladorJuego>();
            juego.GameOver();
        }
        else
        {
            print("Restando --" + tiempo);
        }

    }

    IEnumerator Transicion()
    {
        if (SceneManager.GetSceneByName("Juego").isLoaded)
        {
            bandera.niv1 = true;
        }
        else if (SceneManager.GetSceneByName("Juego2").isLoaded)
        {
            bandera.niv2 = true;
        }
        else  if (SceneManager.GetSceneByName("Juego3").isLoaded)
        {
                bandera.niv3 = true;
        }

        juego = FindObjectOfType<ControladorJuego>();
        ali = FindObjectOfType<ContadorAlimentos>();
        // juego.transicion.SetTrigger("end");
        yield return new WaitForSeconds(0.2f);
        
        if (bandera.niv2 == true && bandera.niv1 == true && bandera.niv3 == true)
        {
                SceneManager.LoadScene("Felicitaciones2");
        }
        else
        {
            juego.Felicitaciones();
        }
        
        /*  if ((ali.manzana*50 + ali.frutilla*25 + ali.guineo*50 + ali.mandarina*50 + ali.uva * 25 + ali.zanahoria * 50
              + ali.brocoli * 25 + ali.pepino * 50 + ali.tomate * 50 + ali.aguacate * 50 >= 100) &&
              (ali.maduroasado*50 + ali.sanduche * 50 + ali.tortillaverde * 50 >= 100)&&
              (ali.queso * 50 + ali.huevodeoro * 50 + ali.leche * 50 >= 100))
          {
              // juego.Lonchera();
              juego.Felicitaciones();
          }
          else
          {
              print("No has obtenido suficiente alimentos");
              juego.GameOver();
          }

          */

        // SceneManager.LoadScene("Menuinicio");
    }
}
