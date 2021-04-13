using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject activePlaceHolder;  //The placeHolder from which we drag the piece is the current placeholder anytime.
    public PlaceHolderStats[,] placeHolderPositionArray = new PlaceHolderStats[8,8];
    

    public bool isWhitesTurn;
    public Image turnIndicator;

    private void Awake()
    {
        if(instance==null)
            instance = this;

        isWhitesTurn = true;

        #region to take care of Array

        for (int i=0;i<8;i++)
        {
            for(int j=0;j<8;j++)
            {
               placeHolderPositionArray[i, j] = gameObject.AddComponent<PlaceHolderStats>();
            }
        }

        for (int i = 0; i < 8; i++)
        {
            placeHolderPositionArray[i, 0].isOccupied =true;
            placeHolderPositionArray[i, 1].isOccupied =true;  
            placeHolderPositionArray[i, 6].isOccupied =true;
            placeHolderPositionArray[i, 7].isOccupied =true;
        }

        #endregion
    }


    public bool CheckTurn(GameObject draggedPiece)
    {
        if (draggedPiece.GetComponent<PieceStats>().isWhite && GameController.instance.isWhitesTurn)
            return true;
        else if (!draggedPiece.GetComponent<PieceStats>().isWhite && !GameController.instance.isWhitesTurn)
            return true;
        else
            return false;
    }
}
