﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidaslonchera : MonoBehaviour {

    public int vidasLonchera;
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
