using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPuntaje : MonoBehaviour {
    [SerializeField] public Text puntajeText;
    [SerializeField] public Text puntosfloat;
    public ContadorPuntaje contP;

    //public GameObject pun;
    // Use this for initialization
    void Start () {

        
    }

    


    // Update is called once per frame
    void Update () {
        //puntosfloat.text = "" + 00;
        // puntajeText= GameObject.Find("poptext");
        // pun = GameObject.Find("puntaje");
        contP = FindObjectOfType<ContadorPuntaje>();
        puntajeText.text = contP.puntaje + " pts";
       
        
    }

    public void IncrementarPuntaje(string tag)
    {

        if (tag == "manzana" || tag == "guineo" || tag == "mandarina" || tag == "uva" || tag == "maduroasado")
        {
            contP.puntaje += 10f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "frutilla")
        {
            contP.puntaje += 10f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "zanahoria")
        {
            contP.puntaje += 10f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "sanduche")
        {
            contP.puntaje += 10f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "tortillaverde")
        {
            contP.puntaje += 10f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "huevodeoro")
        {
            contP.puntaje += 10f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "queso")
        {
            contP.puntaje += 10f;
             //contP.puntaje -= 20f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "brocoli")
        {
            contP.puntaje += 10f;
            //contP.puntaje -= 20f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "pepino")
        {
            contP.puntaje += 10f;
            //contP.puntaje -= 20f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "tomate")
        {
            contP.puntaje += 10f;
            //contP.puntaje -= 20f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "leche")
        {
            contP.puntaje += 10f;
            //contP.puntaje -= 20f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "aguacate")
        {
            contP.puntaje += 10f;
            //contP.puntaje -= 20f;
            puntosfloat.text = "+10 pts";
        }

        if (tag == "chatarra")
        {
            contP.puntaje += 20f;
            puntosfloat.text = "+20 pts";
        }



        // puntosfloat = 10;
        //print("incrementado puntaje= " + puntaje);
    }

    public void RestarPuntaje(string tag)
    {
        if (tag == "chatarra")
        {
           
            contP.puntaje -= 20f;

            if (contP.puntaje <= 0)
            {
                contP.puntaje = 0f;
            }
            else if (contP.puntaje > 0)
            {
                // puntaje -= 50f;
            }
            puntosfloat.text = "-20 pts";
        }

    }
}
