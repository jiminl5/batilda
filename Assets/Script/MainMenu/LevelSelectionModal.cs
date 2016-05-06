using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectionModal : MonoBehaviour {

    public GameObject MonthOneLevels;
    public GameObject BackToMainMenuBtn;

    public GameObject LoadingScene;
    public GameObject PauseMenu;
    public GameObject Tiles;
    public GameObject[] MainMenuBtns; //Used to deactivate menu buttons
    public GameObject[] MainMenuAssets; // Used to re-activate
    public GameObject[] GoBtns; // Used To Deactivate gobtns.
    public GameObject[] TutorialAssets;
    public GameObject LevelSelectionPanel;
    public GameObject LevelDetail;

    public Image LoadingAsset;
    AsyncOperation async;
    public static bool ConfirmGameStart;
    public static bool PauseActive;
    public bool QuitActive;
 
    public void loadLevel(string level_name)
    {
        //Application.LoadLevel(level_name);
        SceneManager.LoadScene(level_name);
    }
    void Start()
    {
        ConfirmGameStart = false;
        PauseActive = false;
        QuitActive = false;
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
            {
                if (!LevelSelectionPanel.activeSelf && !LevelDetail.activeSelf)
                {
                    SetQuitMenu();
                }
                else if (LevelSelectionPanel.activeSelf && !LevelDetail.activeSelf)
                {
                    LevelSelectionPanel.SetActive(false);
                    foreach (GameObject go in MainMenuAssets)
                    {
                        go.SetActive(true);
                    }
                    foreach (GameObject go in GoBtns)
                    {
                        go.SetActive(false);
                    }
                }
                else if (LevelSelectionPanel.activeSelf && LevelDetail.activeSelf)
                {
                    LevelDetail.SetActive(false);
                    EnableMonthBtn();
                    foreach (GameObject go in GoBtns)
                    {
                        go.SetActive(false);
                    }
                }
            }
        }
        else if (SceneManager.GetSceneAt(0).name == "v2.0" && ConfirmGameStart)
        {
            if (Input.GetKeyDown("escape"))
            {
                SetPauseMenu();
            }
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetQuitMenu()
    {
        if (!QuitActive)
        {
            foreach (GameObject go in MainMenuBtns)
            {
                go.GetComponent<Button>().interactable = false;
            }
            PauseMenu.SetActive(true);
            QuitActive = true;
        }
        else if(QuitActive)
        {
            foreach (GameObject go in MainMenuBtns)
            {
                go.GetComponent<Button>().interactable = true;
            }
            PauseMenu.SetActive(false);
            QuitActive = false;
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
            if (PlayerPrefs.GetString("tutorial") == "yes")
            {
                foreach (GameObject go in TutorialAssets)
                {
                    go.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
        else if (PauseActive)
        {
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
            PauseActive = false;
            Tiles.SetActive(true);
            if (PlayerPrefs.GetString("tutorial") == "yes")
            {
                foreach (GameObject go in TutorialAssets)
                {
                    if (go != TutorialAssets[3] && !TutorialAssets[3].GetComponent<SpriteRenderer>().enabled)
                        go.GetComponent<BoxCollider2D>().enabled = true;
                    else if (go == TutorialAssets[3] && TutorialAssets[3].GetComponent<SpriteRenderer>().enabled)
                        go.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
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

    public void DisableMonthBtn()
    {
        BackToMainMenuBtn.GetComponent<Button>().interactable = false;
        BackToMainMenuBtn.GetComponent<Image>().enabled = false;
        foreach (Transform child in MonthOneLevels.transform)
        {
            foreach (Transform child_ in child.transform)
            {
                child_.GetComponent<Button>().interactable = false;
            }
        }
    }
    public void EnableMonthBtn()
    {
        BackToMainMenuBtn.GetComponent<Button>().interactable = true;
        BackToMainMenuBtn.GetComponent<Image>().enabled = true;
        foreach (Transform child in MonthOneLevels.transform)
        {
            foreach (Transform child_ in child.transform)
            {
                child_.GetComponent<Button>().interactable = true;
            }
        }
    }
}
