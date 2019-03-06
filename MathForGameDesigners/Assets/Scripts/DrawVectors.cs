using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVectors : MonoBehaviour
{

    public GameObject objectA, objectB;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        //Let's draw a line to each object
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, objectB.transform.position);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, objectA.transform.position);
        
        //Draw ObjectA's facing
        Gizmos.color = Color.green;
        //Gizmos.DrawLine(objectA.transform.position, objectA.transform.position + objectA.transform.forward);
        Gizmos.DrawRay(objectA.transform.position, objectA.transform.forward);
        
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(objectB.transform.position, objectB.transform.position + objectB.transform.forward);
        Gizmos.DrawRay(objectB.transform.position, objectB.transform.forward);
        
        //Dot product time
        Vector3 dotProductVector = Vector3.up * Vector3.Dot(objectA.transform.forward, objectB.transform.forward);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + dotProductVector);
        
        //Dot product of A and B position
        Vector3 positonDotProductVect =
            Vector3.up * Vector3.Dot(objectA.transform.position.normalized, objectB.transform.position.normalized);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + positonDotProductVect);
    }
}
