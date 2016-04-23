using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectionModal : MonoBehaviour {

    public GameObject LoadingScene;
    public GameObject PauseMenu;
    public GameObject Tiles;
    public Image LoadingAsset;
    AsyncOperation async;
    public static bool ConfirmGameStart = false;
    public static bool PauseActive = false;
 
    public void loadLevel(string level_name)
    {
        //Application.LoadLevel(level_name);
        SceneManager.LoadScene(level_name);
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
        //async = Application.LoadLevelAsync("v2.0");
        async = SceneManager.LoadSceneAsync("v2.0");
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
        //Pause Menu Jimmy 2016-04-23
        if (SceneManager.GetSceneAt(0).name == "gdMainMenu")
        {
            if (Input.GetKeyDown("escape"))
                Application.Quit();
        }
        else if (SceneManager.GetSceneAt(0).name == "v2.0" && ConfirmGameStart)
        {
            if (Input.GetKeyDown("escape") && !PauseActive)
            {
                Time.timeScale = 0.00001f;
                PauseMenu.SetActive(true);
                PauseActive = true;
                Tiles.SetActive(false);
            }
            else if (Input.GetKeyDown("escape") && PauseActive)
            {
                Time.timeScale = 1f;
                PauseMenu.SetActive(false);
                PauseActive = false;
                Tiles.SetActive(true);
            }
        }

    }
}
