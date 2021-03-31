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

        if (eventData != null)
        {
            if (!GetComponent<PlaceHolderStats>().isOccupied) //TODO Check if it's Occupied by a different color. If not return.
            {
                if (algo.MovementPossible(placeHolderStats.xPos, placeHolderStats.yPos,eventData.pointerDrag))
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    eventData.pointerDrag.GetComponent<PieceStats>().SetNewPos(placeHolderStats.xPos, placeHolderStats.yPos); //passes PH's x and y pos to be set as the current object's x and y 
                    Debug.Log("Placed!");
                    eventData.pointerDrag.GetComponent<PieceStats>().PlaceHolderOfThisPiece = thisPlaceHolder;
                    dropped = true;
                }

            }
        }
        if (!dropped)
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<PieceStats>().PlaceHolderOfThisPiece.GetComponent<RectTransform>().anchoredPosition;

    }

    //TODO
    private bool isOccupiable()
    {
        return true; //TODO Checks if the slot is occupiable; 1) if the move is possible for the dragged piece 2) If possible, check if the slot is NOT occupied by the same colored piece 3) If both are true it's occupiable.
    }
}
