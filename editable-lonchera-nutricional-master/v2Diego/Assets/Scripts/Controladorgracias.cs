using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controladorgracias : MonoBehaviour {

    public AudioSource audioFelicidades, audioClic;
    public ContadorPuntaje puntaje;
    public ControladorBandera bandera;
    public ContadorAlimentos alimentos;
    // Use this for initialization
    void Start () {
        puntaje = FindObjectOfType<ContadorPuntaje>();
        bandera = FindObjectOfType<ControladorBandera>();
        alimentos = FindObjectOfType<ContadorAlimentos>();
        puntaje.puntaje = 0;

        alimentos.listaAlimentos.Clear();
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
        audioFelicidades.Play();
        bandera.niv1 = false;
        bandera.niv2 = false;
        bandera.niv3 = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IrMenu()
    {
     
        audioClic.Play();
        StartCoroutine(Transicion("Menuinicio"));
    }

    IEnumerator Transicion(string scene)
    {
        // transicion.SetTrigger("end");
        yield return new WaitForSeconds(0.2f);

            SceneManager.LoadScene(scene);
    }
}
