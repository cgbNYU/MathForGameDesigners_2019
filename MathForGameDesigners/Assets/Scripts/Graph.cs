using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    public Transform pointPrefab;
    [Range(10, 100)] public int resolution = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = new Vector3(0, 0, 0);
        for (int i = 0; i < resolution; i++) 
        {
            
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x;
            point.localPosition = position;
            point.localScale = scale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
