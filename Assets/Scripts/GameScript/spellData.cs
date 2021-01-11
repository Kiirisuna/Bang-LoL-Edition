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

    public void updateCard (int index, deckCards card) {
        this.handIndex = index;
        this.card = card;

        string temp1;
        string temp2;
        string temp3;

        switch (card.suit) {
            case suits.bSpades: temp1 = "\u2660"; break;
            case suits.bClubs: temp1 =  "\u2663"; break;
            case suits.wHearts: temp1 = "\u2661"; break;
            case suits.wDiamonds: temp1 = "\u2662"; break;
            default: temp1 = "null"; break;
        }

        switch (card.value) {
            case cardValue.Ace: temp2 = "A"; break;
            case cardValue.Jack: temp2 = "J"; break;
            case cardValue.King: temp2 = "K"; break;
            case cardValue.N10: temp2 = "10"; break;
            case cardValue.N2: temp2 = "2"; break;
            case cardValue.N3: temp2 = "3"; break;
            case cardValue.N4: temp2 =  "4"; break;
            case cardValue.N5:  temp2 =  "5"; break;
            case cardValue.N6: temp2 = "6"; break;
            case cardValue.N7: temp2 = "7"; break;
            case cardValue.N8: temp2 = "8"; break;
            case cardValue.N9: temp2 = "9"; break;
            case cardValue.Queen: temp2 = "Q"; break;
            default: temp2 = "null"; break;
        }

        switch (card.type) {
            case cardType.Bang: temp3 = "BANG!"; break;
            case cardType.Missed: temp3 = "MISS!"; break;
            case cardType.Gatling: temp3 = "GATLING"; break;
            case cardType.Indians: temp3 = "INDIANS!"; break;
            case cardType.Beer: temp3 = "BIRRA"; break;
            case cardType.Saloon: temp3 = "SALOON"; break;
            case cardType.Schofield: temp3 = "SCHOFIELD"; break;
            case cardType.Remington: temp3 = "REMINGTON"; break;
            case cardType.RevCarabine: temp3 = "REV. CARABINE"; break;
            case cardType.Winchester: temp3 = "WINCHESTER"; break;
            case cardType.Mustang: temp3 = "MUSTANG"; break;
            case cardType.Scope: temp3 = "SCOPE"; break;
            case cardType.CatBalou: temp3 = "CAT BALOU"; break;
            case cardType.Barrel: temp3 = "BARILE"; break;
            case cardType.Diligenza: temp3 = "DILIGENZA"; break;
            case cardType.WellsFargo: temp3 = "WELLS FARGO"; break;
            case cardType.Panic: temp3 = "PANICO!"; break;
            case cardType.Duel: temp3 = "DUELLO"; break;
            case cardType.Emporio: temp3 = "EMPORIO"; break;
            case cardType.Dynamite: temp3 = "DINAMITE"; break;
            case cardType.Jail: temp3 = "PRIGIONE"; break;
            case cardType.Volcanic: temp3 = "VOLCANIC"; break;
            default: temp3 = "null"; break;
        }
        displaySuit.text = temp2 + temp1;
        displayName.text = temp3;
        loadSprite();
    }

    public int returnIndex() {
        return this.handIndex;
    }

    public deckCards getCard() {
        return this.card;
    }

    public void updateIndex(int i) {
        this.handIndex = i;
    }

    private void loadSprite() {
        //switch (card.getTypeRaw()) {
            //case cardType.Bang: desc.GetComponent<Image>().sprite = bang2; break;
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
        //}
    }
    
}
