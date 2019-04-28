using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibNoise;
using LibNoise.Generator;

public class SubRandom : MonoBehaviour
{

    public int RandomCalls = 50;
    private List<float> normalVals = new List<float>();
    private List<float> randomVals = new List<float>();
    private List<float> perlinVals = new List<float>();
    private List<float> subRandomVals = new List<float>();
    private List<float> curvedVals = new List<float>();
    public AnimationCurve randDistro;
    
    // Start is called before the first frame update
    void Start()
    {
        CalcRandomLines();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalcRandomLines();
        }
    }

    private void CalcRandomLines()
    {
        normalVals.Clear();
        randomVals.Clear();
        perlinVals.Clear();
        subRandomVals.Clear();
        curvedVals.Clear();
        //Set pattern, no randomness
        for (int i = 0; i < RandomCalls; i++)
        {
            normalVals.Add((float)i / (float)RandomCalls);
        }
        
        //pure random
        for (int i = 0; i < RandomCalls; i++)
        {
            randomVals.Add(Random.value);
        }
        
        //perlin noise
        Perlin pNoise = new Perlin(0.6, 2, 0.2, 6, Random.Range(0, 10), QualityMode.Medium);
        for (int i = 0; i < RandomCalls; i++)
        {
            perlinVals.Add((float)pNoise.GetValue((double)i, (double)i, 0));
        }
        
        //sub randomness
        float subRegions = RandomCalls;
        float subRange = 1f / subRegions;
        for (int i = 0; i < RandomCalls; i++)
        {
            subRandomVals.Add(Random.value * subRange);
            subRandomVals[i] += ((float) i % subRegions) / subRegions;
        }
        
        //curved randomness
        for (int i = 0; i < RandomCalls; i++)
        {
            curvedVals.Add(randDistro.Evaluate(Random.value));
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            for (int i = 0; i < RandomCalls; i++)
            {
                //normal vals
                float offset = 25f;
                Vector3 drawFrom = new Vector3(normalVals[i] * 100f, offset, 0);
                Vector3 drawTo = new Vector3(drawFrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawFrom, drawTo);
                
                //random vals
                offset = 20f;
                drawFrom = new Vector3(randomVals[i] * 100f, offset, 0);
                drawTo = new Vector3(drawFrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawFrom, drawTo);
                
                //perlin vals
                offset = 15f;
                drawFrom = new Vector3(perlinVals[i] * 100f, offset, 0);
                drawTo = new Vector3(drawFrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawFrom, drawTo);
                
                //subRandom vals
                offset = 10f;
                drawFrom = new Vector3(subRandomVals[i] * 100f, offset, 0);
                drawTo = new Vector3(drawFrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawFrom, drawTo);
                
                //curved vals
                offset = 5f;
                drawFrom = new Vector3(curvedVals[i] * 100f, offset, 0);
                drawTo = new Vector3(drawFrom.x, offset + 3f, 0);
                Gizmos.DrawLine(drawFrom, drawTo);
            }
        }
    }
}
