using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    //Public variables
    public int SpawnNum = 12;
    public GameObject SpawnObject;
    public float SpawnRadius = 1; //Should remain at 1 probably but can be used to expand unit circle
    
    //Private variables
    private List<GameObject> objects = new List<GameObject>(); //holds the objects to spawn
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObjects()
    {
        float spawnAngles = (Mathf.PI * 2) / SpawnNum; //how far apart each object is

        for (int i = 0; i < SpawnNum; i++)
        {
            float theta = spawnAngles * i; //increment the object angle
            GameObject newSpawn = Instantiate(SpawnObject); //instantiate the object
            
            newSpawn.transform.SetParent(gameObject.transform); //parent this object to the spawn location
            newSpawn.transform.position = transform.position; //move the object to the center of the spawn
            newSpawn.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Rad2Deg * theta));
            newSpawn.transform.position += new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0); //move into position around the circle
        }
    }
}
