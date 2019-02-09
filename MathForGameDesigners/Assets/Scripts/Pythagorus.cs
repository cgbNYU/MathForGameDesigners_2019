using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pythagorus : MonoBehaviour
{

    public Transform a; 
    public Transform b;
    public Transform c; //this one scales and the others follow
    
    // Start is called before the first frame update
    void Start()
    {
        c.localScale = new Vector3(2,2,2);
    }

    // Update is called once per frame
    void Update()
    {
        PythScale();
    }

    public void PythScale()
    {
        //Set Cube a via pythagorean theorum
        float aScale = Mathf.Sqrt(Mathf.Pow(c.localScale.x, 2) - Mathf.Pow(b.localScale.x, 2));
        a.localScale = new Vector3(aScale, aScale, aScale);
        
        //Set Cube b via pythagorean theorum
        float bScale = Mathf.Sqrt(Mathf.Pow(c.localScale.x, 2) - Mathf.Pow(a.localScale.x, 2));
        b.localScale = new Vector3(bScale, bScale, bScale);
    }
}
