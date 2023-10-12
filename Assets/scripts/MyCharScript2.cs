using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharScript2 : MonoBehaviour
{
    private float moveForce = 10;
    private Animator myAnim;
    private static readonly string WALK_ANIM = "Walk";
    private static readonly string RUN_ANIM = "Run";
    private static readonly string FLIP_ANIM = "Flip";

    private SpriteRenderer sr;
    private Rigidbody2D myBody;
    private float movementX,movementY;
    private bool isSpace;
    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale += new Vector3(0.5f, 0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();       
        
        AnimateCharacter();
    }
    private void FixedUpdate()
    {
        flip();        
    }

    
    void MoveCharacter()
    {
        this.movementX = Input.GetAxis("Horizontal"); //save where you are..
        this.movementY = Input.GetAxis("Vertical");

        Vector3 v = new Vector3(this.movementX, movementY, 0f) * Time.deltaTime * moveForce;
        Vector3 pos = transform.position;
        float tPos = pos.x + v.x;
        Debug.Log("char2 pos:" + tPos);
        float Left = GameObject.FindWithTag("LeftBoundary").transform.position.x;
        
        float Right = GameObject.FindWithTag("RightBoundary").transform.position.x;

        if (tPos <= Right && tPos >= Left) transform.Translate(v.x, v.y, v.z);
    }
    void AnimateCharacter()
    {
        if (movementX > 0)
        {
            if (movementX < 0.5) myAnim.SetBool(WALK_ANIM, true);
            else myAnim.SetBool(RUN_ANIM, true);
            sr.flipX = false;
            //myAnim.SetBool(FLIP_ANIM, false);
        }
        else if (movementX < 0)
        {
            if (movementX > -0.5) myAnim.SetBool(WALK_ANIM, true);
            else myAnim.SetBool(RUN_ANIM, true);
            sr.flipX = true;
            //myAnim.SetBool(FLIP_ANIM, false);
        }
        else
        {
            myAnim.SetBool(WALK_ANIM, false);
            myAnim.SetBool(RUN_ANIM, false);
        }
    }
    void flip()
    {
        Debug.Log("flippppping...");
        bool isIdle = !myAnim.GetBool(WALK_ANIM) && !myAnim.GetBool(RUN_ANIM);
        //Debug.Log("is Idle state:" + isIdle + "," + myAnim.GetBool(WALK_ANIM) + "," + myAnim.GetBool(RUN_ANIM));
        if (isIdle && Input.GetButton("Jump"))
        {
            myAnim.SetBool(FLIP_ANIM, true);

        }
        else
        {
            myAnim.SetBool(FLIP_ANIM, false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collisin...............");
        if (collision.gameObject.CompareTag("LeftBoundary"))
        {
        }
    }
}//class





