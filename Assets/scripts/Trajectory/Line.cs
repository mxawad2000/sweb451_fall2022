using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;

    /// <summary>
    /// specify the next position/point to be appended to the line
    /// </summary>
    /// <param name="pos"></param>
    public void setPosition(Vector2 pos)
    {
        if (!canAppend(pos)) return;
        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);

    }
    public bool canAppend(Vector2 pos)
    {
        //number of points is zero
        if (_renderer.positionCount == 0) return true;
        // |pos - last_point_pos| > Resolution
        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos)
            > DrawManager.RESOLUTION;
    }
}
