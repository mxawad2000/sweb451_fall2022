using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    [SerializeField]
    AnimationCurve animCurve;

    [SerializeField]
    TrajectoryLine trajectoryLine;

    float movementLevel = 10;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // MoveCircle();
        shoot();
        
    }
    private void shoot()
    {
        Vector3 vel = new Vector3(10, 10, 0);
        trajectoryLine.showTrajectoryLine(transform.position,vel);
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        
    }
    private void MoveCircle()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 pos = transform.position;
        pos.x += (movementLevel * animCurve.Evaluate(h)) * Time.deltaTime;
        pos.y += (movementLevel * animCurve.Evaluate(v)) * Time.deltaTime;
        transform.position = pos;
    }
}
