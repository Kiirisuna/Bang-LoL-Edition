using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;




public class playerManager : NetworkBehaviour {
    public GameObject spellCards;
    public GameObject enemyPanel;
    public GameObject yourHand;
    public GameObject discard;
    public GameObject deckButton;
    public GameObject gameManager;

    public override void OnStartClient() {
        base.OnStartClient();

        yourHand = GameObject.Find("yourHand");
        enemyPanel = GameObject.Find("enemyPanel");
        discard = GameObject.Find("discardButton");
        deckButton = GameObject.Find("deckButton");
        gameManager = GameObject.Find("gameManager");
    }

    [Server]
    public override void OnStartServer() {
        
    }

    //************************************************** Draw Stuff ***********************************************//
    [Command]
    public void CmdDealCards() {
        
    }

    public void drawCards() {
        CmdDrawCards();
    }

    [Command]
    void CmdDrawCards() {
        GameObject toAdd = gameManager.GetComponent<gameManager>().drawCards();
        NetworkServer.Spawn(toAdd, connectionToClient);
        RpcShowCard(toAdd, "Dealt");
    }


    [ClientRpc]
    void RpcShowCard(GameObject card, string type) {
        if (type == "Dealt") {
            if (hasAuthority) {
                card.transform.SetParent(yourHand.transform, false);
            } 
        } else if (type == "Played") {
            GameObject.Destroy(card);
        }
    }

    //**************************************** Play Stuff *******************************************//

    // Play card from hand
    public void playCard(GameObject card) {
        CmdPlayCard(card);
    }

    [Command]
    void CmdPlayCard(GameObject card) {
        gameManager.GetComponent<gameManager>().removeCardHand(0, card.GetComponent<spellData>().returnIndex());
        RpcShowCard(card, "Played");
    }
}
