using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //rb.drag = 1f;//increase friction little

    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        
    }
    private void FixedUpdate()
    {
       
    }
    
    private static float Force = 1000;
    private float direction = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color c = GetRandomColor();
        GetComponent<Renderer>().material.color = c;
        Debug.Log("on Conllsion....");
        if (collision.gameObject.CompareTag("RightBoundary"))
        {
            rb.AddForce(Vector3.left * Force/2);
            direction *= -1;
        }
        else if (collision.gameObject.CompareTag("LeftBoundary"))
        {
            rb.AddForce(Vector3.right * Force/2);
            direction *= -1;
        }

    }
    void MoveHorizontal()
    {
        Vector3 v = rb.transform.position;
        v.x += Time.deltaTime*10*direction;
        rb.transform.position = v;
    }
     private Color GetRandomColor()
    {
        return new Color(
            UnityEngine.Random.Range(0f,1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f)
            );
    }
}
