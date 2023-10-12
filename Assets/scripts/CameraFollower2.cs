using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower2 : MonoBehaviour
{
    private Transform myCharTransform;
    private Vector3 tmpPosition;

    // Start is called before the first frame update
    void Start()
    {
        myCharTransform = GameObject.FindWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        moveCamera();
    }
    void moveCamera()
    {
        tmpPosition = transform.position;
        tmpPosition.x = myCharTransform.position.x;
        //move the camera to myCharPosition
        transform.position = tmpPosition;
    }
}
