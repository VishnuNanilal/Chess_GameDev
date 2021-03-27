﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject currentPiece = null;
    public Transform[] placeHolderPos = new Transform[64];

    public bool isOccupied; //Slot occupied or not. (Refactorable)

    private void Awake()
    {
        instance = this;
    }

}