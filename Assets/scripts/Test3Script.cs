using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3Script : MonoBehaviour
{

    public GameObject square;
    public GameObject circle;
    Coroutine animateCo;
    IEnumerator coroutine;

    private void Awake()
    {
        coroutine = Animate();
    }
    // Start is called before the first frame update
    void Start()
    {
        animateCo = StartCoroutine(coroutine);

        Invoke("FadeSquare", 0.1f);
        InvokeRepeating("FadeSquare", 0.1f, 0.5f);
        InvokeRepeating("FadeCircle", 0.1f, 0.5f);

    }

    void FadeSquare()
    {

        SpriteRenderer renderer = square.GetComponent<SpriteRenderer>();
        Color c = renderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
        }
    }


    float alpha = 1f;
    void FadeCircle()
    {
        if (alpha <= 0) alpha = 1;
        SpriteRenderer renderer = circle.GetComponent<SpriteRenderer>();
        Color c = renderer.material.color;
        c.a = alpha;
        renderer.material.color = c;
        alpha -= 0.1f;
    }



    float time = 0;
    bool stopFlag = false;
    static float MINUTE = 60;
    // Update is called once per frame
    void Updatex()
    {
        time += Time.deltaTime;
        if (time >= 10)
        {
            stopFlag = true;
            transform.localScale = new Vector3(1, 1, 0);
            //StopCoroutine("Animate");
            StopCoroutine(animateCo);
        }
    }
    void Update()
    {
        //Invoke("FadeSquare",0.1f);
        time += Time.deltaTime;
        if (time >= 20) CancelInvoke("FadeCircle");
        //if (timeCounter % 10 == 0) FadeCicle2();

    }
    IEnumerator Animate()
    {
        //while (!stopFlag)
        while (true)
        {
            transform.localScale = new Vector3(1, 1, 0);
            float x = Random.Range(1, 10);
            float y = Random.Range(1, 5);
            transform.position = new Vector3(x, y, 0);
            for (float scale = 1f; scale >= 0; scale -= 0.1f)
            {
                transform.localScale *= scale;
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}


