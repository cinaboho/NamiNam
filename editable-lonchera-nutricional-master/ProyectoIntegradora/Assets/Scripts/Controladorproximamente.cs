using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controladorproximamente : MonoBehaviour {


    public void irCreditos(string nombre)
    {
        SceneManager.LoadScene(nombre);
        print("Cambiando a Escena Creditos");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
            

    }
}
