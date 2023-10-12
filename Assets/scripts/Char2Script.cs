using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char2Script : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator myAnim;
    public float timeRemaining = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start() { }
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        myAnim.SetFloat("Horizontal", movement.x);
        myAnim.SetFloat("Vertical", movement.y);
        myAnim.SetFloat("speed", movement.sqrMagnitude);
        if (timeRemaining >0)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log("time rema:" + timeRemaining);
            if (timeRemaining <= 0) Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement*moveSpeed*Time.fixedDeltaTime);
    }
}
