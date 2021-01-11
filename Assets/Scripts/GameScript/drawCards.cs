using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Mirror;

public class drawCards : NetworkBehaviour {

    //public Transform popuptext;
    //private Transform popping;
    public playerManager PlayerManager;
    public gameManager GameManager;

    [SyncVar]
    public int returner;

    private void Start() {
        GameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    [Server]
    public override void OnStartServer() {
        
    }

    public void onHoverEnter() {
        //popuptext.GetComponent<TextMesh>().text = deckGen.getDeckRemains().ToString();
        //popping = Instantiate(popuptext, new Vector3(transform.position.x, transform.position.y, 0), popuptext.rotation);
    }

    public void onHoverExit() {
       // Destroy(popping);
    }

    public void onClick() {
        // When you start a client, that client has an identity and we want to store that identity (should probably store this in playerlist as well)
        NetworkIdentity networkID = NetworkClient.connection.identity;
        PlayerManager = networkID.GetComponent<playerManager>();
        PlayerManager.drawCards();
    }
}
