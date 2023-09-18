using UnityEngine;

public class Rotate90Degrees : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // Velocidad de rotación en grados por segundo
    public bool clockwiseRotation = false; // Variable para controlar la dirección de rotación

    private float targetRotationY; // Ángulo de rotación objetivo
    private bool isRotating = false; // Indicador de si el objeto se está rotando

    void Start()
    {
        // Calcula el ángulo objetivo de rotación
        float rotationAmount = clockwiseRotation ? -90.0f : 90.0f;
        targetRotationY = transform.eulerAngles.y + rotationAmount;
    }

    void Update()
    {
        if (!isRotating)
        {
            // Inicia la rotación
            isRotating = true;
            Rotate90DegreesY();
        }
    }

    void Rotate90DegreesY()
    {
        // Calcula la rotación gradualmente
        float step = rotationSpeed * Time.deltaTime;
        float currentRotationY = transform.eulerAngles.y;

        // Realiza la rotación en el eje Y
        float newRotationY = currentRotationY + (clockwiseRotation ? step : -step);

        // Comprueba si se ha alcanzado la rotación objetivo
        if ((clockwiseRotation && newRotationY >= targetRotationY) ||
            (!clockwiseRotation && newRotationY <= targetRotationY))
        {
            // Ajusta la rotación al valor exacto
            transform.rotation = Quaternion.Euler(0, targetRotationY, 0);
            isRotating = false; // Detiene la rotación
        }
        else
        {
            // Continúa la rotación gradualmente
            transform.rotation = Quaternion.Euler(0, newRotationY, 0);
        }
    }
}
