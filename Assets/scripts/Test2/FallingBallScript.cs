using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FallingBallScript : MonoBehaviour
{
    Rigidbody2D myBody;
    Button button;
    GameObject square;
    float Force = 20;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        //myBody.gravityScale = 0.01f;
        square = GameObject.FindGameObjectWithTag("test2_square");
        button = GameObject.FindGameObjectWithTag("test2_button").gameObject.GetComponent<Button>();
    }
    // Start is called before the first frame update
    void Start()
    {
        myBody.velocity = new Vector2(0,-1);
    }

    bool isOnGround = false;
    // Update is called once per frame
    void Update()
    {
        if (myBody.transform.position.y < 0 && !isOnGround)
        {
            isOnGround = true;
            gameObject.GetComponent<AudioSource>().Play();
            square.SetActive(false);
            button.gameObject.SetActive(false);
            myBody.gravityScale = 0;
            myBody.velocity = new Vector2(0, 0);
        }   
    }
}
