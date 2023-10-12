using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    static readonly string FLYING_ARG = "Flying";
    private float moveForce = 10;
    private Animator myAnim;
    private SpriteRenderer sr;
    private float movementX, movementY;
    private GameObject shape;
    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //myAnim.SetBool(FLYING_ARG, true);
        if(MyGameManager.Instance == null)
        {
            Debug.Log("null manager...");
        }
        else
        {
            //shape = MyGameManager.Instance.getGO();
            addObject();
        }
        
    }
    int numObjs = 0;
    float radius = 8f;
    Vector3 objPos;
    float angle = 0;
    void addObject()
    {
        if (objPos == null) objPos = gameObject.transform.position;
        if (numObjs == 20) return;
        shape = MyGameManager.Instance.getGO();
        shape.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        angle += Mathf.PI * 2 / 20;
        float x= Mathf.Cos(angle) * radius;
        float y= Mathf.Sin(angle) * radius;
        Vector3 pos = objPos + new Vector3(x, y, 0);
        //float angleDegrees = -angle * Mathf.Rad2Deg;
        //Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
        shape.transform.position = pos;
        Instantiate(shape);
        numObjs++;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int count = 0;
    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        AnimateCharacter();
        count++;
        if(count % 100==0 && numObjs < 200)
        {
            if (shape != null) addObject();
        }

    }
    float orientationX = -1;
    float orientationY = 0;
    void MoveCharacter()
    {
        this.movementX = Input.GetAxis("Horizontal");
        this.movementY = Input.GetAxis("Vertical");

        if (this.movementX != 0)
        {
            if (Mathf.Abs(movementX) > 0.8) { FlipBird(); return; }
            orientationX = (movementX > 0 ? 1 : -1);
            this.transform.position += new Vector3(this.movementX, 0f, 0f) * Time.deltaTime * moveForce;
            rotateBirdHor();
        }
        if (this.movementY != 0)
        {
            orientationY = (movementY > 0 ? 1 : -1);
            this.transform.position += new Vector3(0f, movementY, 0f) * Time.deltaTime * moveForce;
            rotateBirdVer();
        }
    }
    void FlipBird()
    {        
        transform.Rotate(new Vector3(0, 0, 1), 10);
    }

    void rotateBirdVer()
    {
        float a = transform.rotation.eulerAngles.z;
        transform.Rotate(new Vector3(0, 0, 1), -a); //rotate back..
        float flag = orientationX * orientationY;
        if (flag == 1)
        {
            transform.Rotate(new Vector3(0, 0, 1), 90); //rotate 90 degrees
        }
        else if(flag ==-1)
        {
            transform.Rotate(new Vector3(0, 0, 1), -90); //rotate -90 degrees
        }
    }
    void rotateBirdHor()
    {
        float a = transform.rotation.eulerAngles.z; //take the object back to its default orientation
        transform.Rotate(new Vector3(0, 0, 1), -a); //rotate back..
        if (orientationX > 0 && !sr.flipX) sr.flipX = true;
        if (orientationX < 0 && sr.flipX) sr.flipX = false;
    }

    void AnimateCharacter()
    {
        //change animation based on INPUT
        if (movementX > 0)
        {            
            sr.flipX = true;
        }
        else if (movementX < 0)
        {
            sr.flipX = false;
        }
    }

}
