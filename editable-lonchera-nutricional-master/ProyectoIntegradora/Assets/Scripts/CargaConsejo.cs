using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaConsejo : MonoBehaviour {

   // int rand;
    public ControladorBandera bandera;
    public SpriteRenderer sprite1,sprite2,sprite3,sprite4;
    public AudioSource audioArrastrar, audioChatarra, audioArmar, audioPerdervidas, audioClic;
    // Use this for initialization
    void Start () {
        bandera = FindObjectOfType<ControladorBandera>();
       // rand = Random.Range(1, 5);
        StartCoroutine(cargarEscena());
    }

    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void IrNiveles()
    {
        audioClic.Play();
        if (bandera.niv1 == true)
        {
            bandera.niv1 = false;
            SceneManager.LoadScene("Juego");
        }
        else if (bandera.niv2)
        {
            bandera.niv2 = false;
            SceneManager.LoadScene("Juego2");
        }
        else if (bandera.niv3)
        {
            bandera.niv3 = false;
            SceneManager.LoadScene("Juego3");
        }
    }

    IEnumerator cargarEscena()
    {

        // rand = 3;
        //  if(rand == 1)
        //  {
        //  print(rand);

       //audioHome = GetComponent<AudioSource>();
       // audioHome.Play();

            sprite1.GetComponent<Renderer>().enabled = true;
            sprite2.GetComponent<Renderer>().enabled = false;
            sprite3.GetComponent<Renderer>().enabled = false;
            sprite4.GetComponent<Renderer>().enabled = false;
            audioArrastrar.Play();
            yield return new WaitForSecondsRealtime(audioArrastrar.clip.length);
            yield return new WaitForSecondsRealtime(1.5f);
        //  }

        // if (rand == 2)
        // {
        //  print(rand);
            sprite1.GetComponent<Renderer>().enabled = false;
            sprite2.GetComponent<Renderer>().enabled = true;
            sprite3.GetComponent<Renderer>().enabled = false;
            sprite4.GetComponent<Renderer>().enabled = false;
            audioPerdervidas.Play();
            yield return new WaitForSecondsRealtime(audioPerdervidas.clip.length);
            yield return new WaitForSecondsRealtime(1.5f);
        //  }

        //  if (rand == 3)
        //  {
        //  print(rand);
            sprite1.GetComponent<Renderer>().enabled = false;
            sprite2.GetComponent<Renderer>().enabled = false;
            sprite3.GetComponent<Renderer>().enabled = true;
            sprite4.GetComponent<Renderer>().enabled = false;
            audioChatarra.Play();
            yield return new WaitForSecondsRealtime(audioChatarra.clip.length);
            yield return new WaitForSecondsRealtime(1.5f);
        //  }

        //  if (rand == 4)
        //  {
        //  print(rand);
        /*
            sprite1.GetComponent<Renderer>().enabled = false;
            sprite2.GetComponent<Renderer>().enabled = false;
            sprite3.GetComponent<Renderer>().enabled = false;
            sprite4.GetComponent<Renderer>().enabled = true;
            audioArmar.Play();
        // }

        yield return new WaitForSecondsRealtime(audioArmar.clip.length);
        yield return new WaitForSecondsRealtime(1f);*/
        // SceneManager.LoadScene("Niveles");
        if (bandera.niv1 == true)
        {
            bandera.niv1 = false;
            SceneManager.LoadScene("Juego");
        }
        else if (bandera.niv2)
        {
            bandera.niv2 = false;
            SceneManager.LoadScene("Juego2");
        }
        else if (bandera.niv3)
        {
            bandera.niv3 = false;
            SceneManager.LoadScene("Juego3");
        }
    }
}
