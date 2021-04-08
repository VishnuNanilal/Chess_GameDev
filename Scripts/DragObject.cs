using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Handles gameObject getting dragged
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //public RayCastHandler rayCastHandler;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    GameObject[] pieces;
    PieceStats pieceStats;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        pieceStats = GetComponent<PieceStats>();
        canvasGroup = GetComponent<CanvasGroup>();
        pieces = GameObject.FindGameObjectsWithTag("Piece");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        foreach (GameObject piece in pieces)
        {
            piece.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }    
        

        SetCurrentDraggedPiece(eventData.pointerDrag);
        SetCurrentPlaceHolder(eventData.pointerDrag);

        if (GameController.instance.CheckTurn())
            GameController.instance.isCorrectTurn = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!GameController.instance.isCorrectTurn)
            return;

        rectTransform.anchoredPosition += eventData.delta;
        canvasGroup.alpha = .75f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        foreach (GameObject piece in pieces)
        {
            piece.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        canvasGroup.alpha = 1;
        SetCurrentDraggedPiece(null);
    }   

    void SetCurrentDraggedPiece(GameObject pointerDrag) //Sets the dragged object as the current object in game.
    {
        GameController.instance.activePiece = pointerDrag;
    }


    void SetCurrentPlaceHolder(GameObject pointerDrag)
    {
        GameController.instance.activePlaceHolder = pointerDrag.GetComponent<PieceStats>().PlaceHolderOfThisPiece;
    }

}
