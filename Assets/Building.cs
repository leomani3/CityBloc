using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    public float height;
    public List<Vector2> points;

    public Building(float f, List<Vector2> p)
    {
        height = f;
        points = new List<Vector2>(p);
    }
}
