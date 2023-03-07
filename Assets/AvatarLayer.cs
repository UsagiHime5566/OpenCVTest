using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenCVForUnity.CoreModule;

public class AvatarLayer : MonoBehaviour
{
    RawImage rawImage;
    public Texture2D currentTex;

    void Awake(){
        rawImage = GetComponent<RawImage>();
    }

    public void SetDisplay(Texture2D tex){
        currentTex = tex;
        rawImage.texture = tex;
    }

    void OnDestroy() {
        if(currentTex != null)
            Destroy(currentTex);
    }
}
