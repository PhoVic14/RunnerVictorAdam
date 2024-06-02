using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{

    public static float leftSide = -4f;
    public static float rightSide = 4f;
    public float internalRight;
    public float internalLeft;


    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;

    }
}
