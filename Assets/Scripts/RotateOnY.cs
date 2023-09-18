using UnityEngine;

public class Rotate90Degrees : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // Velocidad de rotaci�n en grados por segundo
    public bool clockwiseRotation = false; // Variable para controlar la direcci�n de rotaci�n

    private float targetRotationY; // �ngulo de rotaci�n objetivo
    private bool isRotating = false; // Indicador de si el objeto se est� rotando

    void Start()
    {
        // Calcula el �ngulo objetivo de rotaci�n
        float rotationAmount = clockwiseRotation ? -90.0f : 90.0f;
        targetRotationY = transform.eulerAngles.y + rotationAmount;
    }

    void Update()
    {
        if (!isRotating)
        {
            // Inicia la rotaci�n
            isRotating = true;
            Rotate90DegreesY();
        }
    }

    void Rotate90DegreesY()
    {
        // Calcula la rotaci�n gradualmente
        float step = rotationSpeed * Time.deltaTime;
        float currentRotationY = transform.eulerAngles.y;

        // Realiza la rotaci�n en el eje Y
        float newRotationY = currentRotationY + (clockwiseRotation ? step : -step);

        // Comprueba si se ha alcanzado la rotaci�n objetivo
        if ((clockwiseRotation && newRotationY >= targetRotationY) ||
            (!clockwiseRotation && newRotationY <= targetRotationY))
        {
            // Ajusta la rotaci�n al valor exacto
            transform.rotation = Quaternion.Euler(0, targetRotationY, 0);
            isRotating = false; // Detiene la rotaci�n
        }
        else
        {
            // Contin�a la rotaci�n gradualmente
            transform.rotation = Quaternion.Euler(0, newRotationY, 0);
        }
    }
}
