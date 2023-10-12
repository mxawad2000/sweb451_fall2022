using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(EdgeCollider2D))]
public class ShipScript : MonoBehaviour
{
    Rigidbody2D ShipBody;
    SpriteRenderer sr;
    LineRenderer lr;
    EdgeCollider2D edgeCollider;
    [SerializeField] private GameObject bulletPrefab;
    //Button startButton;
    private void Awake()
    {
        ShipBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //startButton = GameObject.FindGameObjectWithTag("startButton").GetComponent<Button>();
        lr = GetComponent<LineRenderer>();
        edgeCollider = GetComponent< EdgeCollider2D >();
    }
    void setEdgeCollider()
    {
        List<Vector2> edges = new List<Vector2>();
        for(int i = 0; i < lr.positionCount; i++)
        {
            Vector3 v = lr.GetPosition(i);
            edges.Add(new Vector2(v.x, v.y));
        }
        this.edgeCollider.SetPoints(edges);
        Debug.Log("Setting:" + edgeCollider.edgeCount + " edges...");
    }
    // Start is called before the first frame update
    void Start()
    {
        GameMgr.cleanList += endGame;
    }
    public void endGame()
    {
        //GetComponent<AudioSource>().Stop();
        //startButton.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        MoveShip();
        if (Input.GetKey(KeyCode.Space))
        {
            //bulletTrajectory();
            createTraj();
        }
        else
        {
            this.lr.positionCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }
    void shoot()
    {
        int bDirection = 0;
        Vector3 direction = transform.rotation.eulerAngles;
        Debug.Log("direction:" + direction);
        if(direction.z == 0)//shoot up
        {
            bDirection = 0;
        }else if (direction.z == 180)//shoot down
        {
            bDirection = 2;
        }
        else if (direction.z == 90)//shoot left
        {
            bDirection = 3;
        }
        else if (direction.z == 270)//shoot right
        {
            bDirection = 1;
        }
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<BulletScript>().setTrajectory(transform.position, bDirection);
    }

    private Vector3[] GetPoints(int orientation, int N)
    {
        Vector3[] points = new Vector3[N];
        points[0] = transform.position;
        int x = 0, y = 0;
        for (int i = 1; i < N; i++)
        {
            if (orientation == 0)//up
                y++;
            else if (orientation == 1)// left
                x--;
            else if (orientation == 2)//down
                y--;
            else if (orientation == 3)//right
                x++;
            points[i] = new Vector3(points[0].x+x, points[0].y+ y, 0);
        }
        return points;
    }
    void createTraj()
    {
        int N = 10;
        Vector3[] points = new Vector3[N];
        points[0] = transform.position;
        int x = 0, y = 0;
        Vector3 direction = transform.rotation.eulerAngles;
        Debug.Log("direction:" + direction);
        for (int i = 1; i < N; i++)
        {
            if (direction.z == 0) y++;//up
            else if (direction.z == 90) x--;//left
            else if (direction.z == 180) y--;//down
            else if (direction.z == 270) x++; //right
            points[i] = new Vector3(points[0].x + x, points[0].y + y, 0);
        }
        lr.positionCount = N;
        lr.SetPositions(points);
    }


  
    float Speed = 5;
    private void MoveShip()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        setOrientation(h, v);
        Vector2 pos = transform.position;
        pos.x += Speed * h * Time.deltaTime;
        pos.y += Speed * v * Time.deltaTime;
       transform.position = pos;
    }
    void setOrientation(float x, float y)
    {
        if(x !=0)
        {
            float a = transform.rotation.eulerAngles.z;
            transform.Rotate(new Vector3(0, 0, 1), -a+90);            
            if(x > 0 ) transform.Rotate(new Vector3(0, 0, 1), -180);
        }
        if (y != 0)
        {
            float a = transform.rotation.eulerAngles.z;
            transform.Rotate(new Vector3(0, 0, 1), -a);
            if (y < 0) transform.Rotate(new Vector3(0, 0, 1), -180);
        }
    }
    void setOrientationDefault()
    {
        float a = transform.rotation.eulerAngles.z;
        transform.Rotate(new Vector3(0, 0, 1), -a); //rotate back..
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameMgr.Instance.PlayExplosion();
        GameMgr.Instance.SetEnergy(-20);
        GameMgr.Instance.SetScore(-1);
        collision.gameObject.SetActive(false);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameMgr.Instance.PlayExplosion();
        GameMgr.Instance.SetEnergy(-20);
        GameMgr.Instance.SetScore(-1);
        collision.gameObject.SetActive(false);
    }
    

}
