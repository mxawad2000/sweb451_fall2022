using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrapper : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D myBody;
    private float movementX, movementY,moveForce=20;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myBody.AddForce(-Physics.gravity * myBody.mass * Time.deltaTime, ForceMode2D.Impulse);
        MovePlayer();
    }
    void MovePlayer()
    {
        this.movementX = Input.GetAxis("Horizontal"); //save where you are..
        this.movementY = Input.GetAxis("Vertical");

        //this.transform.position += new Vector3(this.movementX, 0f, 0f) * Time.deltaTime * moveForce;
        Vector3 v = new Vector3(this.movementX, movementY, 0f) * Time.deltaTime * moveForce;
        transform.Translate(v.x, v.y, v.z);
    }
}
