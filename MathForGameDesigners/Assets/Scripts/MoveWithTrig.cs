using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTrig : MonoBehaviour
{

    [Range(0, 2 * Mathf.PI)] public float theta = 0;

    public float r = 5;

    public float speed = 1;

    public bool isSpiral = false;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpiral)
        {
            transform.position = PointOnCircle(Time.time * speed, r * Mathf.Sin(Time.time));
        }
        else
        {
            transform.position = PointOnCircle(Time.time * speed, r);
        }
        
        /*Vector3 newpos = transform.position;

        newpos.z = Time.time;

        transform.position = newpos;*/
    }

    //Angle is in Radians
    public Vector3 PointOnCircle(float angle, float radius)
    {
        return new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
    }
    
}
