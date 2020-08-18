using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiolonchera : MonoBehaviour {

    public AudioSource audioJackpot, audioClic;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playJackpot()
    {
        audioJackpot.Play();
    }

    public void playClic()
    {
        audioClic.Play();
    }
}
