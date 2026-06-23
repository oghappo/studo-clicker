using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class clicker : MonoBehaviour
{
    public GameObject floatingTextPrefab; // Сюда перетащим префаб из папки
    public Transform canvasTransform;     // Ссылка на Канвас (чтобы текст был внутри него)
    public Transform heroTransform; // Сюда в инспекторе перетащишь свой объект 'buton'
    public static int score;
    public TextMeshProUGUI scoreText;

    public int clickValue = 1; // Лучше сразу дать 1, чтобы клик работал

    [Header("UPGRADE")]
    public int upgradeCost = 10;
    public int UpgradeValue = 2;
    public TextMeshProUGUI upgradeinfoText;

    private void Start()
    {
        // 1. ЗАГРУЖАЕМ ПРОГРЕСС ПРИ СТАРТЕ
        // Если запускаем первый раз — подставляются дефолтные 0, 1 и 10
        score = PlayerPrefs.GetInt("SavedScore", 0);
        clickValue = PlayerPrefs.GetInt("SavedClickValue", 1);
        upgradeCost = PlayerPrefs.GetInt("SavedUpgradeCost", 10);

        // 2. ОБНОВЛЯЕМ UI ЗАГРУЖЕННЫМИ ДАННЫМИ
        scoreText.text = score.ToString();
        if (upgradeinfoText != null)
        {
            upgradeinfoText.text = $"Price: {upgradeCost} (+{UpgradeValue} Click)";
        }
    }

    public void Clicked()
    {
        score += clickValue;
        scoreText.text = score.ToString();
        StartCoroutine(ClickAnimation());

        // СОЗДАЕМ ТЕКСТ ПО ПОВЕРХНОСТИ:
        GameObject popup = Instantiate(floatingTextPrefab, canvasTransform);
        popup.transform.position = heroTransform.position;
        popup.GetComponent<TextMeshProUGUI>().text = "+" + clickValue.ToString();

        // Сохраняем каждый клик, чтобы прогресс точно не пропал
        SaveProgress();
    }

    public void UpgradeClick()
    {
        if (score >= upgradeCost)
        {
            score -= upgradeCost;
            clickValue += UpgradeValue;
            upgradeCost *= 2;

            // Обновляем тексты
            scoreText.text = score.ToString();
            upgradeinfoText.text = $"Price: {upgradeCost} (+{UpgradeValue} klk)";

            // Сохраняем данные сразу после покупки апгрейда
            SaveProgress();
        }
    }

    // МЕТОД ДЛЯ СОХРАНЕНИЯ ДАННЫХ
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("SavedScore", score);
        PlayerPrefs.SetInt("SavedClickValue", clickValue);
        PlayerPrefs.SetInt("SavedUpgradeCost", upgradeCost);
        PlayerPrefs.Save(); // Принудительно записываем на диск
    }

    // Автосохранение, если игрок просто закрыл игру (на ПК)
    private void OnApplicationQuit()
    {
        SaveProgress();
    }

    // Автосохранение, если игру свернули на телефоне
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveProgress();
        }
    }

    IEnumerator ClickAnimation()
    {
        heroTransform.localScale = Vector3.one * 1.1f;
        yield return new WaitForSeconds(0.05f);
        heroTransform.localScale = Vector3.one;
    }
}