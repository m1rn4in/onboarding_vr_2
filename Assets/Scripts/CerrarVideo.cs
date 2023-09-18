using UnityEngine;
using UnityEngine.Video;

public class CerrarVideo : MonoBehaviour
{
    public VideoPlayer video;
    public double delayTime = 10.0; // Segundos de retraso antes de que comience la reproducción.

    private bool hasStarted = false;

    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.playOnAwake = false; // Desactiva la reproducción automática en Awake.
        video.loopPointReached += CheckOver;
    }

    void Update()
    {
        if (!hasStarted)
        {
            delayTime -= Time.deltaTime;

            if (delayTime <= 0)
            {
                video.Play(); // Inicia la reproducción del video después del retraso.
                hasStarted = true;
            }
        }
        
        // Puedes agregar lógica adicional aquí si es necesario.
    }

    void CheckOver(VideoPlayer vp)
    {
        // Desactiva el objeto que contiene el VideoPlayer cuando se alcanza el punto final.
        gameObject.SetActive(false);
    }
}
