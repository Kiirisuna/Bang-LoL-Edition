using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public characterCard card;
    public Text nameText;
    public Text descrptionText;

    public Image artworkImage;
    public Text rangeText;
    public Text attackText;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descrptionText.text = card.description;

        artworkImage.sprite = card.artwork;
        rangeText.text = card.range.ToString();
        healthText.text = card.health.ToString();

        if (card.attack == 999) {
            attackText.text = "\u221E";
        } else {
            attackText.text = card.attack.ToString();
        }
        
    }


}
