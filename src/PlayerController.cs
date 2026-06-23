using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Движение")]
    public float moveSpeed = 7f;

    [Tooltip("Ограничение перемещения по краям экрана (ось X)")]
    public float xLimit = 4f;

    void Update()
    {
        // Получаем ввод с клавиатуры (A/D или Стрелочки влево/вправо)
        float moveInput = Input.GetAxis("Horizontal");

        // Двигаем персонажа по оси X
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);

        // Ограничиваем движение, чтобы персонаж не убегал за пределы экрана
        float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}