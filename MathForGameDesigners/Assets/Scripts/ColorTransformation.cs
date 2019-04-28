using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTransformation : Transformation
{
    //The new position to be applied
    public Vector3 colorAxis;
    
    //creates the Position transformation matrix
    public override Matrix4x4 Matrix
    {
        get
        {
            Matrix4x4 matrix = new Matrix4x4();
            matrix.SetRow(0, new Vector4(1f, 0f, 0f, colorAxis.x));
            matrix.SetRow(1, new Vector4(0f, 1f, 0f, colorAxis.y));
            matrix.SetRow(2, new Vector4(0f, 0f, 1f, colorAxis.z));
            matrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
            return matrix;
        }
    }
}
