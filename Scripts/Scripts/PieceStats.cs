using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceStats : MonoBehaviour
{   
    public enum PieceType
    {
        None,
        King,
        Queen,
        Knight,
        Bishop,
        Rook,
        Pawn
    }

    public PieceType pieceType;
    public int initXpos;
    public int initYpos;

    public int currentXPos;
    public int currentYPos;

    public GameObject PlaceHolderOfThisPiece;

    private void Start()
    {
        currentXPos = initXpos;
        currentYPos = initYpos;
        
    }

    public void SetNewPos(int PlaceHolderXPos, int PlaceHolderyYPos)
    {
        currentXPos = PlaceHolderXPos;
        currentYPos = PlaceHolderyYPos;
    }
}
