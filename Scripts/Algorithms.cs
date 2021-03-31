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
    int xPos = GameController.instance.currentPiece.GetComponent<PieceStats>().currentXPos;
    int yPos = GameController.instance.currentPiece.GetComponent<PieceStats>().currentYPos;
    public bool MovementPossible(int newXPos,int newYPos) //Passing the x,y positions of the PlaceHoolder to check if it's an available position.
    {
        int xDiff = Math.Abs(xPos - newXPos);
        int yDiff = Math.Abs(yPos - newYPos);

        if (AlgorithCalc(xDiff, yDiff))
            return true;
        else
            return false;
    }

    public bool AlgorithCalc(int xDiff, int yDiff)
    {
        PieceStats.PieceType piece = GameController.instance.currentPiece.GetComponent<PieceStats>().pieceType;
        //TODO remove this part and lay out the algorithms for each dataType through switch.
        if (xDiff == yDiff)
            isDiagonal = true;
        else if (xDiff == 0 || yDiff == 0)
            isStraight = true;
        else if (xDiff <= 1 && yDiff <= 1)
            isSingleCellMove = true;
        else if ((xDiff == 2 && yDiff == 1) || (yDiff == 2 && xDiff == 1))
            isKnightMove = true;
        else
            return false;

        switch(piece)
        {
            case PieceStats.PieceType.King:
                if (isSingleCellMove == true)
                    return true;
                else
                    return false;
            default:
                return false;
                
        }
    }
}
