using UnityEngine;
using UnityEngine.UI; // Это нужно для работы с Image

public class Skin : MonoBehaviour
{
    [Header("UI Ячейки на персонаже")]
    // Те самые ячейки, которые ты заполнял в Инспекторе
    public Image hatImage;
    public Image shirtImage;
    public Image pantsImage;
    public Image shoesImage;

    // Основная функция, которую вызывают кнопки
    public void ApplySkin(ClothingItem item)
    {
        // 1. Проверяем, не пустой ли предмет прилетел
        if (item == null) return;

        // 2. Смотрим, какой тип у этого предмета
        switch (item.itemType)
        {
            case ClothingType.Hat:
                // Если это шапка — работаем с hatImage
                ApplyToSlot(hatImage, item.itemSprite);
                break;

            case ClothingType.Shirt:
                // Если кофта — работаем с shirtImage
                ApplyToSlot(shirtImage, item.itemSprite);
                break;

            case ClothingType.Pants:
                // Если штаны — работаем с pantsImage
                ApplyToSlot(pantsImage, item.itemSprite);
                break;

            case ClothingType.Shoes:
                // Если обувь — работаем с shoesImage
                ApplyToSlot(shoesImage, item.itemSprite);
                break;
        }
    }

    // Вспомогательная функция, чтобы не писать один и тот же код 4 раза
    // Она берет ячейку, ставит в неё спрайт и включает её.
    private void ApplyToSlot(Image targetImage, Sprite newSprite)
    {
        // Проверяем, привязана ли ячейка в Инспекторе (чтобы не было NullReference)
        if (targetImage != null)
        {
            targetImage.sprite = newSprite; // Устанавливаем новую картинку
            targetImage.gameObject.SetActive(true); // ВКЛЮЧАЕМ ОБЪЕКТ ОДЕЖДЫ

            // На всякий случай сбрасываем прозрачность на максимум
            Color c = targetImage.color;
            c.a = 1f;
            targetImage.color = c;
        }
        else
        {
            Debug.LogError("Ошибка: В скрипте Skin не привязана одна из UI ячеек!");
        }
    }
}