using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualObjetiveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftTarget;
    public Transform RightTarget;
    public float minDistance = 1;
    public int num = 1;
    public int num2 = 2;
    public float centerCameraPosition;
    public float DistanceTargets;
    public float cameraTry;
    public float myCamera;
    // Update is called once per frame
    void Update()
    {
        DistanceTargets = Mathf.Abs((leftTarget.position.x - RightTarget.position.x));
        centerCameraPosition = (leftTarget.position.x + RightTarget.position.x) / 2;
        
        
    }
    

        

    
}
