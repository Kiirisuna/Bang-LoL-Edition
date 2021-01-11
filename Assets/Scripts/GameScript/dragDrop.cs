using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class dragDrop : NetworkBehaviour
{
    public GameObject Canvas;
    public GameObject DropZone;
    public playerManager PlayerManager;
    
    private bool isDragging = false;
    private bool isDropZone = false;
    private bool isDraggable = true;

    private GameObject dropZone;
    private Vector2 startPosition;
    private GameObject startParent;

    private void Start() {
        Canvas = GameObject.Find("Main Canvas");
        DropZone = GameObject.Find("discardButton");
        if (!hasAuthority) {
            isDraggable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isDropZone = false;
        dropZone = null;
    }

    public void startDrag() {
        if (!isDraggable) return;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
    }

    public void endDrag() {
        if (!isDraggable) return;
        isDragging = false;
        if (isDropZone) {
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<playerManager>();
            PlayerManager.playCard(gameObject);
        } else {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}
