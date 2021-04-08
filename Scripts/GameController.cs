using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    //public RayCastHandler rayCastHandler;

    public GameObject activePiece = null; //The object we is the dragged piece
    public GameObject activePlaceHolder;  //The placeHolder from which we drag the piece is the current placeholder anytime.
    public Transform[] placeHolderPositions = new Transform[64];

    public bool isWhitesTurn;
    public bool isCorrectTurn;

    public Image turnIndicator;
    private void Awake()
    {
        instance = this;
        isWhitesTurn = true;
    }
    
    public bool CheckTurn()
    {
        if (activePiece.GetComponent<PieceStats>().isWhite && GameController.instance.isWhitesTurn)
            return true;
        else if (!activePiece.GetComponent<PieceStats>().isWhite && !GameController.instance.isWhitesTurn)
            return true;
        else
            return false;
    }
}
