using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCorner : MonoBehaviour
{

    public Transform followCorner;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followCorner.position;
    }
}
