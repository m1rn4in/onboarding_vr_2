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
        targetRotationY = transform.eulerAngles.y + (clockwiseRotation ? -90.0f : 90.0f);
    }

    void Update()
    {
        if (!isRotating)
        {
            // Inicia la rotación
            RotateObjectOnY();
        }
    }

    void RotateObjectOnY()
    {
        // Calcula la rotación gradualmente
        float step = rotationSpeed * Time.deltaTime;
        float currentRotationY = transform.eulerAngles.y;

        // Realiza la rotación en el eje Y
        transform.rotation = Quaternion.Euler(0, currentRotationY + step, 0);

        // Comprueba si se ha alcanzado la rotación objetivo
        if ((clockwiseRotation && transform.eulerAngles.y <= targetRotationY) ||
            (!clockwiseRotation && transform.eulerAngles.y >= targetRotationY))
        {
            // Ajusta la rotación al valor exacto
            transform.rotation = Quaternion.Euler(0, targetRotationY, 0);
            isRotating = false; // Detiene la rotación
        }
    }
}
