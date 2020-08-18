using DigitalRuby.SoundManagerNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ActivityHubManager : MonoBehaviour {
    public void exitApp()
    {
        GameStateManager.Instance.ReadLocalFile();
        StartCoroutine(GameStateManager.Instance.SyncJsonData());
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        Application.Quit();
    }
}
