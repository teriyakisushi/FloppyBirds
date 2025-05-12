using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int PlayerScore;
    public Text ScoreText;
    public GameObject GameOverScreen;

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
        GameOverScreen.SetActive(true);
    }
}
