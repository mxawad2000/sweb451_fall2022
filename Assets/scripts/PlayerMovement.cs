using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    AudioSource myAudioSource;
    public float speed = 5;
   
    // Start is called before the first frame update
    void Start()
    {
        this.myAudioSource = GetComponent<AudioSource>();
        this.myRigidBody = GetComponent<Rigidbody2D>();
        Debug.Log("starting...");
        StartCoroutine(someFun());
        
    }
    IEnumerator someFun()
    {
        yield return new WaitForSeconds(2f);
        
        Debug.Log("do something...");
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 pos = transform.position;
        pos.x += speed * h * Time.deltaTime;
        pos.y += speed * v * Time.deltaTime;
        transform.position = pos;
    }
}
