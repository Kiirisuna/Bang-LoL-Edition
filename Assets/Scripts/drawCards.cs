using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Security.Cryptography;

public class drawCards : MonoBehaviour {
    public GameObject spellCards;
    public GameObject enemyPanel;
    public GameObject yourHand;
    public GameObject canvas;


    public Transform popuptext;
    private Transform popping;
    // Start is called before the first frame update
    public void Awake() {
        canvas = GameObject.Find("Main Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onHoverEnter() {
        //popuptext.GetComponent<TextMesh>().text = deckGen.getDeckRemains().ToString();
        //popping = Instantiate(popuptext, new Vector3(transform.position.x, transform.position.y, 0), popuptext.rotation);
    }

    public void onHoverExit() {
       // Destroy(popping);
    }



    public void onClick() {
        if (deckGen.getDeckRemains() > 0) {
            // This is not actually drawing a card btw
            deckGen.drawCard(0);
        } else {
            deckGen.reshuffleDiscard();
            deckGen.drawCard(0);
        }
    }
}
