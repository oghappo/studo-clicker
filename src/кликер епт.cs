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
    // ЗАМЕНИЛИ ТИП ТУТ:
    public TextMeshProUGUI scoreText;

    public int clickValue = 1; // Лучше сразу дать 1, чтобы клик работал

    [Header("UPGRADE")]
    public int upgradeCost = 10;
    public int UpgradeValue = 2;
    // И ТУТ:
    public TextMeshProUGUI upgradeinfoText;

    public void Clicked()
    {
        score += clickValue;
        scoreText.text = score.ToString();
        StartCoroutine(ClickAnimation());

        // СОЗДАЕМ ТЕКСТ:
        // Создаем объект префаба в позиции мышки (или в центре персонажа)
        GameObject popup = Instantiate(floatingTextPrefab, canvasTransform);

        // Устанавливаем ему позицию кнопки (heroTransform)
        popup.transform.position = heroTransform.position;

        // Меняем текст на текущее значение клика
        popup.GetComponent<TextMeshProUGUI>().text = "+" + clickValue.ToString();
    }
    private void Start()
    {
        // Обновляем тексты
        scoreText.text = score.ToString();
        // Добавил пробелы, чтобы текст не слипался
        upgradeinfoText.text = $"Цена: {upgradeCost} (+{UpgradeValue} клик)";
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
            // Добавил пробелы, чтобы текст не слипался
            upgradeinfoText.text = $"Цена: {upgradeCost} (+{UpgradeValue} клик)";
        }
    }
    IEnumerator ClickAnimation()
    {
        // Увеличиваем масштаб до 1.1 (на 10%)
        heroTransform.localScale = Vector3.one * 1.1f;

        // Ждем крохотную долю секунды
        yield return new WaitForSeconds(0.05f);

        // Возвращаем в исходный размер (1.0)
        heroTransform.localScale = Vector3.one;
    }
}