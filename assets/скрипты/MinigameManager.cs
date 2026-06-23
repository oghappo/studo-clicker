using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance { get; private set; }

    [Header("Компоненты UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    [Header("Настройки игры")]
    public int maxLives = 3;

    private int _score = 0;
    private int _currentLives;
    private bool _isGameOver = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        _currentLives = maxLives;
        UpdateUI();
        Time.timeScale = 1f;
    }

    public void AddScore(int points)
    {
        if (_isGameOver) return;
        _score += points;
        UpdateUI();
    }

    public void LoseLife()
    {
        if (_isGameOver) return;

        _currentLives--;
        UpdateUI();

        if (_currentLives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + _score;
        if (livesText != null) livesText.text = "Lives: " + _currentLives;
    }

    private void GameOver()
    {
        _isGameOver = true;
        Debug.Log("Игра окончена! Вы пропустили слишком много кубиков.");

        // ИСПРАВИЛИ ТУТ: Теперь через 2 секунды вызывается метод возврата на главную сцену
        Invoke("GoToMainScene", 2f);
    }

    // ИСПРАВИЛИ ТУТ: Переименовали метод и заменили загрузку на главную сцену кликера
    private void GoToMainScene()
    {
        // Загружаем твою основную сцену по её точному названию
        SceneManager.LoadScene("SampleScene");
    }
}