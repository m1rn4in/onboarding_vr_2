using UnityEngine;

public class MoveZ : MonoBehaviour
{
    public float translationSpeedZ = 5.0f; // Velocidad de traslación en el eje Z
    public Vector3[] movePoints; // Puntos a los que se moverá el objeto en el eje Z
    public float waitTime = 10.0f; // Tiempo de espera en cada punto en segundos

    private int currentPointIndex = 0; // Índice del punto actual
    private float currentTime = 0.0f; // Contador de tiempo para el tiempo de espera
    private bool isMoving = true; // Indicador de si el objeto se está moviendo o esperando

    private Vector3 CurrentPosition => transform.position;
    private Vector3 CurrentTarget => new Vector3(CurrentPosition.x, CurrentPosition.y, movePoints[currentPointIndex].z);

    void Update()
    {
        MoveObjectOnZ();
    }

    void MoveObjectOnZ()
    {
        if (!isMoving)
        {
            // Espera un tiempo antes de continuar
            currentTime += Time.deltaTime;

            if (currentTime >= waitTime)
            {
                isMoving = true;
                currentTime = 0.0f;
            }
        }
        else
        {
            // Calcula la diferencia en el eje Z entre la posición actual y el punto objetivo
            float distanceZ = CurrentTarget.z - CurrentPosition.z;

            // Realiza la traslación en el eje Z
            float translationDirectionZ = Mathf.Sign(distanceZ);
            float translationZ = translationSpeedZ * Time.deltaTime * translationDirectionZ;
            transform.Translate(0, 0, translationZ);

            // Comprueba si se ha alcanzado el punto objetivo en el eje Z
            if (Mathf.Abs(distanceZ) < 0.1f)
            {
                isMoving = false;
                currentTime = 0.0f;
                currentPointIndex++;

                if (currentPointIndex >= movePoints.Length)
                {
                    transform.position = new Vector3(CurrentPosition.x, CurrentPosition.y, movePoints[movePoints.Length - 1].z);
                }
            }
        }
    }
}
