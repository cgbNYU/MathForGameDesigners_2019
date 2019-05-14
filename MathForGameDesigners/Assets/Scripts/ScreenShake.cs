using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using LibNoise;
using LibNoise.Generator;

//Shake the camera around using various kinds of noise
//Attach this to a camera object
public class ScreenShake : MonoBehaviour
{
    //X Values
    public double XFrequency = 0.6;
    public double XLacunarity = 2;
    public double XPersistence = 0.2;
    public int XOctaves = 6;
    public int XSeed;
    
    //Y values
    public double YFrequency = 0.6;
    public double YLacunarity = 2;
    public double YPersistence = 0.2;
    public int YOctaves = 6;
    public int YSeed;
    
    //Publics
    public float ShakeTime;
    
    //Privates
    public Vector3 originalPosition;
    private Vector3 shakeRange = new Vector3(1, 1, 1);
    private double i = 0;
    private float timer;
    public bool isShake = false;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; //initialize starting pos
        
        //Randomize seeds
        XSeed = Random.Range(0, 10);
        YSeed = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isShake = true;
        Shake();
    }

    private void Shake()
    {
        if (isShake)
        {
            //perlin noise
            Perlin xNoise = new Perlin(XFrequency, XLacunarity, XPersistence, XOctaves, XSeed, QualityMode.Medium);
            Perlin yNoise = new Perlin(YFrequency, YLacunarity, YPersistence, YOctaves, YSeed, QualityMode.Medium);

            //Transform movement
            transform.position = originalPosition +
                Vector3.Scale(new Vector3((float) xNoise.GetValue(i, i, i), (float) yNoise.GetValue(i, i, i), 0),
                    shakeRange);
            
            shakeRange = new Vector3(shakeRange.x * -1, shakeRange.y);    

            //increment position along Perlin
            i++;
            
            //Increment timer
            timer += Time.deltaTime;
            if (timer >= ShakeTime)
            {
                isShake = false;
                timer = 0;
                i = 0;
                transform.position = originalPosition;
            }
        }
    }
}
