using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks to see if the enemy can see the player and turns the enemy to a hostile state if so
public class ViewCone : MonoBehaviour
{
    
    //Hold onto player transform
    private Transform playerTransform;

    private bool hasSeen;
    
    //Public variables
    public float viewAngle = 30;
    public LineRenderer LaserLine;
    public ScreenShake ScreenShake;
    [Range(0, 1)]
    public float AccuracyPercentage;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Rotator").transform; //initialize playerTransform
        hasSeen = false;
        LaserLine = GetComponent<LineRenderer>();
        LaserLine.SetPosition(0, transform.position);
        LaserLine.SetPosition(1, transform.position);
        ScreenShake = GameObject.Find("CameraParent").GetComponent<ScreenShake>();
    }

    // Update is called once per frame
    void Update()
    {
        ViewCheck();
    }

    //Checks to see if the player is within a cone of view width viewAngle degrees
    private void ViewCheck()
    {
        var cone = Mathf.Cos(viewAngle * Mathf.Deg2Rad);
        var heading = (playerTransform.position - transform.position).normalized;

       if (!hasSeen)
       {
            if (Vector3.Dot(transform.right, heading) > cone)
            {
                hasSeen = true;
                Laser();
            }
       }

       if (hasSeen)
       {
            if (Vector3.Dot(transform.right, heading) < cone)
            {
                hasSeen = false;
                StartCoroutine(LaserOff());
            }
       }
    }

    private void Laser()
    {
        //a hit
        if (Random.value <= AccuracyPercentage)
        {
            ScreenShake.isShake = true;
            LaserLine.SetPosition(1, playerTransform.position);
        }
        else
        {
            Vector3 cross = Vector3.Cross(playerTransform.position - transform.position, Vector3.back);
            if(Random.value <= 0.5)
                LaserLine.SetPosition(1, playerTransform.position + cross.normalized);
            else
                LaserLine.SetPosition(1, playerTransform.position - cross.normalized);
        }
    }

    IEnumerator LaserOff()
    {
        yield return new WaitForSeconds(0.25f);
        LaserLine.SetPosition(1, transform.position);
    }
}
