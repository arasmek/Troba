using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Vector2 RotateVector(Vector2 initialVector, float theta)
    {
        return new Vector2(initialVector.x * Mathf.Cos(theta) -
                                        initialVector.y * Mathf.Sin(theta),
                                        initialVector.x * Mathf.Sin(theta) +
                                        initialVector.y * Mathf.Cos(theta));
    }
}
