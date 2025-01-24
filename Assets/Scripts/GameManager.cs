using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public UIManager uIManager;

    public enum GameState
    {
        MainMenu,
        GamePlay,
        GamePause,
        Settings,
        Intro
    }

    public GameState currentGameState;
    public GameState previousGameState;

    public GameObject player;

    void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleGameState();
    }

    void HandleGameState()
    {
        switch (currentGameState)
        {
            case GameState.MainMenu:
                MainMenu();
                break;
            case GameState.GamePlay:
                GamePlay();
                break;
            case GameState.GamePause:
                GamePause();
                break;
            case GameState.Settings:
                Settings();
                break;
            case GameState.Intro:
                Intro();
                break;
        }
    }

    #region Game States
    void MainMenu()
    {
        Cursor.visible = true;
        uIManager.MainMenuUI();
        player.SetActive(false);
    }

    void GamePlay()
    {
        Cursor.visible = false;
        uIManager.GamePlayUI();
        player.SetActive(true);
    }

    void GamePause()
    {
        Cursor.visible = true;
        uIManager.GamePauseUI();
        player.SetActive(true);
    }

    void Settings()
    {
        Cursor.visible = true;
        uIManager.SettingsUI();
        player.SetActive(false);
    }

    void Intro()
    {
        Cursor.visible = true;
        uIManager.IntroUI();
        player.SetActive(false);
    }
    #endregion

    public void ChangeGameState(GameState newGameState)
    {
        previousGameState = currentGameState;
        currentGameState = newGameState;
    }

    public void ChangeToPreviousGameState()
    {
        GameState temp = currentGameState;
        currentGameState = previousGameState;
        previousGameState = temp;
    }

    public void PlayGame()
    {
        ChangeGameState(GameState.GamePlay);
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenMainMenu()
    {
        ChangeGameState(GameState.MainMenu);
    }

    public void OpenSettings()
    {
        ChangeGameState(GameState.Settings);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
