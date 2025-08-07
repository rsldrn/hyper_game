using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour  
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletePanel;
    
    [SerializeField] private Slider progressBar;
    [SerializeField] private Text levelText;
    
    private bool hasLevelCompleted; // Level tamamlanma bayragi


    
    void Start()
    {
        progressBar.value = 0;
        
        levelText.text = "Level " + (ChunkManager.Instance.GetLevels() +1).ToString();

        GameManager.onGameStateChanged += GameStateChangeCallback;
        
        //////////Oyun boyle mi durdurulmali
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangeCallback;
    }

    void Update()
    {
        UpdateProgressBar(); 
    }

    private void GameStateChangeCallback(GameState gameState) //
    {
        if (gameState == GameState.GameOver) //
        {
            ShowGameOverPanel();
        }
        else if (gameState == GameState.LevelComplete)//
        {
            ShowLevelCompletePanel();
        }
    }

    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameState.Game);//

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        hasLevelCompleted = false; // Yeni oyun baslarken sifirla
    }
    
    public void RetryButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowLevelCompletePanel()
    {
        gamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        /////////
        Time.timeScale = 0f;
    }

    public void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGameState())
        {
            return;
        }
        
        float progress = PlayerController.Instance.transform.position.z / ChunkManager.Instance.GetFinishZ();
        progressBar.value = progress;
        
        // Progress bar 1.0'a ulastiginda level tamamlama
        if (progress >= 1f && !hasLevelCompleted)
        {
            hasLevelCompleted = true;
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            GameManager.instance.SetGameState(GameState.LevelComplete);
        }
        
    }
}
