using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class Pythagorus : MonoBehaviour
{

    //Boxes
    public Transform a; 
    public Transform b;
    public Transform c; //this one scales and the others follow

    //Spheres
    public Transform x;
    public Transform y;
    
    //Scale variables for A and B
    public float aMinScale;
    public float aMaxScale;
    public float aDuration;

    public float bMinScale;
    public float bMaxScale;
    public float bDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScaleUpA());
        StartCoroutine(ScaleUpB());
    }

    // Update is called once per frame
    void Update()
    {
        PythCalc();
        AngleCalc();
    }

    //These functions scale the A and B cubes up and down over time
    IEnumerator ScaleUpA()
    {
        Tween aTween = a.DOScale(aMaxScale, aDuration);
        aTween.SetEase(Ease.Linear);
        
        yield return aTween.WaitForCompletion();
        StartCoroutine(ScaleDownA());
    }

    IEnumerator ScaleDownA()
    {
        Tween aTween = a.DOScale(aMinScale, aDuration);
        aTween.SetEase(Ease.Linear);
        
        yield return aTween.WaitForCompletion();
        StartCoroutine(ScaleUpA());
    }
    
    IEnumerator ScaleUpB()
    {
        Tween aTween = b.DOScale(bMaxScale, bDuration);
        aTween.SetEase(Ease.Linear);
        
        yield return aTween.WaitForCompletion();
        StartCoroutine(ScaleDownB());
    }

    IEnumerator ScaleDownB()
    {
        Tween aTween = b.DOScale(bMinScale, bDuration);
        aTween.SetEase(Ease.Linear);
        
        yield return aTween.WaitForCompletion();
        StartCoroutine(ScaleUpB());
    }

    //Calculates C cube's scale based on the current scale of A and B
    public void PythCalc()
    {
        //Set Cube C via pythagorean theorum
        float cScale = Mathf.Sqrt(Mathf.Pow(a.localScale.x, 2) + Mathf.Pow(b.localScale.x, 2));

        PythScale(cScale);
    }

    //Calculates the scale of the Angle Spheres using the size of the Cubes
    public void AngleCalc()
    {
        float xScale = Mathf.Acos(a.localScale.x / c.localScale.x);
        float yScale = Mathf.Acos(b.localScale.x / c.localScale.x);
        
        x.localScale = new Vector3(xScale, xScale, xScale);
        y.localScale = new Vector3(yScale, yScale, yScale);
    }
    
    //Scales the C cube
    public void PythScale(float scale)
    {
        c.localScale = new Vector3(scale, scale, scale);
    }
}
