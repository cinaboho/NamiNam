using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registro : MonoBehaviour {

    public int clicJugar;
    public int clicVideo;
    public int clicCreditos;
    public int terminanJuego;
    public int lleganLonchera;
    public int armanLonchera;
    public int pierden;
    public int ganan;
    public int abandonan;
    public int repiten;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        {
            DontDestroyOnLoad(this);

            if (FindObjectsOfType(GetType()).Length > 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
