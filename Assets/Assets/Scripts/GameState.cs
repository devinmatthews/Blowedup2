using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    public static bool gameOver;

    private static long score;
    public static long Score
    {
        get
        {
            return score;
        }
        set
        {
            score = Math.Max(value, 0);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCountInBuildSettings - 1)
        {
            ResetGame();
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void ResetGame()
    {
        gameOver = false;
        SceneManager.LoadScene(0);
    }
}
