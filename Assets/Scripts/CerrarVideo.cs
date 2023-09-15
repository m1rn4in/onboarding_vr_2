using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CerrarVideo : MonoBehaviour
{
    public VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    void Start()
    {
    }

    void Update()
    {
    }

    void CheckOver(VideoPlayer vp)
    {
        // Desactiva el objeto que contiene el VideoPlayer cuando se alcanza el punto final.
        gameObject.SetActive(false);
    }
}
