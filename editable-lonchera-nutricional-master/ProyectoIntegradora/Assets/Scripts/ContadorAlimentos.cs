using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorAlimentos : MonoBehaviour {

    public int manzana;
    public int frutilla;
    public int guineo;
    public int mandarina;
    public int uva;
    public int zanahoria;
    public int sanduche;
    public int tortillaverde;
    public int maduroasado;
    public int huevodeoro;
    public int queso;
    public int brocoli;
    public int pepino;
    public int tomate;
    public int leche;
    public int aguacate;
    //string[] listaAlimentos;
    public List<string> listaAlimentos = new List<string>();
    //public List<int> listAlimentos = new List<int>();

    // Use this for initialization
    void Start () {
        //Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }



    }

    // Update is called once per frame
    void Update () {
		
	}

    public void IncrementarAlimentos(string tag)
    {
        if (tag == "manzana")
        {
            manzana += 1;
            //  listaAlimentos,
            if (listaAlimentos.Contains("manzana"))
            {
               // print("ya existe ese alimento");
            }
            else
            {
                //print("agregando nuevo alimento");
                listaAlimentos.Add("manzana");
            }
           
        }

        if (tag == "frutilla")
        {
            frutilla += 1;
            if (listaAlimentos.Contains("frutilla"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("frutilla");
            }
        }

        if (tag == "guineo")
        {
            guineo += 1;
            if (listaAlimentos.Contains("guineo"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("guineo");
            }
        }

        if (tag == "mandarina")
        {
            mandarina += 1;
            if (listaAlimentos.Contains("mandarina"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("mandarina");
            }
        }

        if (tag == "uva")
        {
            uva += 1;
            if (listaAlimentos.Contains("uva"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("uva");
            }
        }

        if (tag == "zanahoria")
        {
            zanahoria += 1;
            if (listaAlimentos.Contains("zanahoria"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("zanahoria");
            }
        }

        if (tag == "sanduche")
        {
            sanduche += 1;
            if (listaAlimentos.Contains("sanduche"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("sanduche");
            }
        }

        if (tag == "tortillaverde")
        {
            tortillaverde += 1;
            if (listaAlimentos.Contains("tortillaverde"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("tortillaverde");
            }
        }

        if (tag == "maduroasado")
        {
            maduroasado += 1;
            if (listaAlimentos.Contains("maduroasado"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("maduroasado");
            }
        }

        if (tag == "huevodeoro")
        {
            huevodeoro += 1;
            if (listaAlimentos.Contains("huevodeoro"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("huevodeoro");
            }
        }

        if (tag == "queso")
        {
            queso += 1;
            if (listaAlimentos.Contains("queso"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("queso");
            }
        }

        if (tag == "brocoli")
        {
            brocoli += 1;
            if (listaAlimentos.Contains("brocoli"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("brocoli");
            }
        }

        if (tag == "pepino")
        {
            pepino += 1;
            if (listaAlimentos.Contains("pepino"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("pepino");
            }
        }

        if (tag == "tomate")
        {
            tomate += 1;
            if (listaAlimentos.Contains("tomate"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("tomate");
            }
        }

        if (tag == "leche")
        {
            leche += 1;
            if (listaAlimentos.Contains("leche"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("leche");
            }
        }

        if (tag == "aguacate")
        {
            aguacate += 1;
            if (listaAlimentos.Contains("aguacate"))
            {
                // print("ya existe ese alimento");
            }
            else
            {
                listaAlimentos.Add("aguacate");
            }
        }


        //print("incrementado puntaje= " + puntaje);
    }
}
