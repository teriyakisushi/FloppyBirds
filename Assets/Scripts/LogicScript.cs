using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class LogicScript : MonoBehaviour
{
    public int PlayerScore;
    public float PipeMoveSpeed;
    public Text ScoreText;
    public GameObject GameOverScreen;
    public bool isGameOver = false;

    [ContextMenu("Increse Score")]
    public void AddScore(int scoreToAdd)
    {
        PlayerScore += scoreToAdd;
        ScoreText.text = PlayerScore.ToString();
    }
    public void RestartGame()
    {
        // Reload the current scene  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        isGameOver = true;
        GameOverScreen.SetActive(true);
    }

    public float originalPipeSpeed;  // Pipe ��ԭʼ�ٶ�  
    public float TargetPipeSpeed; // Pipe ��Ŀ���ٶ�  
    public float PipeSpeedMultiplier = 2.0f; // Pipe ���ٶȳ���  
    public void PipeSpeedUp(bool accelerate)
    {
        PipeMoveSpeed = accelerate ? originalPipeSpeed * PipeSpeedMultiplier : originalPipeSpeed;

        // ��������pipe������ٶ�  
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
