using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class LogicScript : MonoBehaviour
{
    public int PlayerScore;
    public float PipeMoveSpeed;
    public Text ScoreText;
    public GameObject GameOverScreen;
    public Text Start_CountdownText;
    public GameObject StartScreen;
    public bool isGameOver = false;
    private bool gameStarted = false;

    [ContextMenu("Increse Score")]
    public void AddScore(int scoreToAdd)
    {
        PlayerScore += scoreToAdd;
        ScoreText.text = PlayerScore.ToString();
    }

    public void Start()
    {
        if (StartScreen != null)
        {
            StartScreen.SetActive(true);
        }

        originalPipeSpeed = PipeMoveSpeed;

        StartCoroutine(CountdownToStart());
    }

    private IEnumerator CountdownToStart()
    {
        if (Start_CountdownText == null)
        {
            Debug.LogError("Start_CountdownText is null!");
            StartScreen.SetActive(false);
            yield break;
        }

        // stop game time
        Time.timeScale = 0;

        for (int i = 3; i > 0; i--)
        {
            Start_CountdownText.text = i.ToString();

            float pauseEndTime = Time.realtimeSinceStartup + 1f;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return null;
            }
        }

        Start_CountdownText.text = "GO!";

        // hide start screen
        StartScreen.SetActive(false);

        // Resume Games
        Time.timeScale = 1;
        gameStarted = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        // Reload the scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameOver = true;
        GameOverScreen.SetActive(true);
    }

    public float originalPipeSpeed;  // Pipe 的原始速度  
    public float TargetPipeSpeed; // Pipe 的目标速度  
    public float PipeSpeedMultiplier = 2.0f; // Pipe 的速度乘数  

    public void PipeSpeedUp(bool accelerate)
    {
        if (!gameStarted) return;

        PipeMoveSpeed = accelerate ? originalPipeSpeed * PipeSpeedMultiplier : originalPipeSpeed;

        // Update all pipes speed
        PipeMoveScript[] pipes = FindObjectsByType<PipeMoveScript>(FindObjectsSortMode.None);
        foreach (PipeMoveScript pipe in pipes)
        {
            pipe.MoveSpeed = PipeMoveSpeed;
        }
    }

    public void DestroyPipe(GameObject pipeObject)
    {
        Debug.Log("Pipe Destroyed");
        Destroy(pipeObject);
        AddScore(10);
    }
}