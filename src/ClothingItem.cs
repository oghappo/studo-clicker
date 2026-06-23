using UnityEngine;

// 1. Создаем список типов (обязательно ВНЕ класса)
public enum ClothingType
{
    Hat,
    Shirt,
    Pants,
    Shoes
}

[CreateAssetMenu(fileName = "New Item", menuName = "Clothes/Create Item")]
public class ClothingItem : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;

    // 2. Добавляем само поле типа (именно его ищет скрипт Skin)
    public ClothingType itemType;
}