using UnityEngine;

public class FallingObject : MonoBehaviour
{
    // Создаем типы предметов прямо внутри скрипта
    public enum ObjectType { GoodItem, BadItem }

    [Header("Тип объекта")]
    [Tooltip("GoodItem — надо ловить (Дошик/Зачетка). BadItem — надо избегать (Таракан).")]
    public ObjectType itemType = ObjectType.GoodItem;

    [Header("Настройки падения")]
    public float fallSpeed = 5f;
    public float destroyYLimit = -6f; // Поставь чуть ниже, чем стоит твой игрок

    private bool _hasBeenCaught = false;

    void Update()
    {
        // Движение вниз
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        // Если объект упал ниже лимита Y
        if (transform.position.y < destroyYLimit)
        {
            if (!_hasBeenCaught && MinigameManager.Instance != null)
            {
                // Жизнь отнимается ТОЛЬКО если игрок пропустил хороший предмет (дошик или зачетку)
                if (itemType == ObjectType.GoodItem)
                {
                    MinigameManager.Instance.LoseLife();
                }
                // Если пролетел таракан — игрок молодец, увернулся, жизнь НЕ отнимаем
            }

            Destroy(gameObject); // В любом случае удаляем объект со сцены
        }
    }

    // Метод срабатывает, когда объект пересекается с Trigger-коллайдером игрока
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что столкнулись именно с объектом с тегом Player
        if (other.CompareTag("Player") && !_hasBeenCaught)
        {
            _hasBeenCaught = true;

            if (MinigameManager.Instance != null)
            {
                if (itemType == ObjectType.GoodItem)
                {
                    MinigameManager.Instance.AddScore(1); // Поймал дошик/зачетку — +1 очко
                }
                else if (itemType == ObjectType.BadItem)
                {
                    MinigameManager.Instance.LoseLife(); // Поймал таракана — минус жизнь!
                }
            }

            Destroy(gameObject); // Уничтожаем пойманный объект
        }
    }
}