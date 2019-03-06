using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMatrix : MonoBehaviour
{
    
    public Vector3 shearing;
    public float theta;
    
    private Camera cam;
    public Matrix4x4 originalCamProjMatrix;
    private Matrix4x4 XShearing = Matrix4x4.identity;
    private Matrix4x4 YShearing = Matrix4x4.identity;
    private Matrix4x4 matrixRotate = Matrix4x4.identity;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        originalCamProjMatrix = cam.projectionMatrix;
    }

    // Update is called once per frame
    void Update()
    {
       // cam.projectionMatrix = camProjMatrix; //gives me manual control in editor
        Shear();
        RotateCameraProj();
        ProjUpdate();
    }

    public void Shear()
    {
        XShearing[0, 1] = shearing.x;
        YShearing[1, 0] = shearing.y;
    }

    public void RotateCameraProj()
    {
        matrixRotate[0, 0] = Mathf.Cos(theta);
        matrixRotate[0, 1] = Mathf.Sin(theta);
        matrixRotate[1, 0] = -Mathf.Sin(theta);
        matrixRotate[1, 1] = Mathf.Cos(theta);

        
    }

    public void ProjUpdate()
    {
        cam.projectionMatrix = originalCamProjMatrix * matrixRotate * XShearing * YShearing;
    }
}
