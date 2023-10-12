using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //private Vector3[] trajectory;
    private Rigidbody2D rb;
    private int direction;
    private Vector3 position;
    private void Awake()
    {
        //bTransform = GetComponent<Rigidbody2D>().transform;
        rb = GetComponent<Rigidbody2D>();
    }
    public void setTrajectory(Vector3 pos,int direction)
    {
        this.direction = direction;
        this.position = pos;
    }
    public void SetPosition(Vector3 pos)
    {
        this.position = pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float time;
    int index = 0;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        MoveBullet();
        //MoveBulletTraj(45,10);
    }
    void MoveBullet()
    {
        if(direction == 0)//shoot up
        {
            this.position.y += Time.deltaTime * 10f;
        }else if(direction ==1)//shoot right
        {
            this.position.x += Time.deltaTime * 10f;
        }else if(direction == 2)// shoot down.
        {
            this.position.y -= Time.deltaTime * 10f;
        }else if(direction == 3)//show left...
        {
            this.position.x -= Time.deltaTime * 10f;
        }
        rb.transform.position = this.position;
    }
    
    void MoveBulletTraj(float angle,float v)
    {
        //if (this.trajectory == null) return;
        float G = 10;
        float x = time * 10f;
        float y = x * Mathf.Tan(angle) - (G * x * x) / (2 * v * v * Mathf.Cos(angle));
        transform.position = this.position + new Vector3(x, y, 0) ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameMgr.Instance.PlayExplosion();
        collision.gameObject.SetActive(false);
    }

}
