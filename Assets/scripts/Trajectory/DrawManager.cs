using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{ 
    private Camera _camera; //to specify the position of the mouse.
    [SerializeField] private Line _linePrefab;
    //public Rigidbody2D my2DRigid;
    //public AudioSource myAudioSource;
    
    private Line _currentLine;
    public const float RESOLUTION = 0.1f; //smoothing, the smaller the smoother.

    void Start()
    {
        _camera = Camera.main;

    }

    int frame = 0;
    // Update is called once per frame
    void Update()
    {
        frame++;
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        //detect left mouse button is pressed for the first time (or after being released)
        if (Input.GetMouseButtonDown(0))
        {
            _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
        }
        //detect if the left mouse is held.
        if (Input.GetMouseButton(0))
        {
            //add to the line renderer
            _currentLine.setPosition(mousePos);
        }
        
    }
}
