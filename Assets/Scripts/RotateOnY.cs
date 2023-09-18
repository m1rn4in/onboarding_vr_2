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
        targetRotationY = transform.eulerAngles.y + (clockwiseRotation ? -90.0f : 90.0f);
    }

    void Update()
    {
        if (!isRotating)
        {
            // Inicia la rotaci�n
            RotateObjectOnY();
        }
    }

    void RotateObjectOnY()
    {
        // Calcula la rotaci�n gradualmente
        float step = rotationSpeed * Time.deltaTime;
        float currentRotationY = transform.eulerAngles.y;

        // Realiza la rotaci�n en el eje Y
        transform.rotation = Quaternion.Euler(0, currentRotationY + step, 0);

        // Comprueba si se ha alcanzado la rotaci�n objetivo
        if ((clockwiseRotation && transform.eulerAngles.y <= targetRotationY) ||
            (!clockwiseRotation && transform.eulerAngles.y >= targetRotationY))
        {
            // Ajusta la rotaci�n al valor exacto
            transform.rotation = Quaternion.Euler(0, targetRotationY, 0);
            isRotating = false; // Detiene la rotaci�n
        }
    }
}
