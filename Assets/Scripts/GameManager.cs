using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Start, FirstLevel, SecondLevel }

    public static GameState currentGameState = GameState.Start;

    public void QuitGame()
    {
        EditorApplication.isPlaying = false;
    }

}
