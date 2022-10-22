using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Member Variables

    //on click action for start game, loads first level
    public void ClickStartFirstLevel()
    {
        GameManager.currentGameState = GameManager.GameState.FirstLevel;
        SceneManager.LoadSceneAsync(1);
        DontDestroyOnLoad(gameObject);
    }
}
