using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Calls Event when an object is places in the gameObject.
public class DropSlot : MonoBehaviour, IDropHandler
{   

    PlaceHolderStats placeHolderStats;
    PieceStats pieceStats;
    void Start()
    {
        placeHolderStats=GetComponent<PlaceHolderStats>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null)
        {
            if (!GetComponent<PlaceHolderStats>().isOccupied) //TODO Check if it's Occupied by a different color. If not return.
            {
                if (GameController.instance.algo.MovementPossible(placeHolderStats.xPos,placeHolderStats.yPos))
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    GameController.instance.currentPiece.GetComponent<PieceStats>().SetPos(placeHolderStats.xPos, placeHolderStats.yPos); //passes PH's x and y pos to be set as the current object's x and y pos.
                                                                                                                                          //TODO removes the piece if any is present.     
                    Debug.Log("Object Dropped");

                }
            }
        }

    }

    //TODO
    private bool isOccupiable()
    {
        return true; //TODO Checks if the slot is occupiable; 1) if the move is possible for the dragged piece 2) If possible, check if the slot is NOT occupied by the same colored piece 3) If both are true it's occupiable.
    }
}
