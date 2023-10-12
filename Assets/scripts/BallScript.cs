using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform MainCameraTransform;
    GameObject[] LWalls, RWalls;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject go = GameObject.FindGameObjectWithTag("MainCamera");
        if (go != null) MainCameraTransform = go.transform;
        LWalls= GameObject.FindGameObjectsWithTag("LeftBoundary");
        RWalls = GameObject.FindGameObjectsWithTag("RightBoundary");
        setWalls();
    }
    private void setWalls()
    {
        int index = Random.Range(0, LWalls.Length);
        LWalls[index].SetActive(true);
        RWalls[index].SetActive(true);
        for (int i = 0; i < LWalls.Length; i++)
        {
            if (i != index)
            {
                LWalls[i].SetActive(false);
                RWalls[i].SetActive(false);
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        rb.drag = 1f;//increase friction little

    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        
    }
    private void LateUpdate()
    {
       
    }
    private void FixedUpdate()
    {
       
    }
    void Bounce()
    {

    }
    
    private static float Force = 1000;
    private Vector3 v = Vector3.up * Force;
    private float direction = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color c = GetRandomColor();
        GetComponent<Renderer>().material.color = c;
        Debug.Log("on Conllsion....");
        if (collision.gameObject.CompareTag("Floor"))
        {
            //v.x=5;
            rb.AddForce(v); //add force
            v.y -= (Force / 10) * rb.drag; //reduce the force by the amount of friction/drag
            //v.x = 10;
            //Vector3 pos = transform.position;
            Debug.Log("vel.x dir:" + rb.velocity.x);
        }else if (collision.gameObject.CompareTag("RightBoundary"))
        {
            rb.AddForce(Vector3.left * Force);
            direction *= -1;
            setWalls();
        }
        else if (collision.gameObject.CompareTag("LeftBoundary"))
        {
            rb.AddForce(Vector3.right * Force);
            direction *= -1;
        }
       
    }
    void MoveHorizontal()
    {
        Vector3 v = rb.transform.position;
        v.x += Time.deltaTime * 10 * direction;
        rb.transform.position = v;
    }
    private Color GetRandomColor()
    {
        return new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f)
            );
    }
    private Vector3 tmpPosition;
    void moveCamera()
    {
        float maxRight = 72.5f;
        float maxLeft = -50;
        if (MainCameraTransform != null)
        {
            tmpPosition = transform.position;
            tmpPosition.x = MainCameraTransform.position.x;
            //move the camera to myCharPosition
            if (tmpPosition.x > maxRight) tmpPosition.x = maxRight;
            if (tmpPosition.x < maxLeft) tmpPosition.x = maxLeft;
            transform.position = tmpPosition;
        }
    }
}
