using UnityEngine;

public class MoveX : MonoBehaviour
{
    public float translationSpeed = 5.0f; // Velocidad de traslación en el eje X
    public Vector3[] points; // Puntos a los que se moverá el objeto en el eje X
    public float waitTime = 10.0f; // Tiempo de espera en cada punto en segundos

    private int currentPointIndex = 0; // Índice del punto actual
    private float currentTime = 0.0f; // Contador de tiempo para el tiempo de espera
    private bool isMoving = true; // Indicador de si el objeto se está moviendo o esperando

    private Vector3 CurrentPosition => transform.position;
    private Vector3 CurrentTarget => new Vector3(points[currentPointIndex].x, CurrentPosition.y, CurrentPosition.z);

    void Update()
    {
        MoveObjectOnX();
    }

    void MoveObjectOnX()
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
            // Calcula la diferencia en el eje X entre la posición actual y el punto objetivo
            float distanceX = CurrentTarget.x - CurrentPosition.x;

            // Realiza la traslación en el eje X
            float translationDirectionX = Mathf.Sign(distanceX);
            float translationX = translationSpeed * Time.deltaTime * translationDirectionX;
            transform.Translate(translationX, 0, 0);

            // Comprueba si se ha alcanzado el punto objetivo en el eje X
            if (Mathf.Abs(distanceX) < 0.1f)
            {
                isMoving = false;
                currentTime = 0.0f;
                currentPointIndex++;

                if (currentPointIndex >= points.Length)
                {
                    transform.position = new Vector3(points[points.Length - 1].x, CurrentPosition.y, CurrentPosition.z);
                }
            }
        }
    }
}
