using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Member Variables
    ////StartMenu
    Button firstLevelButton;
    ////Button secondLevelButton;
    Button quitGameButton;
    ////FirstLevel
    Button exitLevelButton;
    TextMeshProUGUI scaredTimerText;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            quitGameButton = GameObject.FindGameObjectWithTag("QuitGameButton").GetComponent<Button>();
            quitGameButton.onClick.AddListener(ClickQuitGame);

            firstLevelButton = GameObject.FindGameObjectWithTag("FirstLevelButton").GetComponent<Button>();
            firstLevelButton.onClick.AddListener(ClickStartFirstLevel);
        }

        if (scene.buildIndex == 1)
        {
            exitLevelButton = GameObject.FindGameObjectWithTag("ExitLevelButton").GetComponent<Button>();
            exitLevelButton.onClick.AddListener(ClickExitLevel);

            scaredTimerText = GameObject.FindGameObjectWithTag("ScaredTimer").GetComponent<TextMeshProUGUI>();
            scaredTimerText.enabled = false;
        }
    }

    //on click action for start game, loads first level
    public void ClickStartFirstLevel()
    {
        GameManager.currentGameState = GameManager.GameState.FirstLevel;
        SceneManager.LoadSceneAsync(1);
    }

    //on click action for exit level to start screen
    public void ClickExitLevel()
    {
        GameManager.currentGameState = GameManager.GameState.Start;
        SceneManager.LoadSceneAsync(0);
    }

    //on click action for quitting the game
    public void ClickQuitGame()
    {
        EditorApplication.isPlaying = false;
    }
}
