using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLineRenderer2 : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Camera _camera;
    private void Awake()
    {
        this._lineRenderer = GetComponent<LineRenderer>();
        _camera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))//in case you clicked on the left mouse after previous release
        {
            Debug.Log("mouse left clicked at:" + mousePos);
            this._lineRenderer.positionCount=1;
            this._lineRenderer.SetPosition(0, mousePos);
        }
        if (Input.GetMouseButton(0)) //in case you are holding the left mouse button
        {
            this._lineRenderer.positionCount++;
            this._lineRenderer.SetPosition(_lineRenderer.positionCount-1, mousePos);
        }

    }
}
