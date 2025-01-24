using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject gamePlayUI;
    public GameObject gamePauseUI;
    public GameObject settingsUI;
    public GameObject introUI;

    public void TurnOffUI()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        gamePauseUI.SetActive(false);
        settingsUI.SetActive(false);
        introUI.SetActive(false);
    }

    public void MainMenuUI()
    {
        TurnOffUI();
        mainMenuUI.SetActive(true);
    }

    public void GamePlayUI()
    {
        TurnOffUI();
        gamePlayUI.SetActive(true);
    }

    public void GamePauseUI()
    {
        TurnOffUI();
        gamePauseUI.SetActive(true);
    }

    public void SettingsUI()
    {
        TurnOffUI();
        settingsUI.SetActive(true);
    }

    public void IntroUI()
    {
        TurnOffUI();
        introUI.SetActive(true);
    }
}
