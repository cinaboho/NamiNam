using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneradorAlimentos : MonoBehaviour {


    [SerializeField]
    private GameObject[] frutas;
    public ControladorTiempo tiempo;
    public bool bandera;

    private BoxCollider2D col;
    float x1, x2;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f;

    }
    void Start()
    {
        tiempo = FindObjectOfType<ControladorTiempo>();
        StartCoroutine(GenerarAlimentos(1f));
    }

    IEnumerator GenerarAlimentos(float time)
    {
        yield return new WaitForSecondsRealtime(time);


        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);

        Instantiate(frutas[Random.Range(0, frutas.Length)], temp, Quaternion.identity);
    

        if (SceneManager.GetSceneByName("Juego").isLoaded)
        {
            StartCoroutine(GenerarAlimentos(3.5f));
           
        }
        else if (SceneManager.GetSceneByName("Juego2").isLoaded)
        {
            StartCoroutine(GenerarAlimentos(2f));
           
        }
        else if (SceneManager.GetSceneByName("Juego3").isLoaded)
        {
            StartCoroutine(GenerarAlimentos(1f));
          
        }




    }
    // Use this for initialization



    // Update is called once per frame
    void Update()
    {
        if (tiempo.tiempo<= 12)
        {
            bandera = true;
        }
    }
	
}
