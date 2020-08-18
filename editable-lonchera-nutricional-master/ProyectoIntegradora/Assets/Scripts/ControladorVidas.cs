using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorVidas : MonoBehaviour {

    public GameObject vida1, vida2, vida3;
    public int contVidas;
    public ControladorBandera bandera;
    public Vidaslonchera vLon;
    public ControladorJuego juego;
    public Controladorlonchera lonchera;

    // Use this for initialization
    void Start () {
        bandera = FindObjectOfType<ControladorBandera>();
        if (SceneManager.GetSceneByName("Juego").isLoaded || SceneManager.GetSceneByName("Juego2").isLoaded || SceneManager.GetSceneByName("Juego3").isLoaded)
        {
            vLon = FindObjectOfType<Vidaslonchera>();
            vLon.vidasLonchera = 3;
            Instantiate(vida1, GameObject.Find("Canvas").transform);
            Instantiate(vida2, GameObject.Find("Canvas").transform);
            Instantiate(vida3, GameObject.Find("Canvas").transform);
        }

        if (SceneManager.GetSceneByName("Lonchera").isLoaded)
        {
            vLon = FindObjectOfType<Vidaslonchera>();
           // crearVidas();



        }
        

        contVidas = 3;

        juego = FindObjectOfType<ControladorJuego>();
    }
	
	// Update is called once per frame
	void Update () {

    }
    private void Awake()
    {
   
    }
    public void crearVidas()
    {
        if(vLon.vidasLonchera == 1)
        {
            GameObject v1 = Instantiate(vida1, transform.position, transform.rotation) as GameObject;
            v1.transform.SetParent(GameObject.Find("Canvas").transform);
            v1.transform.localScale = new Vector3(30, 30, 30);
            v1.transform.localPosition = new Vector3(-197, 114, 0); ;
        }
        else if (vLon.vidasLonchera == 2)
        {
            GameObject v1 = Instantiate(vida1, transform.position, transform.rotation) as GameObject;
            v1.transform.SetParent(GameObject.Find("Canvas").transform);
            v1.transform.localScale = new Vector3(30, 30, 30);
            v1.transform.localPosition = new Vector3(-197, 114, 0); ;

            GameObject v2 = Instantiate(vida2, transform.position, transform.rotation) as GameObject;
            v2.transform.SetParent(GameObject.Find("Canvas").transform);
            v2.transform.localScale = new Vector3(30, 30, 30);
            v2.transform.localPosition = new Vector3(-128, 114, 0); ;
        }
        else if (vLon.vidasLonchera == 3)
        {
            GameObject v1 = Instantiate(vida1, transform.position, transform.rotation) as GameObject;
            v1.transform.SetParent(GameObject.Find("Canvas").transform);
            v1.transform.localScale = new Vector3(30, 30, 30);
            v1.transform.localPosition = new Vector3(-197, 114, 0); ;

            GameObject v2 = Instantiate(vida2, transform.position, transform.rotation) as GameObject;
            v2.transform.SetParent(GameObject.Find("Canvas").transform);
            v2.transform.localScale = new Vector3(30, 30, 30);
            v2.transform.localPosition = new Vector3(-128, 114, 0); ;

            GameObject v3 = Instantiate(vida3, transform.position, transform.rotation) as GameObject;
            v3.transform.SetParent(GameObject.Find("Canvas").transform);
            v3.transform.localScale = new Vector3(30, 30, 30);
            v3.transform.localPosition = new Vector3(-57, 114, 0); ;
        }
   
    }

    public void RestarVidas()
    {
        //print("probando");
       // print("vidas restantes: " + contVidas);
        if (contVidas == 3)
        {
           
           //vida1.SetActive(false);

            GameObject.Find("vida1(Clone)").SetActive(false);

            contVidas--;
           // vLon.vidasLonchera = contVidas;
            //print("vidas restantes: "+ contVidas);
        }

        else if (contVidas == 2)
        {

            // vida2.SetActive(false);
            GameObject.Find("vida2(Clone)").SetActive(false);
            contVidas--;
           // vLon.vidasLonchera = contVidas;
            //print("vidas restantes: " + contVidas);
        }

       else if (contVidas == 1)
        {

            GameObject.Find("vida3(Clone)").SetActive(false);
            //vida3.SetActive(false);
            contVidas--;
          //  vLon.vidasLonchera = contVidas;
            //   print("vidas restantes: " + contVidas);
            StartCoroutine(Transicion());
        }
    }

    public void RestarVidasLonchera()
    {
        if (contVidas == 3)
        {
            GameObject.Find("vida1(Clone)").SetActive(false);
            contVidas--;
        }

        else if (contVidas == 2)
        {
            GameObject.Find("vida2(Clone)").SetActive(false);
            contVidas--;
        }

        else if (contVidas == 1)
        {
            GameObject.Find("vida3(Clone)").SetActive(false);
            contVidas--;
            StartCoroutine(TransicionLonchera());
        }
    }

        IEnumerator Transicion()
    {
        juego = FindObjectOfType<ControladorJuego>();
       // juego.transicion.SetTrigger("end");
        yield return new WaitForSeconds(0.2f);
        juego.GameOver();
    }

    IEnumerator TransicionLonchera()
    {
        lonchera = FindObjectOfType<Controladorlonchera>();
        // juego.transicion.SetTrigger("end");
        yield return new WaitForSeconds(0.2f);
        //lonchera.Repetir();
        lonchera.GameOver();
    }
}
