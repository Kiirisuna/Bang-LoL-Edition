using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class discardPile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameObject spellCards;
    public GameObject enemyPanel;
    public GameObject yourHand;
    public GameObject theDeck;

    private bool mouseOverDiscard = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOverDiscard) {
            // TODO
            // Create popup with remaining cards in the deck
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        mouseOverDiscard = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        mouseOverDiscard = false;
    }

}
