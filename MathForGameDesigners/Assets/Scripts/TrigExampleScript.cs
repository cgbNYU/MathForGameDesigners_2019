using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrigExampleScript : MonoBehaviour
{
    private LineRenderer myLine;
    List<Vector3> positionList = new List<Vector3>();

    public float lengthA = 1f;
    public float speedA;

    public float lengthB;
    public float speedB;

    public float lengthC;
    public float speedC;

    public GameObject trailObj;
    public GameObject trailObj2;
    
    // Start is called before the first frame update
    void Start()
    {
        myLine = GetComponent<LineRenderer>();
        myLine.positionCount = 0;
        positionList.Add(Vector3.zero);
        positionList.Add(Vector3.zero);
        positionList.Add(Vector3.zero);
        positionList.Add(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        positionList[1] = PointOnCircle(Time.time * speedA, lengthA);
        positionList[2] = positionList[1] + PointOnCircle(Time.time * speedB, lengthB);
        positionList[3] = positionList[2] + PointOnCircle(Time.time * speedC, lengthC);
        UpdatePoints();
        trailObj.transform.position = positionList[positionList.Count - 2];
        trailObj2.transform.position = positionList[positionList.Count - 1];
    }

    //Sets the position count to the length of the list of positions
    //Sets the positions from the positionList
    public void UpdatePoints()
    {
        myLine.positionCount = positionList.Count;     
        myLine.SetPositions(positionList.ToArray());
    }
    
    //Angle is in Radians
    public Vector3 PointOnCircle(float angle, float radius)
    {
        return new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
    }
}
