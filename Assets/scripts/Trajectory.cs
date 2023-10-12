using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    private Rigidbody2D myBody;
    float h;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        h = myBody.position.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField]
    private Vector3 ForceVelocity = new Vector3(1400, 1400, 0);

    private int direction = 0;
    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonDown(0)) direction = 1;
        //else if (Input.GetMouseButtonDown(1)) direction = -1;
        //if(direction != 0) UpdateTrajectory(myBody, direction);
        //if(direction == 0) myBody.AddForce(-Physics.gravity * Time.deltaTime, ForceMode2D.Impulse);//2nd parameter decide to additive force.
        //ApplyTrajectoryForce();
        toy();
    }
    float ForceLeft = 40;
    float ForceUp = 200;
    int countt = 0;
//    float elapsedTime = 0;
    void toy()
    {
        myBody.AddForce(-Physics.gravity * Time.deltaTime, ForceMode2D.Impulse); //make the object hanging..
        //make it go left..
        Debug.Log("position:" + transform.position);
        Vector3 F = Vector3.left * ForceLeft * Time.deltaTime;
        Vector3 A = F / myBody.mass;
        Vector3 V0 = myBody.velocity;
        myBody.AddForce(F, ForceMode2D.Impulse); //make the object move Left.
        Debug.Log("Distance:" +
            (V0 * Time.deltaTime + 0.5f * A * Mathf.Pow(Time.deltaTime,2)));
        //elapsedTime += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        myBody.AddForce(Vector3.up * ForceUp * Time.deltaTime, ForceMode2D.Impulse); //make the object climb the obstacle
        Debug.Log("collision................");
    }
    private void FixedUpdate()
    {
        
    }
    
    void UpdateTrajectory(Rigidbody2D body,float direction)
    {
        Vector3 velocity = (ForceVelocity / body.mass) * Time.deltaTime; //calculate the veclocity based on the mass.
        // a = v / t, F = a . m -->  F = vm/t --> v = F . t / m
        float h = body.position.y; //height of object y value.
        float x = direction * 20 * Time.deltaTime + body.position.x;
        //y = h + v_y * t - g * t^2 / 2
        float y = h + velocity.y * Time.deltaTime - 0.5f * Physics.gravity.y * Time.deltaTime * Time.deltaTime;
        float z = velocity.z * Time.deltaTime;
        Vector3 pos = transform.position;
                Vector3 newPosition = new Vector3(x,y,z);
        //update the new position...
        body.position = newPosition;
    }
    int timesteps = 20,count=0;
    float ForceUP = 10;
    float moveRight = 20;
    void ApplyTrajectoryForce()
    {
        transform.Translate(new Vector3(3, 0, 0) * Time.deltaTime * moveRight);
        Vector3 f = Vector3.up;
        myBody.AddForce(f * ForceUP * Time.deltaTime, ForceMode2D.Impulse);
        if (count < timesteps / 2) ForceUP += 2;
        else ForceUP -= 2;
        count++;
        
    }
}
