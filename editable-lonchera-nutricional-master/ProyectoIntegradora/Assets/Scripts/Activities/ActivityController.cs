using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityController : MonoBehaviour {

    public GameObject activityOptionPrefab;
    public GameObject options;
    public Sprite[] nonLivingSprites;
    public Sprite[] livingSprites;
    public Color[] myColors; //0 = white, 1 = green, 2 = red

    private string activityName;
    private readonly int numberOfSubLevels = 10;
    private int score = 0;
    private int errors = 0;
    private int activity3Flag = 0;
    private bool subLevelFinished = false;
    private ArrayList spritesAlreadyInUse;

    private bool order;  //false = no vivo ... true = vivo
    private string orderSoundName;  //el nombre del audio que dará la orden en esta actividad

    private readonly string[] LoliVoicesCorrect = { "LoliExcelente", "LoliRespondisteMuybien", "LoliBienSigueAsi", "LoliEsoEstuvoGenial" };
    private readonly string[] LoliVoicesWrong = { "LoliDeNuevo", "LoliIntentaloOtraVez", "LoliNoTeDesanimes", "LoliPuedesHacerloMejor" };

    public LevelMetaData levelData;


    // Use this for initialization
    public void EndLevel(string status)
    {
        if (status == "abandonado")
        {
            AudioManager.Instance.PlaySFX("TinyButtonPush");
        }

        levelData.estado = status;
        levelData.fecha_fin = System.DateTime.Now.ToString("yyyy/MM/dd");
        levelData.tiempo_juego = System.Math.Round(Time.timeSinceLevelLoad).ToString();
        levelData.correctas = score.ToString();
        levelData.incorrectas = errors.ToString();
        GameStateManager.Instance.AddJsonToList(JsonUtility.ToJson(levelData));

        GameStateManager.Instance.LoadScene("ActivityHub");
    }
}
