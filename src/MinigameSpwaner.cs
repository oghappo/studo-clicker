using UnityEngine;

public class MinigameSpawner : MonoBehaviour
{
    [Header("Список предметов для спавна")]
    public GameObject[] objectsToSpawn; // Сюда перетащи дошик, таракана, деньги и оценку

    [Header("Точки спавна")]
    public Transform[] spawnPoints; // Твои точки (Left, Center, Right)

    [Header("Настройки времени")]
    public float spawnInterval = 2f; // Через сколько секунд падает новый предмет
    private float timer;

    void Update()
    {
        // Отсчитываем время
        timer += Time.deltaTime;

        // Если время пришло — спавним предмет и сбрасываем таймер
        if (timer >= spawnInterval)
        {
            SpawnRandomObject();
            timer = 0f;
        }
    }

    void SpawnRandomObject()
    {
        // Проверка на случай, если забыл закинуть объекты в инспекторе (чтобы не было ошибок)
        if (objectsToSpawn.Length == 0 || spawnPoints.Length == 0) return;

        // 1. Выбираем случайный предмет из массива
        int randomObjectIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject selectedPrefab = objectsToSpawn[randomObjectIndex];

        // 2. Выбираем случайную точку спавна (лево, центр или право)
        int randomPointIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedPoint = spawnPoints[randomPointIndex];

        // 3. Создаем выбранный предмет в выбранной точке
        Instantiate(selectedPrefab, selectedPoint.position, selectedPoint.rotation);
    }
}