using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float translationSpeed = 5.0f; // Velocidad de traslaci�n en el eje X
    public Vector3[] points; // Puntos a los que se mover� el objeto en el eje X
    public float waitTime = 10.0f; // Tiempo de espera en cada punto en segundos

    private int currentPointIndex = 0; // �ndice del punto actual en X
    private float currentTime = 0.0f; // Contador de tiempo para el tiempo de espera
    private bool isMoving = true; // Indicador de si el objeto se est� moviendo o esperando

    private Vector3 CurrentPosition => transform.position;
    private Vector3 CurrentTarget => new Vector3(points[currentPointIndex].x, CurrentPosition.y, CurrentPosition.z);

    public float rotationSpeed = 90.0f; // Velocidad de rotaci�n en grados por segundo
    public bool clockwiseRotation = false; // Variable para controlar la direcci�n de rotaci�n (true para rotar en sentido horario, false para antihorario)
    
    private bool isRotating = false; // Indicador de si el objeto se est� rotando
    private float rotationStartTime; // Tiempo en el que se inici� la rotaci�n
    private bool hasRotated = false; // Indicador de si ya se ha realizado la rotaci�n

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
        // Tu c�digo de movimiento en X aqu� (similar al c�digo anterior)

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
            // Calcula el �ngulo de rotaci�n gradualmente
            float rotationAngle = Mathf.Lerp(0, 90.0f * (clockwiseRotation ? -1.0f : 1.0f), (Time.time - rotationStartTime) * rotationSpeed);

            // Realiza la rotaci�n en el eje Y
            transform.rotation = Quaternion.Euler(0, rotationAngle, 0);

            // Cuando se alcanza el �ngulo de rotaci�n deseado, detiene la rotaci�n
            if (Mathf.Abs(rotationAngle) >= 90.0f)
            {
                isRotating = false;
            }
        }
    }
}
