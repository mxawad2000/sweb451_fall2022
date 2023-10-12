using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Script : MonoBehaviour
{
    private Animator diamondAnim;
    private SpriteRenderer sr;
    void Awake()
    {
        diamondAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    int param = 0;
    void AnimateDiamond()
    {
        
        int r; //= Random.Range(1, 3);
        if (input > 0) r = 1;
        else r = 2;
        Debug.Log("r:" + r + " param:" + param);

        if (param != r )
        {
            param = r;
            diamondAnim.SetInteger("param", 0);
            diamondAnim.SetInteger("param", r);
        }
    }
    float input;
    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal"); //save where you are..
        if (input != 0) AnimateDiamond();
        
    }
}
