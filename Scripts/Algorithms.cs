using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithms : MonoBehaviour
{
    GameController gameController = GameController.instance.GetComponent<GameController>();

    public bool MovementPossible(int newXPos, int newYPos, int XPos, int Ypos)
    {
        int XDiff = XPos - newXPos;
        int YDiff = Ypos - newYPos;

        if (AlgorithCalc(gameController.currentPiece.GetComponent<PieceStats>().pieceType))
            return true;
        else
            return false;

    }
    public bool AlgorithCalc(PieceStats.PieceType pieceType)
    {
        return true;//TODO remove this part and lay out the algorithms for each dataType through switch.
        switch(gameController.currentPiece.GetComponent<PieceStats>().pieceType)
        {
            //TODO Different Algos for each PieceType;
        }
    }
}
