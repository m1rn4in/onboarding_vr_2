using UnityEngine;
using UnityEngine.Video;

public class CerrarVideo : MonoBehaviour
{
    public VideoPlayer video;
    public double delayTime = 10.0; // Segundos de retraso antes de que comience la reproducci�n.

    private bool hasStarted = false;

    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.playOnAwake = false; // Desactiva la reproducci�n autom�tica en Awake.
        video.loopPointReached += CheckOver;
    }

    void Update()
    {
        if (!hasStarted)
        {
            delayTime -= Time.deltaTime;

            if (delayTime <= 0)
            {
                video.Play(); // Inicia la reproducci�n del video despu�s del retraso.
                hasStarted = true;
            }
        }
        
        // Puedes agregar l�gica adicional aqu� si es necesario.
    }

    void CheckOver(VideoPlayer vp)
    {
        // Desactiva el objeto que contiene el VideoPlayer cuando se alcanza el punto final.
        gameObject.SetActive(false);
    }
}
