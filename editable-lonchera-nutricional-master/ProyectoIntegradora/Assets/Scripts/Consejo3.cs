﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Consejo3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(cargarEscena());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator cargarEscena()
    {

        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("Consejo4");

    }
}
