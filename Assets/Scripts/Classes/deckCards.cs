using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum suits { wDiamonds, bClubs, wHearts, bSpades  };
public enum cardValue {N2, N3, N4, N5, N6, N7, N8, N9, N10, Jack, Queen, King, Ace };
public enum cardType {
    Bang, Missed, Gatling, Indians, Beer, Saloon, Schofield, Remington, RevCarabine, Winchester, Mustang, Scope, CatBalou, Panic, Barrel,
    Diligenza, WellsFargo, Duel, Dynamite, Jail, Volcanic, Emporio
};

public class deckCards {  
    // The value of the card.
    protected cardValue value;
    // The suit of the card.
    protected suits suit;
    // The type of the card.
    protected cardType type;

    public deckCards(suits suit, cardType type, cardValue value) {
        this.suit = suit;
        this.type = type;
        this.value = value;
    }

    public suits getSuitRaw() {
        return this.suit;
    }

    public cardValue getValueRaw() {
        return this.value;
    }

    public cardType getTypeRaw() {
        return this.type;
    }

    public string getSuitString() {
        switch (suit)
        {
            case suits.bSpades: return "\u2660";
            case suits.bClubs: return "\u2663";
            case suits.wHearts: return "\u2661";
            case suits.wDiamonds: return "\u2662";
            default: return "null";
        }
    }

    //Gets the single character version of the card value.
    public string getShortValue() {
        switch (value) {
            case cardValue.Ace: return "A";
            case cardValue.Jack: return "J";
            case cardValue.King: return "K";
            case cardValue.N10: return "10";
            case cardValue.N2: return "2";
            case cardValue.N3: return "3";
            case cardValue.N4: return "4";
            case cardValue.N5: return "5";
            case cardValue.N6: return "6";
            case cardValue.N7: return "7";
            case cardValue.N8: return "8";
            case cardValue.N9: return "9";
            case cardValue.Queen: return "Q";
            default: return "null";
        }
    }

    //Gets the string to be written on the face card.
    public string getCardString() {
        switch (type) {
            case cardType.Bang: return "BANG!";
            case cardType.Missed: return "MISS!";
            case cardType.Gatling: return "GATLING";
            case cardType.Indians: return "INDIANS!";
            case cardType.Beer: return "BIRRA";
            case cardType.Saloon: return "SALOON";
            case cardType.Schofield: return "SCHOFIELD";
            case cardType.Remington: return "REMINGTON";
            case cardType.RevCarabine: return "REV. CARABINE";
            case cardType.Winchester: return "WINCHESTER";
            case cardType.Mustang: return "MUSTANG";
            case cardType.Scope: return "SCOPE";
            case cardType.CatBalou: return "CAT BALOU";
            case cardType.Barrel: return "BARILE";
            case cardType.Diligenza: return "DILIGENZA";
            case cardType.WellsFargo: return "WELLS FARGO";
            case cardType.Panic: return "PANICO!";
            case cardType.Duel: return "DUELLO";
            case cardType.Emporio: return "EMPORIO";
            case cardType.Dynamite: return "DINAMITE";
            case cardType.Jail: return "PRIGIONE";
            case cardType.Volcanic: return "VOLCANIC";
            default: return "null";
        }
    }
}

