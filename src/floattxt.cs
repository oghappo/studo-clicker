using UnityEngine;
using TMPro;

public class floattxt : MonoBehaviour
{
    public float destroyTime = 1f; // Через сколько секунд текст исчезнет
    public Vector2 minSpeed = new Vector2(-150, 150); // Диапазон влево/вправо
    public Vector2 maxSpeed = new Vector2(150, 250);  // Диапазон вверх

    private Vector3 currentSpeed; // Конкретная скорость для этого клона

    void Start()
    {
        void Start()
        {
            // ... остальной код (выбор скорости) ...

            // Вот эта строка удаляет клон из памяти через 1 секунду:
            Destroy(gameObject, destroyTime);
        }
        // 1. Считаем случайную скорость при появлении
        float randomX = Random.Range(minSpeed.x, maxSpeed.x);
        float randomY = Random.Range(minSpeed.y, maxSpeed.y);
        currentSpeed = new Vector3(randomX, randomY, 0);

        // 2. Даем команду на самоуничтожение
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        // 3. Каждый кадр двигаем текст
        transform.position += currentSpeed * Time.deltaTime;
    }
}