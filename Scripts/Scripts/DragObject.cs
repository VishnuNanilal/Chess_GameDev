using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Handles gameObject getting dragged
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
            canvasGroup.blocksRaycasts = false;

            SetCurrentPiece(eventData.pointerDrag);
            Debug.Log(GameController.instance.currentPiece);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("On Drag");
        rectTransform.anchoredPosition += eventData.delta;
        canvasGroup.alpha = .75f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
        SetCurrentPiece(null);
        
        Debug.Log("End Drag");
    }

    void SetCurrentPiece(GameObject draggedObj) //Sets the dragged object as the current object in game.
    {
        GameController.instance.currentPiece = draggedObj;
    }
}
