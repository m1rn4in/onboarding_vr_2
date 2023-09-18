using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float translationSpeed = 5.0f; // Velocidad de traslación en el eje X
    public Vector3[] points; // Puntos a los que se moverá el objeto en el eje X
    public float waitTime = 10.0f; // Tiempo de espera en cada punto en segundos

    private int currentPointIndex = 0; // Índice del punto actual en X
    private float currentTime = 0.0f; // Contador de tiempo para el tiempo de espera
    private bool isMoving = true; // Indicador de si el objeto se está moviendo o esperando

    private Vector3 CurrentPosition => transform.position;
    private Vector3 CurrentTarget => new Vector3(points[currentPointIndex].x, CurrentPosition.y, CurrentPosition.z);

    public float rotationSpeed = 90.0f; // Velocidad de rotación en grados por segundo
    public bool clockwiseRotation = false; // Variable para controlar la dirección de rotación (true para rotar en sentido horario, false para antihorario)
    
    private bool isRotating = false; // Indicador de si el objeto se está rotando
    private float rotationStartTime; // Tiempo en el que se inició la rotación
    private bool hasRotated = false; // Indicador de si ya se ha realizado la rotación

    void Update()
    {
        if (!hasRotated)
        {
            if (isMoving)
            {
                MoveObjectOnX();
            }
            else
            {
                currentTime += Time.deltaTime;
                if (currentTime >= waitTime)
                {
                    isRotating = true;
                    rotationStartTime = Time.time;
                    hasRotated = true;
                }
            }
        }
        else
        {
            RotateObjectOnY();
        }
    }

    void MoveObjectOnX()
    {
        // Tu código de movimiento en X aquí (similar al código anterior)

        // Cuando se alcance el punto objetivo en X, cambia a espera
        if (Mathf.Abs(CurrentTarget.x - CurrentPosition.x) < 0.1f)
        {
            isMoving = false;
            currentTime = 0.0f;
        }
    }

    void RotateObjectOnY()
    {
        if (isRotating)
        {
            // Calcula el ángulo de rotación gradualmente
            float rotationAngle = Mathf.Lerp(0, 90.0f * (clockwiseRotation ? -1.0f : 1.0f), (Time.time - rotationStartTime) * rotationSpeed);

            // Realiza la rotación en el eje Y
            transform.rotation = Quaternion.Euler(0, rotationAngle, 0);

            // Cuando se alcanza el ángulo de rotación deseado, detiene la rotación
            if (Mathf.Abs(rotationAngle) >= 90.0f)
            {
                isRotating = false;
            }
        }
    }
}
