using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private static string PLAYER_TAG = "PlayerTag";
    private Transform myCharTransform;
    private Vector3 tmpPosition;
    [SerializeField]
    private float maxLeft, maxRight;
    // Start is called before the first frame update
    void Start()
    {
        myCharTransform = GameObject.FindWithTag(PLAYER_TAG).transform;
        
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
        if (myCharTransform != null)
        {
            tmpPosition = transform.position;
            tmpPosition.x = myCharTransform.position.x;
            //move the camera to myCharPosition
            if (tmpPosition.x > maxRight) tmpPosition.x = maxRight;
            if (tmpPosition.x < maxLeft) tmpPosition.x = maxLeft;
            transform.position = tmpPosition;
        }
    }
}
