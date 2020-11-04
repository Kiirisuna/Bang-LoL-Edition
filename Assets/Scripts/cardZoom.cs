using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardZoom : MonoBehaviour
{
    public GameObject canvas;

    private GameObject zoomCard;

    public void Awake() {
        canvas = GameObject.Find("Main Canvas");
    }

    // Execute when mouse hovers over card
    public void onHoverEnter() {
        zoomCard = Instantiate(gameObject, new Vector2(250, 270), Quaternion.identity);
        zoomCard.transform.SetParent(canvas.transform, false);
        zoomCard.GetComponent<spellData>().updateCard(0, gameObject.GetComponent<spellData>().getCard());
        zoomCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(300, 600);
    }

    public void onHoverExit() {
        Destroy(zoomCard);
    }
}
