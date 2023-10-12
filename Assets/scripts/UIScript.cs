using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    int score = 0;
    TextMesh scoreValue;
    private void Awake()
    {
        scoreValue = GetComponent<TextMesh>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = score + "";
        if (Input.GetKeyDown(KeyCode.Space)) score++;
    }
}
