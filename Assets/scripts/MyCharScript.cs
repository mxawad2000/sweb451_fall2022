using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyCharScript : MonoBehaviour
{
    Dropdown playerOptions;
    
    private float moveForce = 10;
    private Animator myAnim;
    private static readonly string WALK_ANIM = "Walk";
    private static readonly string RUN_ANIM = "Run";
    private static readonly string FLIP_ANIM = "Flip";

    private SpriteRenderer sr;
    private Rigidbody2D myBody;
    private AudioSource audioSource;
    private float movementX,movementY;
    private bool isSpace;

    public float speed;
    public float angularSpeed;
    delegate void MyDelegate();
    MyDelegate md;
    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        this.audioSource = GetComponent<AudioSource>();
        md = A;
        md += B;
    }
    void A() { Debug.Log("A"); }
    void B() { Debug.Log("B"); }
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale += new Vector3(0.5f, 0.5f, 1);
        md();
        md -= Start;
        md = A;
        md();
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveCharacter();
        MoveCharacter();
        myAnim.SetInteger("entry", 1);
        AnimateCharacter();
        speed = myBody.velocity.magnitude;
    }
    int count = 0;
    private void FixedUpdate()
    {
        flip();
        //myBody.AddForce(Vector3.left * 200);
        //myBody.mass += 2;
        if(this.transform.position.y > 0)
        {
            myBody.AddForce(Physics.gravity);
            myBody.drag = 1;//opposite of gravity
        }
        else
        {
            myBody.AddForce(-1 * Physics.gravity);
            myBody.drag = 100;
        }
        //MyCharScript.ApplyForce2ReachVelocity(myBody, Vector3.right * 10, 100f);
    }
    static void ApplyForce2ReachVelocity(Rigidbody2D rig, Vector3 velocity, float Force, ForceMode2D mode = ForceMode2D.Force)
    {
        if (velocity.magnitude == 0 || Force == 0) return;
        velocity = velocity + velocity.normalized * 0.2f * rig.drag; // add portion of the drag to the velocity
        Force = Mathf.Clamp(Force, -rig.mass / Time.fixedDeltaTime, rig.mass / Time.fixedDeltaTime);
        if(rig.velocity.magnitude == 0)
        {
            rig.AddForce(Force * velocity, mode);
        }
        else
        {
            var vel2 = (velocity.normalized * Vector3.Dot(velocity,rig.velocity)/velocity.magnitude);
            rig.AddForce((velocity - vel2) * Force, mode);
        }
    }

    void MoveCharacter()
    {
            this.movementX = Input.GetAxis("Horizontal"); //save where you are..
            this.movementY = Input.GetAxis("Vertical");

            //this.transform.position += new Vector3(this.movementX, 0f, 0f) * Time.deltaTime * moveForce;
            Vector3 v = new Vector3(this.movementX, movementY, 0f) * Time.deltaTime * moveForce;
            transform.Translate(v.x,v.y,v.z);
    }
    void MoveCharacter2()
    {
        this.movementX = Input.GetAxis("Horizontal"); //save where you are..
        this.movementY = Input.GetAxis("Vertical");

        Vector3 v = new Vector3(this.movementX, movementY, 0f) * Time.deltaTime * moveForce;
        Vector3 pos = transform.position;
        float tPos = pos.x + v.x;
        Debug.Log("char2 pos:" + tPos);
        if (tPos <= 30 && tPos >= -30) transform.Translate(v.x, v.y, v.z);
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
        bool isIdle = !myAnim.GetBool(WALK_ANIM) && !myAnim.GetBool(RUN_ANIM);
        //Debug.Log("is Idle state:" + isIdle + "," + myAnim.GetBool(WALK_ANIM) + "," + myAnim.GetBool(RUN_ANIM));
        if (isIdle && Input.GetButton("Jump"))
        {
            Debug.Log("applying force...");
            myAnim.SetBool(FLIP_ANIM, true);
            //this.myBody.AddForce(-transform.right*20);   
            //myAnim.SetBool(WALK_ANIM, true);
        }
        else
        {
            myAnim.SetBool(FLIP_ANIM, false);
            //this.myBody.AddForce(new Vector2(0, 2));
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collisin...............");
        if (collision.gameObject.CompareTag("LeftBoundary"))
        {
            AudioSource cas = collision.gameObject.GetComponent<AudioSource>();
            cas.Play();
        }
        //this.audioSource.Stop();
        if ( collision.gameObject.CompareTag("RightBoundary")){
            AudioSource cas = collision.gameObject.GetComponent<AudioSource>();
            cas.Play();

        }
        //this.audioSource.Play();
    }
}//class





