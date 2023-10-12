using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowInAndOut : MonoBehaviour
{
    [SerializeField] AnimationCurve animCurve;
    private Vector2 position;
    Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }
    void Start()
    {
        position = transform.position;
        Debug.Log("time of curve:" + animCurve.keys[animCurve.length - 1].time);
    }


    int count = 0;
    void Update()
    {
 
        time += Time.deltaTime;
        if (time <= 1)
        {
            MoveSlowInAndOut();
            count++;
        }
        
        if ( animCurve.keys[animCurve.length-1].time >= 1.0f)
        {
            
            //time = 0;
            //transform.position = position;
        }
        
    }
    float time,span=10;
    private void MoveSlowInAndOut()
    {
        Vector3 v = transform.position;
        v.x += ( (5*Time.deltaTime  + 2*animCurve.Evaluate(time))) ;
        transform.position = v;
        Debug.Log("delta:" + (2 * (Time.deltaTime + animCurve.Evaluate(time))) + " Count:" + count + 
            " curve:" + animCurve.Evaluate(time) );
        _camera.transform.position = v;
    }
}
