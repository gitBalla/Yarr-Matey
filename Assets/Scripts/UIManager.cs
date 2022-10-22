using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Member Variables
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on click action for start game, loads first level
    public void ClickStartFirstLevel()
    {
        GameManager.currentGameState = GameManager.GameState.FirstLevel;
        SceneManager.LoadSceneAsync(1);
        DontDestroyOnLoad(gameObject);
    }
}
