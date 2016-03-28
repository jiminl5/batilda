using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class LevelSelectionModal : MonoBehaviour {

    public GameObject LoadingScene;
    public Image LoadingAsset;
    AsyncOperation async;
 
    public void loadLevel(string level_name)
    {
        Application.LoadLevel(level_name);
    }
    void Start()
    {
        StartCoroutine(LevelCoroutine());
    }
    public void loadScene()
    {
        async.allowSceneActivation = true;
    }

    public void activateWaitressTab()
    {

    }

    public void activateChefTab()
    {

    }

    IEnumerator LevelCoroutine()
    {
        //LoadingScene.SetActive(true);
        async = Application.LoadLevelAsync("v2.0");
        async.allowSceneActivation = false;
        yield return async;
    }

    public void quitApp()
    {
        Application.Quit();
    }

    public void getTutorial(string Tutorial)
    {
        PlayerPrefs.SetString("tutorial", Tutorial);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }
}
