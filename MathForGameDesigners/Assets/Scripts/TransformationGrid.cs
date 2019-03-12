using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationGrid : MonoBehaviour {

    public Transform prefab; //holds the cube prefab that makes up the grid. Can be any prefab

    public int gridResolution = 10; //dictates how big the grid will be. default: 10x10

    Transform[] grid; //the array that holds all of the cube transforms in the grid
    
    List<Transformation> transformations; //Holds the transformations as they are applied to the grid
    
    //A unified matrix for all transformations
    Matrix4x4 transformation;

    void Awake () {
        //When this object becomes Awake, it spawns a grid
        grid = new Transform[gridResolution * gridResolution * gridResolution];
        //This for loop iterates along the z, x, and y axes until it hits gridResolution size, spawning cubes as it goes
        for (int i = 0, z = 0; z < gridResolution; z++) {
            for (int y = 0; y < gridResolution; y++) {
                for (int x = 0; x < gridResolution; x++, i++) {
                    grid[i] = CreateGridPoint(x, y, z);
                }
            }
        }
        
        //Initialization
        transformations = new List<Transformation>();
    }
    
    void Update () {
        UpdateTransformation();
        //Actually applies the changes to each point
        for (int i = 0, z = 0; z < gridResolution; z++) {
            for (int y = 0; y < gridResolution; y++) {
                for (int x = 0; x < gridResolution; x++, i++) {
                    grid[i].localPosition = TransformPoint(x, y, z);
                }
            }
        }
    }
    
    //Iterates through the points applying the whole transformation matrix to each point
    void UpdateTransformation () {
        GetComponents<Transformation>(transformations);
        if (transformations.Count > 0) {
            transformation = transformations[0].Matrix;
            for (int i = 1; i < transformations.Count; i++) {
                transformation = transformations[i].Matrix * transformation;
            }
        }
    }
    
    //Performs the matrix multiplication using the newly made matrix
    Vector3 TransformPoint (int x, int y, int z) {
        Vector3 coordinates = GetCoordinates(x, y, z);
        return transformation.MultiplyPoint(coordinates);
    }
    
    //This spawns a prefab at the location given by the for loop in Awake
    Transform CreateGridPoint (int x, int y, int z) {
        Transform point = Instantiate<Transform>(prefab); //here's where the instantiation happens
        point.localPosition = GetCoordinates(x, y, z); //moves the prefab to the correct spot
        //Sets the color of the cube to a new color using the positional vector
        point.GetComponent<MeshRenderer>().material.color = new Color(
            (float)x / gridResolution,
            (float)y / gridResolution,
            (float)z / gridResolution
        );
        return point; //returns the Transform it just created
    }
    
    //Converts the x, y, and z values in Awake into positions
    Vector3 GetCoordinates (int x, int y, int z) {
        return new Vector3(
            x - (gridResolution - 1) * 0.5f,
            y - (gridResolution - 1) * 0.5f,
            z - (gridResolution - 1) * 0.5f
        );
    }
}

//Master class for our transformation code
//Holds an Apply function that any subclass can use
public abstract class Transformation : MonoBehaviour {

    //Multiplies the Transformation matrices from each subclass
    public Vector3 Apply (Vector3 point) {
        return Matrix.MultiplyPoint(point);
    }
    
    public abstract Matrix4x4 Matrix { get; } //used to grab the Matrix from our Transformation subclasses
}
