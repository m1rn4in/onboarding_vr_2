using UnityEngine;

public class MoveRotMove : MonoBehaviour
{
    public float translationSpeedX = 5.0f; // Velocidad de traslación en el eje X
    public Vector3[] pointsX; // Puntos a los que se moverá el objeto en el eje X
    public float waitTimeX = 10.0f; // Tiempo de espera en cada punto en segundos

    private int currentPointIndexX = 0; // Índice del punto actual en X
    private float currentTimeX = 0.0f; // Contador de tiempo para el tiempo de espera en X
    private bool isMovingX = true; // Indicador de si el objeto se está moviendo en X

    private Vector3 CurrentPosition => transform.position;
    private Vector3 CurrentTargetX => new Vector3(pointsX[currentPointIndexX].x, CurrentPosition.y, CurrentPosition.z);

    public float rotationSpeedY = 90.0f; // Velocidad de rotación en grados por segundo
    public bool clockwiseRotation = false; // Variable para controlar la dirección de rotación (true para rotar en sentido horario, false para antihorario)

    private bool isRotatingY = false; // Indicador de si el objeto se está rotando en Y
    private float rotationStartTimeY; // Tiempo en el que se inició la rotación en Y
    private bool hasRotatedY = false; // Indicador de si ya se ha realizado la rotación en Y

    // Puntos a los que se moverá el objeto en el eje Z
    public float translationSpeedZ = 5.0f; // Velocidad de traslación en el eje Z
    public Vector3[] pointsZ; 
    public float waitTimeZ = 10.0f; // Tiempo de espera en cada punto en segundos para Z

    private int currentPointIndexZ = 0; // Índice del punto actual en Z
    private float currentTimeZ = 0.0f; // Contador de tiempo para el tiempo de espera en Z
    private bool isMovingZ = false; // Indicador de si el objeto se está moviendo en Z

    private Vector3 CurrentTargetZ => new Vector3(CurrentPosition.x, CurrentPosition.y, pointsZ[currentPointIndexZ].z);

    void Update()
    {
        if (!hasRotatedY)
        {
            if (isMovingX)
            {
                MoveObjectOnX();
            }
            else
            {
                currentTimeX += Time.deltaTime;
                if (currentTimeX >= waitTimeX)
                {
                    isRotatingY = true;
                    rotationStartTimeY = Time.time;
                    hasRotatedY = true;
                }
            }
        }
        else if (!isMovingZ)
        {
            currentTimeZ += Time.deltaTime;
            if (currentTimeZ >= waitTimeZ)
            {
                isMovingZ = true;
                currentTimeZ = 0.0f;
            }
        }
        else
        {
            MoveObjectOnZ();
        }
    }

    void MoveObjectOnX()
    {
        float distanceX = CurrentTargetX.x - CurrentPosition.x;
        float translationDirectionX = Mathf.Sign(distanceX);
        float translationX = translationSpeedX * Time.deltaTime * translationDirectionX;
        transform.Translate(translationX, 0, 0);

        // Cuando se alcance el punto objetivo en X, cambia a espera
        if (Mathf.Abs(distanceX) < 0.1f)
        {
            isMovingX = false;
            currentTimeX = 0.0f;
        }
    }

    void MoveObjectOnZ()
    {
        float distanceZ = CurrentTargetZ.z - CurrentPosition.z;
        float translationDirectionZ = Mathf.Sign(distanceZ);
        float translationZ = translationSpeedZ * Time.deltaTime * translationDirectionZ;
        transform.Translate(0, 0, translationZ);

        if (Mathf.Abs(distanceZ) < 0.1f)
        {
            isMovingZ = false;
            currentTimeZ = 0.0f;
            currentPointIndexZ++;

            if (currentPointIndexZ >= pointsZ.Length)
            {
                // Has llegado al último punto en Z, puedes reiniciar valores o realizar otras acciones aquí si es necesario
            }
        }
    }
}
