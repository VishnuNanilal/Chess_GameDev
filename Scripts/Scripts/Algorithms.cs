using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithms : MonoBehaviour
{
    bool isDiagonal;
    bool isStraight;
    bool isSingleCellMove;
    bool isKnightMove;
    bool isPawn;

    public void Start()
    {
        //isDiagonal = false;
        //isStraight = false;
        isSingleCellMove = false;
        //isKnightMove = false;
        //isPawn = false;
    }
    public bool MovementPossible(int PHXPos,int PHYPos,GameObject currentPiece) //Passing the x,y positions of the PlaceHoolder to check if it's an available position.
    {
        int xPos = currentPiece.GetComponent<PieceStats>().currentXPos;
        int yPos = currentPiece.GetComponent<PieceStats>().currentYPos;
        int xDiff = Math.Abs(xPos - PHXPos);
        int yDiff = Math.Abs(yPos - PHYPos);

        Debug.Log(xDiff+" "+yDiff );

        if (AlgorithCalc(xDiff, yDiff,currentPiece))
            return true;
        else
            return false;
    }

    public bool AlgorithCalc(int xDiff, int yDiff,GameObject currentPiece)
    {
        PieceStats.PieceType piece = currentPiece.GetComponent<PieceStats>().pieceType;
        //TODO remove this part and lay out the algorithms for each dataType through switch.
        if (xDiff == yDiff)
            isDiagonal = true;
        if (xDiff == 0 || yDiff == 0)
            isStraight = true;
        if (xDiff <= 1 && yDiff <= 1)
            isSingleCellMove = true;
        if ((xDiff == 2 && yDiff == 1) || (yDiff == 2 && xDiff == 1))
            isKnightMove = true;

        switch(piece)
        {
            case PieceStats.PieceType.King:
                if (isSingleCellMove == true)
                {
                    ResetMoveType();
                    return true;
                }
                else
                    return false;
            default:
                return false;
                
        }
    }

    void ResetMoveType()
    {
        //isDiagonal = false;
        //isStraight = false;
        isSingleCellMove = false;
        //isKnightMove = false;
        //isPawn = false;
    }
}
