using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using LibNoise;
using LibNoise.Generator;

public class DrawPixels : MonoBehaviour
{

    public RawImage myImage; //Image that will be created to hold pixels
    private Texture2D drawImage; //This will actually draw the image

    //These determine the resolution of the image used to render the pixels
    [Range(1, 1000)] 
    public int size;
    
    // Start is called before the first frame update
    void Start()
    {
        PixelDraw();
        SubRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SubRandomColor();
        }
    }

    void PixelDraw()
    {
        //create a new image and set it to drawimage
        drawImage = new Texture2D(size, size, TextureFormat.ARGB32, false); 
        
        //Turn off anti-aliasing
        drawImage.filterMode = FilterMode.Point;
        
        //set a default color for the pixels and set the alpha to 0 to make it a transparent background
        Color defaultColor = Color.blue;
        defaultColor.a = 0;
        
        //make an array to hold each pixel and run a for loop
        Color[] colorArray = new Color[drawImage.height * drawImage.height];
        for (int i = 0; i < colorArray.Length; i++)
        {
            colorArray[i] = defaultColor;
        }
        
        //Put the array into drawImage and apply it because you have to
        drawImage.SetPixels(colorArray);
        drawImage.Apply();
        
        //Set the image to look like drawImage
        myImage.texture = drawImage;
        
        //Draw a line
        //DrawLine(drawImage, Color.red, 1, 1, 45, 45);
        SubRandomColor();
    }

    void RandomColors()
    {
        //make an array to hold each pixel and run a for loop
        Color[] colorArray = new Color[drawImage.height * drawImage.height];
        for (int i = 0; i < colorArray.Length; i++)
        {
            colorArray[i] = new Color(Random.value, Random.value, Random.value);
        }
        
        //Put the array into drawImage and apply it because you have to
        drawImage.SetPixels(colorArray);
        drawImage.Apply();
    }

    void PerlinColors()
    {
        Color[] colorArray = new Color[drawImage.height * drawImage.height];
        //perlin noise
        Perlin pNoise = new Perlin(0.6, 2, 0.2, 6, Random.Range(0, 10), QualityMode.Medium);
        for (int i = 0; i < colorArray.Length; i++)
        {
           // colorArray[i] = new Color(pNoise.GetValue();
        }
    }

    void SubRandomColor()
    {
        Color[] colorArray = new Color[drawImage.height * drawImage.height];
        //sub randomness
        float subRegions = colorArray.Length;
        float subRange = 10f / subRegions;
        
        for (int i = 0; i < colorArray.Length; i++)
        {
            subRange += ((float) i % subRegions) / subRegions;
            Color nextColor = new Color(Random.value + subRange, Random.value + subRange, Random.value + subRange);
            colorArray[i] = nextColor;
        }
        drawImage.SetPixels(colorArray);
        drawImage.Apply();
    }

    void DrawLine(Texture2D texture, Color color, int x1, int y1, int x2, int y2)
    {
        texture.SetPixel(x1, y1, color);
        texture.SetPixel(x2, y2, color);
        texture.Apply(); 
    }
}
