using UnityEngine;

public class FallingItem : MonoBehaviour
{
    [Header("Настройки полета")]
    public float fallSpeed = 400f; // Большая скорость, так как координаты UI крупные

    void Update()
    {
        // Каждый кадр двигаем дошик строго вниз
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Если дошик улетел далеко за нижнюю границу экрана (например, ниже Y = -100),
        // удаляем его, чтобы он не забивал память компьютера
        if (transform.position.y < -100f)
        {
            Destroy(gameObject);
        }
    }
}