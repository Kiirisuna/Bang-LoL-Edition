using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spellData : MonoBehaviour
{
    protected deckCards card;
    protected int handIndex;

    public Text displaySuit;
    public Text displayName;
    public Image loaded;
    public Image desc;

    public Sprite bang1;
    public Sprite bang2;

    // Start is called before the first frame update
    void Start()
    {
        displaySuit.text = card.getShortValue() + card.getSuitString();
        displayName.text = card.getCardString();
        loadSprite();
    }

    // Update is called once per frame
    void Update() {

    }

    public void updateCard (int index, deckCards card) {
        this.handIndex = index;
        this.card = card;
    }

    public int returnIndex() {
        return this.handIndex;
    }

    public deckCards getCard() {
        return this.card;
    }

    private void loadSprite() {
        switch (card.getTypeRaw()) {
            case cardType.Bang: desc.GetComponent<Image>().sprite = bang2; break;
            //case cardType.Missed: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Gatling: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Indians: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Beer: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Saloon: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Schofield: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Remington: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.RevCarabine: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Winchester: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Mustang: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Scope: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.CatBalou: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Barrel: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Diligenza: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.WellsFargo: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Panic: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Duel: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Emporio: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Dynamite: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Jail: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //case cardType.Volcanic: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
            //default: loaded = Resources.Load<Image>("Artwork/Lucian"); break;
        }
    }
    
}
