using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Calls Event when an object is places in the gameObject.
public class DropSlot : MonoBehaviour, IDropHandler
{   
    public Algorithms algo;
    public GameObject thisPlaceHolder;
    PlaceHolderStats placeHolderStats;

    void Start()
    {
        placeHolderStats = GetComponent<PlaceHolderStats>();
        thisPlaceHolder = gameObject;
    }
    public void OnDrop(PointerEventData eventData)
    {
        bool dropped = false;
        bool isSameColors; //To see if the dragged piece and occupying piece are of the same color.d

      


        if (eventData != null)
        {
            if (IsOccupiable(eventData.pointerDrag)) // TO check if the cell is empty or occupied by another colored piece.
            {
                if (algo.MovementPossible(placeHolderStats.xPos, placeHolderStats.yPos,eventData.pointerDrag))
                {
                    PlacePiece(eventData.pointerDrag);
                    UnOccupyPrevPlaceHolder();
                    dropped = true;
                }

            }
        }
        if (!dropped)
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<PieceStats>().PlaceHolderOfThisPiece.GetComponent<RectTransform>().anchoredPosition;

    }
    void PlacePiece(GameObject draggedPiece)
    {
        if (placeHolderStats.isOccupied)
        {
            Destroy(placeHolderStats.occupiedPiece);
        }

        draggedPiece.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; //Set Anchor position to that of the new cell
        draggedPiece.GetComponent<PieceStats>().SetNewPos(placeHolderStats.xPos, placeHolderStats.yPos);              //passes PH's x and y pos to be set as the current object's x and y 
     
        placeHolderStats.occupiedPiece = draggedPiece;                                                                //Set dragged piece as piece of this cell.
        draggedPiece.GetComponent<PieceStats>().PlaceHolderOfThisPiece = thisPlaceHolder;                             //Set this PH as the PH of the dragged piece.

        placeHolderStats.isOccupied = true;
    }
    void UnOccupyPrevPlaceHolder()
    {
        GameController.instance.currentPlaceHolder.GetComponent<PlaceHolderStats>().isOccupied = false;
        GameController.instance.currentPlaceHolder.GetComponent<PlaceHolderStats>().occupiedPiece = null;
    }

    private bool IsOccupiable(GameObject draggedPiece)
    {
        if (!placeHolderStats.isOccupied)
            return true;
        if ((draggedPiece.GetComponent<PieceStats>().isWhite && placeHolderStats.occupiedPiece.GetComponent<PieceStats>().isWhite)||(!draggedPiece.GetComponent<PieceStats>().isWhite && !placeHolderStats.occupiedPiece.GetComponent<PieceStats>().isWhite))
                return true;
        else
            return false;
    }

}
