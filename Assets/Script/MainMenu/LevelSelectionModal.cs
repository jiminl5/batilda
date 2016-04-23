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
    public static bool PauseActive;
 
    public void loadLevel(string level_name)
    {
        //Application.LoadLevel(level_name);
        SceneManager.LoadScene(level_name);
    }
    void Start()
    {
        PauseActive = false;
        if (SceneManager.GetSceneAt(0).name == "gdMainMenu")
            StartCoroutine(GameSceneCoroutine());
        else if (SceneManager.GetActiveScene().name == "gameResult")
            StartCoroutine(MainSceneCoroutine());
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

    IEnumerator MainSceneCoroutine()
    {
        async = SceneManager.LoadSceneAsync("gdMainMenu");
        async.allowSceneActivation = false;
        yield return async;
    }

    IEnumerator GameSceneCoroutine()
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
            if (Input.GetKeyDown("escape"))
            {
                SetPauseMenu();
            }
        }

    }

    public void SetPauseMenu()
    {
        if (!PauseActive)
        {
            Time.timeScale = 0.00001f;
            PauseMenu.SetActive(true);
            PauseActive = true;
            Tiles.SetActive(false);
        }
        else if (PauseActive)
        {
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
            PauseActive = false;
            Tiles.SetActive(true);
        }
    }
    public void QuitButton(string level_name) //Quit button in game play
    {
        ResetVariables();
        Time.timeScale = 1f;
        SceneManager.LoadScene(level_name);
    }
    
    void ResetVariables()
    {
        PlayerPrefs.SetString("tutorial", "no");
        CustomerAI.seatCount = 0;
        CustomerAI.seat_taken_1 = false;
        CustomerAI.seat_taken_2 = false;
        CustomerAI.seat_taken_3 = false;
        CustomerAI.seat_taken_4 = false;
        CustomerAI.seat_taken_5 = false;
        CustomerAI.customerSat1 = false;
        CustomerAI.customerSat2 = false;
        CustomerAI.customerSat3 = false;
        CustomerAI.customerSat4 = false;
        CustomerAI.customerSat5 = false;
        Waitress.obj_queue1.Clear();
        Chef.obj_queue.Clear();
        MoveableTile.check_Queue.Clear();
        MoveableTile.check_Queue_1.Clear();
        Unit.unit_queue.Clear();
        Unit1.unit_queue1.Clear();
    }
}
