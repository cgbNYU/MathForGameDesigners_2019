using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOnCircleColor : MonoBehaviour
{

    private SpriteRenderer sprite;

    [Range(0, 1)] public float Hue;
    [Range(0, 1)] public float Sat;
    [Range(0, 1)] public float Val;

    public float speed;
    public float r;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 changingColor = PointOnCircle(Hue * Time.time, Sat);
        sprite.color = Color.HSVToRGB(changingColor.x, changingColor.y, changingColor.z, true);
    }
    
    public Vector3 PointOnCircle(float angle, float radius)
    {
        return new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), Val);
    }
}
