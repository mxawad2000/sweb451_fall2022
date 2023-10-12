using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CometManager : MonoBehaviour
{
    static readonly int DOWN = 0;
    static readonly int HORIZONTAL = 1;
    static readonly int DIAG = 2;
    static readonly int LEFT = 0;
    static readonly int RIGHT = 1;

    float minX, minY, maxX, maxY;
    GameObject UpperLeft, LowerRight;
    public GameObject[] TemplateComet = new GameObject[2] ;
    List<MyComet> CometList = new List<MyComet>();
    //Button startButton;
    private void Awake()
    {
        this.UpperLeft = GameObject.FindGameObjectWithTag("UpperLeft");
        this.LowerRight = GameObject.FindGameObjectWithTag("LowerRight");
        this.minX = UpperLeft.transform.position.x;
        this.maxX = LowerRight.transform.position.x;
        this.maxY = UpperLeft.transform.position.y;
        this.minY = LowerRight.transform.position.y;
        //startButton = GameObject.FindGameObjectWithTag("startButton").GetComponent<Button>();

    }
    
    float[] getRandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float[] loc = { x, y };
        return loc;
    }
    float[] getRandomPosition(int orientation, int direction)
    {
        float x=0, y=0;
        if(orientation == DOWN) //falling
        {
            y = maxY;
            x = Random.Range(minX+0.1f, maxX-0.1f);
        }
        else if(orientation == HORIZONTAL || orientation == DIAG) //horizontal
        {
            x = minX;
            if(direction == LEFT)
            {
                x = maxX;            
            }
            y = Random.Range(minY, maxY);
        }
        float[] loc = { x, y };
        return loc;
    }
    public IEnumerator generateFallingComet2()
    {
        while (true) // how many times do you want to run this.
        {
            
            int orientation = Random.Range(0, 3);//0: falling, 1: horizontal, 2:diag
            int direction = Random.Range(0, 2); //0: Left, 1: Right
            float[] loc = getRandomPosition(orientation, direction);
            int index = Random.Range(0, TemplateComet.Length);
            GameObject go = Instantiate(TemplateComet[index]);
            go.SetActive(false);
            go.transform.position = new Vector3(loc[0], loc[1]);
            MyComet comet = new MyComet(go, orientation, direction);
            if (orientation == HORIZONTAL)
            {
                go.GetComponent<Rigidbody2D>().gravityScale = 0;
                if (direction == RIGHT)
                {
                    go.GetComponent<SpriteRenderer>().flipX = true;
                    go.transform.Rotate(new Vector3(0, 0, -25));
                }
                else
                {
                    go.transform.Rotate(new Vector3(0, 0, -75));
                }
            }
            else if (orientation == DIAG)
            {
                go.transform.Rotate(new Vector3(0, 0, -55));
                go.GetComponent<Rigidbody2D>().gravityScale = 0;
                if (direction == RIGHT) go.GetComponent<SpriteRenderer>().flipX = true;
            }
            CometList.Add(new MyComet(go, orientation, direction));
            go.SetActive(true);
            yield return new WaitForSecondsRealtime(1);
        }
    }
    private void generateFallingComet()
    {
        
        int orientation = Random.Range(0, 3);//0: falling, 1: horizontal, 2:diag
        int direction = Random.Range(0, 2); //0: Left, 1: Right
        float[] loc = getRandomPosition(orientation,direction);
        int index = Random.Range(0, TemplateComet.Length);
        GameObject go = Instantiate(TemplateComet[index]);
        go.SetActive(false);
        go.transform.position = new Vector3(loc[0], loc[1]);
        MyComet comet = new MyComet(go, orientation, direction);
        if(orientation == HORIZONTAL)
        {
            go.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (direction == RIGHT)
            {
                go.GetComponent<SpriteRenderer>().flipX = true;
                go.transform.Rotate(new Vector3(0, 0, -25));
            }
            else
            {
                go.transform.Rotate(new Vector3(0, 0, -75));
            }
        }
        else if(orientation == DIAG)
        {
            go.transform.Rotate(new Vector3(0, 0, -55));
            go.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (direction == RIGHT) go.GetComponent<SpriteRenderer>().flipX = true;
        }
        CometList.Add(new MyComet(go, orientation,direction));
        go.SetActive(true);
    }
    IEnumerator myCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("generateFallingComet", 2, 1);
        myCoroutine = generateFallingComet2();
        StartCoroutine(myCoroutine);
        //startButton.gameObject.SetActive(false);
        //GameMgr.cleanList += CancelInvoke;
        GameMgr.cleanList += StopAllCoroutines;
    }

    void cleanComets()
    {
        //StopAllCoroutines();
        //Debug.Log("num of comets:" + CometList.Count);
        //foreach (MyComet c in CometList) Destroy(c.go);
        //CometList.Clear();
    }
    // Update is called once per frame
    void Update()
    {
       for(int i=0;i<CometList.Count;i++)
        {
            MyComet comet = CometList[i];
            if (cleanObstacle(comet))
            {
                CometList.Remove(comet);
                i--;
            }
            else
            {
                moveComet(comet);
            }

        } 
    }
    float MoveForce = 5;
    void moveComet(MyComet comet)
    {
        float amount = comet.moveForce * Time.deltaTime;
        float x = comet.go.transform.position.x;
        float y = comet.go.transform.position.y;
        if (comet.orientation == HORIZONTAL && comet.direction == LEFT) x-= amount;//dcrease X
        if (comet.orientation == HORIZONTAL && comet.direction == RIGHT) x+= amount;//increase X
        if (comet.orientation == DIAG && comet.direction == LEFT)
        {
            x -= amount; y -= amount;//dcrease X and y
        }
        if (comet.orientation == DIAG && comet.direction == RIGHT)
        {
            x += amount; y -= amount;//increase X and decrease y
        }
        comet.go.transform.position = new Vector3(x, y, 0);
    }
    bool cleanObstacle(MyComet comet)
    {
        float x = comet.go.transform.position.x;
        float y = comet.go.transform.position.y;
        if(x > maxX || x < minX || y >maxY || y < minY)
        {
            Destroy(comet.go);
            return true;
        }
        return false;
    }
}
/////////////////////////////
class MyComet 
{
    internal GameObject go;
    internal int direction;
    internal int orientation;
    internal float moveForce;
    public MyComet(GameObject go, int orientation, int direction)
    {
        this.go = go;
        this.direction = direction;
        this.orientation = orientation;
        moveForce = Random.Range(4, 8);
    }
}

