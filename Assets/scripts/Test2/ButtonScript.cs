using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour
{
    Button button;
    bool isStart = true;
    GameObject mySquare;
    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(handleButton);
        mySquare = GameObject.FindGameObjectWithTag("test2_square");
    }
    private void handleButton()
    {
        if (isStart)
        {
            button.GetComponentInChildren<Text>().text = "STOP";
            startAnimation();
        }
        else
        {
            button.GetComponentInChildren<Text>().text = "START";
            stopAnimation();

        }
        isStart = !isStart;
    }
    // Start is called before the first frame update
    void Start()
    {
        //startAnimation();
        
    }
    void startAnimation()
    {
        Animator anim = mySquare.GetComponent<Animator>();
        anim.SetInteger("param", 1);
    }
    void stopAnimation()
    {
        Animator anim = mySquare.GetComponent<Animator>();
        anim.SetInteger("param", 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
