using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveData : MonoBehaviour {

    public Registro registro;
	// Update is called once per frame
	void Update () {
		
	}

    private void Start()
    {
   //     StartCoroutine(SaveData());
    }

  public IEnumerator SaveData()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        registro = FindObjectOfType<Registro>();
        Debug.Log("Posting JSON...");

        string URL = "https://webservicemoviles.000webhostapp.com/prueba.php";

        WWWForm form = new WWWForm();
        form.AddField("clicjugar", registro.clicJugar);
        form.AddField("clicvideo", registro.clicVideo);
        form.AddField("cliccreditos", registro.clicCreditos);
        form.AddField("lleganlonchera", registro.lleganLonchera);
        form.AddField("armanlonchera", registro.armanLonchera);
        form.AddField("pierden", registro.pierden);
        form.AddField("ganan", registro.ganan);
        form.AddField("abandonan", registro.abandonan);
        form.AddField("repiten", registro.repiten);

        var headers = form.headers;
        headers["content-type"] = "application/json";

        WWW www = new WWW(URL, form.data, headers);

        yield return www;
       // Debug.Log(www.uploadProgress);

        if (www.error == null)
        {
            registro.clicJugar = 0;
            registro.clicVideo = 0;
            registro.clicCreditos = 0;
            registro.lleganLonchera = 0;
            registro.armanLonchera = 0;
            registro.pierden = 0;
            registro.ganan = 0;
            registro.abandonan = 0;
            registro.repiten = 0;
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

    }

}
