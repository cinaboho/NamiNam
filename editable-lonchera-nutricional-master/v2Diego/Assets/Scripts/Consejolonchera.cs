using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Consejolonchera : MonoBehaviour {
    public SpriteRenderer sprite1;
    public AudioSource audioArmar;
    // Use this for initialization
    void Start () {
        StartCoroutine(cargarEscena());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator cargarEscena()
    {
        sprite1.GetComponent<Renderer>().enabled = true;
        yield return new WaitForSecondsRealtime(1f);
        audioArmar.Play();

        yield return new WaitForSecondsRealtime(audioArmar.clip.length);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Lonchera");


    }
}
