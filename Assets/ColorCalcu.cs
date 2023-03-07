using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCalcu : MonoBehaviour
{
    public RenderTexture rt;
    public RawImage ShowImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            CalcuPix();
        }
    }

    void CalcuPix(){
        IsNoPersion();
    }

    Texture2D SavedTexture;
    public bool IsNoPersion(){
        if(rt != null){
            if(SavedTexture != null)
            {
                Destroy(SavedTexture);
            }

            // SavedTexture = new Texture2D(rt.width, rt.height, TextureFormat.RGBA32, false);
            // Graphics.CopyTexture(rt, SavedTexture);
            // SavedTexture.Apply();
            // Color[] pixels = SavedTexture.GetPixels();

            SavedTexture = new Texture2D(rt.width, rt.height, TextureFormat.RGBA32, false);
            RenderTexture.active = rt;
            SavedTexture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            RenderTexture.active = null;
            SavedTexture.Apply();

            Color[] pixels = SavedTexture.GetPixels();


            ShowImage.texture = SavedTexture;

            float totalPixel = 0;

            foreach (var p in pixels)
            {
                totalPixel += p.r;
            }

            Debug.Log($"Total Pix val : {totalPixel}");
            if(totalPixel > 10) return true;
        }

        return false;
    }
}
