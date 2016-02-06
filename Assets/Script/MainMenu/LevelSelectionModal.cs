using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class LevelSelectionModal : MonoBehaviour {

    public GameObject LoadingScene;
    public Image LoadingAsset;

    public void loadLevel(string level_number)
    {
        Application.LoadLevel("level" + level_number);
    }
    
    public void loadScene(string scene_name)
    {
        //Application.LoadLevel(scene_name);
        StartCoroutine(LevelCoroutine(scene_name));
    }

    public void activateWaitressTab()
    {

    }

    public void activateChefTab()
    {

    }

    IEnumerator LevelCoroutine(string scene_name)
    {
        //LoadingScene.SetActive(true);
        AsyncOperation async = Application.LoadLevelAsync(scene_name);
        async.allowSceneActivation = true;
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
