using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controladorlonchera : MonoBehaviour {
    public ContadorAlimentos alimentos;
    public ContadorPuntaje contP;
    public ControladorVidas vidas;
    public Animator transicion,ani;
    public GameObject anilon;
    public Text textpuntaje;
    public int rep;
    public new Audiolonchera audio;
    public Registro registro;
    public AudioSource audioClic;
    public ControladorBandera bandera;

    [SerializeField] public Text textmanzana,textfrutilla,txthuevo,txtmaduro,txtmandarina,txtplatano,txtqueso,txtsanduche,txttortilla,txtuvas,txtzanahoria,txtbrocoli,txtpepino,txttomate,txtleche,txtaguacate;
    public GameObject prefabmanzana,prefabfrutilla,prefabhuevo,prefabmaduro,prefabmandarina,prefabplatano,prefabqueso,prefabsanduche,prefabtortilla,prefabuvas,prefabzanahoria,prefabbtnlonchera,prefabbrocoli,prefabpepino,prefabtomate,prefableche,prefabaguacate;
    public int constructor,regulador,energetico;
    [SerializeField] public Text textlonchera;
    public string loncheraString;
    public int temp,PosX, PosY,txtPos, confila;
    public int manzanaLon,frutillaLon,huevoLon,maduroLon,mandarinaLon,guineoLon,quesoLon,sanducheLon,tortillaLon,uvaLon,zanahoriaLon,brocoliLon,pepinoLon,tomateLon,lecheLon,aguacateLon,maxLon;
    public int manzanaTemp, frutillaTemp, huevoTemp, maduroTemp, mandarinaTemp, guineoTemp, quesoTemp, sanducheTemp, tortillaTemp, uvaTemp, zanahoriaTemp, brocoliTemp, pepinoTemp, tomateTemp, lecheTemp, aguacateTemp;

    //public List<int> milonchera = new List<int>();
    public int[] milonchera = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    // ORDEN ARRAY MILONCHERA : manzana. frutilla, guineo, mandarina, uva, zanahoria, maduro asado, sanduche, tortilla verde, queso, huevo
    public Vector3 vecManzana,vecFrutilla,vecHuevo,vecUva,vecMaduro,vecMandarina,vecGuineo,vecZanahoria,vecTortilla,vecSanduche,vecQueso,vecBrocoli,vecPepino,vecTomate,vecLeche,vecAguacate;

    // Use this for initialization
    //private Vector2 initialPosition;
    void Start () {
        registro = FindObjectOfType<Registro>();
        registro.lleganLonchera++;
        alimentos = FindObjectOfType<ContadorAlimentos>();
        contP = FindObjectOfType<ContadorPuntaje>();
        vidas = FindObjectOfType<ControladorVidas>();
        audio = FindObjectOfType<Audiolonchera>();
        bandera = FindObjectOfType<ControladorBandera>();
        textpuntaje.text = "" + contP.puntaje + " ptos";

        bandera.niv1 = false;
        bandera.niv2 = false;
        bandera.niv3 = false;

        GameObject.Find("Reguladores-seleccionado").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Constructores-seleccionado").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Energeticos-seleccionado").GetComponent<Renderer>().enabled = false;

        GameObject.Find("Reguladores-parte1").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Reguladores-parte2").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Reguladores-parte3").GetComponent<Renderer>().enabled = false;

        GameObject.Find("Constructores-parte1").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Constructores-parte2").GetComponent<Renderer>().enabled = false;

        GameObject.Find("Energeticos-parte1").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Energeticos-parte2").GetComponent<Renderer>().enabled = false;

        
        manzanaTemp = alimentos.manzana;
        frutillaTemp = alimentos.frutilla;
        guineoTemp = alimentos.guineo;
        mandarinaTemp = alimentos.mandarina;
        uvaTemp = alimentos.uva;
        zanahoriaTemp = alimentos.zanahoria;
        sanducheTemp = alimentos.sanduche;
        tortillaTemp = alimentos.tortillaverde;
        maduroTemp = alimentos.maduroasado;
        huevoTemp = alimentos.huevodeoro;
        quesoTemp = alimentos.queso;
        brocoliTemp = alimentos.brocoli;
        pepinoTemp = alimentos.pepino;
        tomateTemp = alimentos.tomate;
        lecheTemp = alimentos.leche;
        aguacateTemp = alimentos.aguacate;
        

        textmanzana.text = alimentos.manzana+"";
        textfrutilla.text = alimentos.frutilla + "";
        txthuevo.text = alimentos.huevodeoro + "";
        txtmaduro.text = alimentos.maduroasado + "";
        txtmandarina.text = alimentos.mandarina + "";
        txtplatano.text = alimentos.guineo + "";
        txtqueso.text = alimentos.queso + "";
        txtsanduche.text = alimentos.sanduche + "";
        txttortilla.text = alimentos.tortillaverde + "";
        txtuvas.text = alimentos.uva + "";
        txtzanahoria.text = alimentos.zanahoria + "";
        txtbrocoli.text = alimentos.brocoli + "";
        txtpepino.text = alimentos.pepino + "";
        txttomate.text = alimentos.tomate + "";
        txtleche.text = alimentos.leche + "";
        txtaguacate.text = alimentos.aguacate + "";
        // GameObject.Find("btnlonchera").GetComponent<Image>().enabled = false;

        CrearAlimentos();


    }

    public void CrearAlimentos()
    {
        foreach (string obj in alimentos.listaAlimentos)
        {

            if (confila < 6)
            {
                PosY = 18;
                txtPos = 50;
            }
            else if (confila >= 6)
            {
                if (confila == 6)
                {
                    PosX = 0;
                }

                PosY = -90;
                txtPos = -55;
            }

            if (obj == "manzana")
            {
                confila++;
                GameObject prefab = Instantiate(prefabmanzana, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecManzana = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecManzana;
                textmanzana.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "frutilla")
            {
                confila++;
                GameObject prefab = Instantiate(prefabfrutilla, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecFrutilla = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecFrutilla;
                textfrutilla.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "huevodeoro")
            {
                confila++;
                GameObject prefab = Instantiate(prefabhuevo, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecHuevo = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecHuevo;
                txthuevo.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "uva")
            {
                confila++;
                GameObject prefab = Instantiate(prefabuvas, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecUva = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecUva;
                txtuvas.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "maduroasado")
            {
                confila++;
                GameObject prefab = Instantiate(prefabmaduro, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecMaduro = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecMaduro;
                txtmaduro.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "mandarina")
            {
                confila++;
                GameObject prefab = Instantiate(prefabmandarina, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecMandarina = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecMandarina;
                txtmandarina.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "guineo")
            {
                confila++;
                GameObject prefab = Instantiate(prefabplatano, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecGuineo = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecGuineo;
                txtplatano.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "zanahoria")
            {
                confila++;
                GameObject prefab = Instantiate(prefabzanahoria, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecZanahoria = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecZanahoria;
                txtzanahoria.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "sanduche")
            {
                confila++;
                GameObject prefab = Instantiate(prefabsanduche, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecSanduche = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecSanduche;
                txtsanduche.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "tortillaverde")
            {
                confila++;
                GameObject prefab = Instantiate(prefabtortilla, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecTortilla = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecTortilla;
                txttortilla.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "queso")
            {
                confila++;
                GameObject prefab = Instantiate(prefabqueso, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecQueso = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecQueso;
                txtqueso.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "brocoli")
            {
                confila++;
                GameObject prefab = Instantiate(prefabbrocoli, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecBrocoli = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecBrocoli;
                txtbrocoli.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "pepino")
            {
                confila++;
                GameObject prefab = Instantiate(prefabpepino, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecPepino = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecPepino;
                txtpepino.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "tomate")
            {
                confila++;
                GameObject prefab = Instantiate(prefabtomate, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecTomate = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecTomate;
                txttomate.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "leche")
            {
                confila++;
                GameObject prefab = Instantiate(prefableche, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecLeche = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecLeche;
                txtleche.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

            if (obj == "aguacate")
            {
                confila++;
                GameObject prefab = Instantiate(prefabaguacate, transform.position, transform.rotation) as GameObject;
                prefab.transform.SetParent(GameObject.Find("Canvas").transform);
                vecAguacate = new Vector3(-320 + PosX, PosY, 12);
                prefab.transform.localPosition = vecAguacate;
                txtaguacate.transform.localPosition = new Vector3(-350 + PosX, txtPos, 0);
                PosX = PosX + 70;
            }

        }
        confila = 0;
    }

    public void RestaurarAlimentos()
    {
        if(manzanaTemp > 0 && alimentos.manzana<1)
        {
            crearManzana();
        }
        if (frutillaTemp > 0 && alimentos.frutilla < 1)
        {
            crearFrutilla();
        }
        if (guineoTemp > 0 && alimentos.guineo < 1)
        {
            crearPlatano();
        }
        if (mandarinaTemp > 0 && alimentos.mandarina < 1)
        {
            crearMandarina();
        }
        if (uvaTemp > 0 && alimentos.uva < 1)
        {
            crearUva();
        }
        if (zanahoriaTemp > 0 && alimentos.zanahoria < 1)
        {
            crearZanahoria();
        }
        if (sanducheTemp > 0 && alimentos.sanduche < 1)
        {
            crearSanduche();
        }
        if (tortillaTemp > 0 && alimentos.tortillaverde < 1)
        {
            crearTortilla();
        }
        if (maduroTemp > 0 && alimentos.maduroasado < 1)
        {
            crearMaduro();
        }
        if (quesoTemp > 0 && alimentos.queso < 1)
        {
            crearQueso();
        }
        if (brocoliTemp > 0 && alimentos.brocoli < 1)
        {
            crearBrocoli();
        }
        if (pepinoTemp > 0 && alimentos.pepino < 1)
        {
            crearPepino();
        }
        if (tomateTemp > 0 && alimentos.tomate < 1)
        {
            crearTomate();
        }
        if (lecheTemp > 0 && alimentos.leche < 1)
        {
            crearLeche();
        }
        if (aguacateTemp > 0 && alimentos.aguacate < 1)
        {
            crearAguacate();
        }
        if (huevoTemp > 0 && alimentos.huevodeoro < 1)
        {
            crearHuevo();
        }


    }

    public void LimpiarVariables()
    {

    }

    IEnumerator Transicion(string scene)
    {
        //transicion.SetTrigger("end");

        if (scene == "Juego")
        {
            registro.abandonan++;
            audio.playClic();
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(scene);
            //LIMPIAR VARIABLES
            alimentos.listaAlimentos.Clear();
            contP.puntaje = 0;
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
            alimentos.aguacate = 0;


            textmanzana.text = "";
            textfrutilla.text = "";
            txthuevo.text = "";
            txtmaduro.text = "";
            txtmandarina.text = "";
            txtplatano.text = "";
            txtqueso.text = "";
            txtsanduche.text = "";
            txttortilla.text = "";
            txtuvas.text = "";
            txtzanahoria.text = "";
            txtbrocoli.text = "";
            txtpepino.text = "";
            txttomate.text = "";
            txtleche.text = "";
            txtaguacate.text = "";
        }
        else if (scene == "Felicitaciones")
        {
            anilon = GameObject.Find("animacionlonchera");
            ani = anilon.GetComponent<Animator>();
            audio.playJackpot();
            ani.SetTrigger("start");
            yield return new WaitForSecondsRealtime(4.1f);
            SceneManager.LoadScene(scene);
            //LIMPIAR VARIABLES
          //  alimentos.listaAlimentos.Clear();
            // contP.puntaje = 0;
            /*  alimentos.manzana = 0;
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


            textmanzana.text = "";
            textfrutilla.text = "";
            txthuevo.text = "";
            txtmaduro.text = "";
            txtmandarina.text = "";
            txtplatano.text = "";
            txtqueso.text = "";
            txtsanduche.text = "";
            txttortilla.text = "";
            txtuvas.text = "";
            txtzanahoria.text = "";
            txtbrocoli.text = "";
            txtpepino.text = "";
            txttomate.text = "";
            txtleche.text = "";
            txtaguacate.text = "";

        }
        else if (scene == "Repetir")
        {
            GameObject.Find("Reguladores-parte1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Reguladores-parte2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Reguladores-parte3").GetComponent<Renderer>().enabled = false;

            GameObject.Find("Energeticos-parte1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Energeticos-parte2").GetComponent<Renderer>().enabled = false;

            GameObject.Find("Constructores-parte1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Constructores-parte2").GetComponent<Renderer>().enabled = false;
            anilon = GameObject.Find("animacionlonchera");
            ani = anilon.GetComponent<Animator>();
            ani.SetTrigger("start");
            yield return new WaitForSecondsRealtime(5f);

            ani.SetTrigger("stop");
            regulador = 0;
            energetico = 0;
            constructor = 0;
        }

        else if (scene == "Repetir2")
        {

            rep++;
            anilon = GameObject.Find("animacionlonchera");
            ani = anilon.GetComponent<Animator>();
            audio.playJackpot();
            ani.SetTrigger("start");

            yield return new WaitForSecondsRealtime(3.9f);
            GameObject.Find("Reguladores-parte1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Reguladores-parte2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Reguladores-parte3").GetComponent<Renderer>().enabled = false;

            GameObject.Find("Energeticos-parte1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Energeticos-parte2").GetComponent<Renderer>().enabled = false;

            GameObject.Find("Constructores-parte1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Constructores-parte2").GetComponent<Renderer>().enabled = false;
            ani.SetTrigger("stop");

            // yield return new WaitForSecondsRealtime(3f);
            yield return new WaitForSecondsRealtime(0.5f);

            RestaurarAlimentos();

            alimentos.manzana = manzanaTemp;
            alimentos.frutilla = frutillaTemp;
            alimentos.guineo = guineoTemp;
            alimentos.mandarina = mandarinaTemp;
            alimentos.uva = uvaTemp;
            alimentos.zanahoria = zanahoriaTemp;
            alimentos.sanduche = sanducheTemp;
            alimentos.tortillaverde = tortillaTemp;
            alimentos.maduroasado = maduroTemp;
            alimentos.huevodeoro = huevoTemp;
            alimentos.queso = quesoTemp;
            alimentos.brocoli = brocoliTemp;
            alimentos.pepino = pepinoTemp;
            alimentos.tomate = tomateTemp;
            alimentos.leche = lecheTemp;
            alimentos.aguacate = aguacateTemp;

            regulador = 0;
            energetico = 0;
            constructor = 0;
            //vidas.contVidas = 3;
            // vidas.crearVidas();
        }
        else if (scene == "Felicitaciones2")
        {
            anilon = GameObject.Find("animacionlonchera");
            ani = anilon.GetComponent<Animator>();
            audio.playJackpot();
            ani.SetTrigger("start");
            yield return new WaitForSecondsRealtime(4.1f);
            SceneManager.LoadScene(scene);
            //LIMPIAR VARIABLES
          //  alimentos.listaAlimentos.Clear();
            // contP.puntaje = 0;
            /*  alimentos.manzana = 0;
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


            textmanzana.text = "";
            textfrutilla.text = "";
            txthuevo.text = "";
            txtmaduro.text = "";
            txtmandarina.text = "";
            txtplatano.text = "";
            txtqueso.text = "";
            txtsanduche.text = "";
            txttortilla.text = "";
            txtuvas.text = "";
            txtzanahoria.text = "";
            txtbrocoli.text = "";
            txtpepino.text = "";
            txttomate.text = "";
            txtleche.text = "";
            txtaguacate.text = "";

        }
        else if (scene == "Gracias")
        {
            anilon = GameObject.Find("animacionlonchera");
            ani = anilon.GetComponent<Animator>();
            audio.playJackpot();
            ani.SetTrigger("start");
            yield return new WaitForSecondsRealtime(4.1f);
            SceneManager.LoadScene(scene);

            alimentos.listaAlimentos.Clear();
            contP.puntaje = 0;
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
            alimentos.aguacate = 0;

            textmanzana.text = "";
            textfrutilla.text = "";
            txthuevo.text = "";
            txtmaduro.text = "";
            txtmandarina.text = "";
            txtplatano.text = "";
            txtqueso.text = "";
            txtsanduche.text = "";
            txttortilla.text = "";
            txtuvas.text = "";
            txtzanahoria.text = "";
            txtbrocoli.text = "";
            txtpepino.text = "";
            txttomate.text = "";
            txtleche.text = "";
            txtaguacate.text = "";

        }
        else if (scene == "Menuinicio")
        {
            alimentos.listaAlimentos.Clear();
            contP.puntaje = 0;
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
            alimentos.aguacate = 0;

            textmanzana.text = "";
            textfrutilla.text = "";
            txthuevo.text = "";
            txtmaduro.text = "";
            txtmandarina.text = "";
            txtplatano.text = "";
            txtqueso.text = "";
            txtsanduche.text = "";
            txttortilla.text = "";
            txtuvas.text = "";
            txtzanahoria.text = "";
            txtbrocoli.text = "";
            txtpepino.text = "";
            txttomate.text = "";
            txtleche.text = "";
            txtaguacate.text = "";
            audioClic.Play();
            yield return new WaitForSecondsRealtime(0.2f);
            SceneManager.LoadScene(scene);
        }

    }

    public void verificarLonchera()
    {
        if (regulador >= 100 && energetico >= 100 && constructor >= 100)
        {
            if (rep == 2)
            {
                registro.armanLonchera++;
                StartCoroutine(Transicion("Gracias"));
              
            }
            else
            {
                registro.armanLonchera++;
                StartCoroutine(Transicion("Repetir2"));
            }

            
          //  StartCoroutine(Transicion("Felicitaciones"));
            //GameObject.Find("btnlonchera").GetComponent<Image>().enabled = true;
        }
    }
	// Update is called once per frame
	void Update () {

        /*if (alimentos.manzana == 0 && alimentos.frutilla == 0 && alimentos.mandarina == 0 && alimentos.guineo == 0 && alimentos.uva == 0 && alimentos.zanahoria == 0
            && alimentos.maduroasado == 0 && alimentos.sanduche == 0 && alimentos.tortillaverde == 0 && alimentos.queso == 0 && alimentos.huevodeoro == 0 && alimentos.brocoli == 0
            && alimentos.pepino == 0 && alimentos.tomate == 0 && alimentos.aguacate == 0 && alimentos.leche == 0)
        {
            if (regulador >= 100 && energetico >= 100 && constructor >= 100)
            {
              
            }
            else
            {
               print("No has conseuido los alimentos suficientes");
                SceneManager.LoadScene("Gameover");
            }
         
        }*/
        /*
        else if(alimentos.leche == 0 && alimentos.huevodeoro == 0 && alimentos.queso == 0)
        {
            if (constructor >= 100)
            {

            }
            else
            {
                print("Te has quedado sin alimento constructores");
                SceneManager.LoadScene("Gameover");
            }
        }*/




        //textpuntaje.text = "" + contP.puntaje + " ptos";
        /*
        textlonchera.text = "";
        for (int i = 0; i < milonchera.Length; i++)
        {
            if (i == 0 && milonchera[0] > 0)
            {
              //  print("imprimiento manzanas");
                textlonchera.text = milonchera[0] + " manzanas" + "\r\n";
            }

            if (i == 1 && milonchera[1] > 0)
            {
               // print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[1] + " frutillas" + "\r\n";
            }

            if (i == 2 && milonchera[2] > 0)
            {
                //print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[2] + " guineo" + "\r\n";
            }

            if (i == 3 && milonchera[3] > 0)
            {
                //print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[3] + " mandarina" + "\r\n";
            }

            if (i == 4 && milonchera[4] > 0)
            {
                //print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[4] + " uvas" + "\r\n";
            }

            if (i == 5 && milonchera[5] > 0)
            {
                //print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[5] + " zanahoria" + "\r\n";
            }

            if (i == 6 && milonchera[6] > 0)
            {
                //print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[6] + " maduro asado" + "\r\n";
            }

            if (i == 7 && milonchera[7] > 0)
            {
                //print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[7] + " sanduche" + "\r\n";
            }

            if (i == 8 && milonchera[8] > 0)
            {
                //print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[8] + " tortilla de verde" + "\r\n";
            }

            if (i == 9 && milonchera[9] > 0)
            {
                //print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[9] + " queso" + "\r\n";
            }

            if (i == 10 && milonchera[10] > 0)
            {
                //print("imprimiento frutillas");
                textlonchera.text = textlonchera.text + milonchera[10] + " huevo" + "\r\n";
            }

            if (i == 11 && milonchera[11] > 0)
            {
               
                textlonchera.text = textlonchera.text + milonchera[11] + " brocoli" + "\r\n";
            }

            if (i == 12 && milonchera[12] > 0)
            {

                textlonchera.text = textlonchera.text + milonchera[12] + " pepino" + "\r\n";
            }

            if (i == 13 && milonchera[13] > 0)
            {

                textlonchera.text = textlonchera.text + milonchera[13] + " tomate" + "\r\n";
            }

            if (i == 14 && milonchera[14] > 0)
            {

                textlonchera.text = textlonchera.text + milonchera[14] + " aguacate" + "\r\n";
            }

            if (i == 15 && milonchera[15] > 0)
            {

                textlonchera.text = textlonchera.text + milonchera[15] + " leche" + "\r\n";
            }


        }*/
        //textlonchera.text =loncheraString;

        if (alimentos.manzana <= 1)
        {
            textmanzana.text = "";
        }
        else
        {
            textmanzana.text = alimentos.manzana + "";
        }

        if (alimentos.frutilla <= 1)
        {
            textfrutilla.text = "";
        }
        else
        {
            textfrutilla.text = alimentos.frutilla + "";
        }

        if (alimentos.huevodeoro <= 1)
        {
            txthuevo.text = "";
        }
        else
        {
           txthuevo.text = alimentos.huevodeoro + "";
        }

        if (alimentos.maduroasado <= 1)
        {
            txtmaduro.text = "";
        }
        else
        {
            txtmaduro.text = alimentos.maduroasado + "";
        }

        if (alimentos.mandarina <= 1)
        {
            txtmandarina.text = "";
        }
        else
        {
            txtmandarina.text = alimentos.mandarina + "";
        }

        if (alimentos.guineo <= 1)
        {
            txtplatano.text = "";
        }
        else
        {
            txtplatano.text = alimentos.guineo + "";
        }

        if (alimentos.queso <= 1)
        {
            txtqueso.text = "";
        }
        else
        {
            txtqueso.text = alimentos.queso + "";
        }

        if (alimentos.sanduche <= 1)
        {
            txtsanduche.text = "";
        }
        else
        {
            txtsanduche.text = alimentos.sanduche + "";
        }

        if (alimentos.tortillaverde <= 1)
        {
            txttortilla.text = "";
        }
        else
        {
            txttortilla.text = alimentos.tortillaverde + "";
        }

        if (alimentos.uva <= 1)
        {
            txtuvas.text = "";
        }
        else
        {
            txtuvas.text = alimentos.uva + "";
        }

        if (alimentos.zanahoria <= 1)
        {
            txtzanahoria.text = "";
        }
        else
        {
            txtzanahoria.text = alimentos.zanahoria + "";
        }

        if (alimentos.brocoli <= 1)
        {
            txtbrocoli.text = "";
        }
        else
        {
            txtbrocoli.text = alimentos.brocoli + "";
        }

        if (alimentos.pepino <= 1)
        {
            txtpepino.text = "";
        }
        else
        {
            txtpepino.text = alimentos.pepino + "";
        }

        if (alimentos.tomate <= 1)
        {
            txttomate.text = "";
        }
        else
        {
            txttomate.text = alimentos.pepino + "";
        }

        if (alimentos.tomate <= 1)
        {
            txttomate.text = "";
        }
        else
        {
            txttomate.text = alimentos.tomate + "";
        }

        if (alimentos.leche <= 1)
        {
            txtleche.text = "";
        }
        else
        {
            txtleche.text = alimentos.leche + "";
        }

        if (alimentos.aguacate <= 1)
        {
            txtaguacate.text = "";
        }
        else
        {
            txtaguacate.text = alimentos.aguacate + "";
        }








    }

    public void IrJuego(string nombre)
    {
        StartCoroutine(Transicion("Juego"));

        //SceneManager.LoadScene(nombre);
        //print("Cambiando a Escena Juego");
        
    }

    public void IrMenu()
    {
        
        StartCoroutine(Transicion("Menuinicio"));

        //SceneManager.LoadScene(nombre);
        //print("Cambiando a Escena Juego");

    }

    public void IrNiveles(string nombre)
    {
        //StartCoroutine(Transicion("Niveles"));
        StartCoroutine(Transicion("Niveles"));
       
        //print("Cambiando a Escena Juego");

    }

    public void crearManzana()
    {
        GameObject prefab = Instantiate(prefabmanzana, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecManzana;
    }

    public void crearFrutilla()
    {
        GameObject prefab = Instantiate(prefabfrutilla, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecFrutilla;
    }

    public void crearHuevo()
    {
        GameObject prefab = Instantiate(prefabhuevo, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecHuevo;
    }

    public void crearMaduro()
    {
        GameObject prefab = Instantiate(prefabmaduro, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecMaduro;
    }

    public void crearMandarina()
    {
        GameObject prefab = Instantiate(prefabmandarina, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecMandarina;
    }

    public void crearPlatano()
    {
        GameObject prefab = Instantiate(prefabplatano, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecGuineo;
    }

    public void crearQueso()
    {
        GameObject prefab = Instantiate(prefabqueso, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecQueso;
    }

    public void crearSanduche()
    {
        GameObject prefab = Instantiate(prefabsanduche, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecSanduche;
    }

    public void crearTortilla()
    {
        GameObject prefab = Instantiate(prefabtortilla, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecTortilla;
    }

    public void crearUva()
    {
        GameObject prefab = Instantiate(prefabuvas, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecUva;
    }

    public void crearZanahoria()
    {
        GameObject prefab = Instantiate(prefabzanahoria, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecZanahoria;
    }

    public void crearBrocoli()
    {
        GameObject prefab = Instantiate(prefabbrocoli, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecBrocoli;
    }

    public void crearPepino()
    {
        GameObject prefab = Instantiate(prefabpepino, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecPepino;
    }

    public void crearTomate()
    {
        GameObject prefab = Instantiate(prefabtomate, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecTomate;
    }

    public void crearLeche()
    {
        GameObject prefab = Instantiate(prefableche, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecLeche;
    }

    public void crearAguacate()
    {
        GameObject prefab = Instantiate(prefabaguacate, transform.position, transform.rotation) as GameObject;
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.localPosition = vecAguacate;
    }


    public void GameOver()
    {
        SceneManager.LoadScene("Gameover");
        // print("Has perdido");
    }

    public void Repetir()
    {
        StartCoroutine(Transicion("Repetir2"));
    }




}
