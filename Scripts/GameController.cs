using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject currentPiece = null; //The oobject we is the current piece anytime.
    public GameObject currentPlaceHolder;  //The placeHolder from which we drag the piece is the current placeholder anytime.

    public Transform[] placeHolderPos = new Transform[64];
    
    private void Awake()
    {
        instance = this;
    }
}
