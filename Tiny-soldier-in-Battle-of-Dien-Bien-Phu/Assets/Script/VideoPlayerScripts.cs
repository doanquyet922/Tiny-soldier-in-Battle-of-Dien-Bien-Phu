using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerScripts : MonoBehaviour
{
    VideoPlayer videoPlayer;
    bool fin = false;
    public RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
}
