using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTransformation : Transformation
{
    public Vector3 rotation; //the new rotation to apply


    public override Matrix4x4 Matrix
    {
        get
        {
            //Controls all rotation
            float radX = rotation.x * Mathf.Deg2Rad; //simple conversion from degrees to radians
            float radY = rotation.y * Mathf.Deg2Rad; //simple conversion from degrees to radians
            float radZ = rotation.z * Mathf.Deg2Rad; //simple conversion from degrees to radians

            //These points calculate the position along the SINE and COSINE waves each y and x coordinate lands, respectively
            float sinX = Mathf.Sin(radX+Time.time);
            float cosX = Mathf.Cos(radX+Time.time);
            float sinY = Mathf.Sin(radY+Time.time);
            float cosY = Mathf.Cos(radY+Time.time);
            float sinZ = Mathf.Sin(radZ+Time.time); //the y position moves along a SINE wave during rotation, so this does that
            float cosZ = Mathf.Cos(radZ+Time.time); //x moves along COSINE

            //Each of these vectors represents a single column of the rotation matrix created by multiplying all 3 axes
            Matrix4x4 matrix = new Matrix4x4();
            matrix.SetColumn(0, new Vector4(
                cosY * cosZ,
                cosX * sinZ + sinX * sinY * cosZ,
                sinX * sinZ - cosX * sinY * cosZ, 0f
            ));
            matrix.SetColumn(1, new Vector4(
                -cosY * sinZ,
                cosX * cosZ - sinX * sinY * sinZ,
                sinX * cosZ + cosX * sinY * sinZ, 0f
            ));
            matrix.SetColumn(2, new Vector4(
                sinY,
                -sinX * cosY,
                cosX * cosY, 0f
            ));

            //The final fourth column is always the same
            matrix.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
            
            //sends the completed matrix back out
            return matrix;
        }
    }
}
