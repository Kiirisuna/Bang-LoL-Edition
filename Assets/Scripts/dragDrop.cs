using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragDrop : MonoBehaviour
{
    public GameObject Canvas;
    
    private bool isDragging = false;
    private bool isDropZone = false;
    private GameObject dropZone;
    private Vector2 startPosition;
    private GameObject startParent;

    private void Awake() {
        Canvas = GameObject.Find("Main Canvas");
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
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
    }

    public void endDrag() {
        isDragging = false;
        if (isDropZone) {
            deckGen.playCard(0, gameObject.GetComponent<spellData>().returnIndex());
            GameObject.Destroy(gameObject);
        } else {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}
