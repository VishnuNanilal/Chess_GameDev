using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceStats : MonoBehaviour
{   
    public int initXpos;
    public int initYpos;

    public int currentXPos;
    public int currentYPos;

    private void Start()
    {
        currentXPos = initXpos;
        currentYPos = initYpos;
    }

    public void SetPos(int PlaceHolderXPos, int PlaceHolderyYPos)
    {
        currentXPos = PlaceHolderXPos;
        currentYPos = PlaceHolderyYPos;
    }
}
