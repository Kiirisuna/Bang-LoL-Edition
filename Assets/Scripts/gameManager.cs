using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public enum suits { wDiamonds, bClubs, wHearts, bSpades };
public enum cardValue { N2, N3, N4, N5, N6, N7, N8, N9, N10, Jack, Queen, King, Ace };
public enum cardType {
    Bang, Missed, Gatling, Indians, Beer, Saloon, Schofield, Remington, RevCarabine, Winchester, Mustang, Scope, CatBalou, Panic, Barrel,
    Diligenza, WellsFargo, Duel, Dynamite, Jail, Volcanic, Emporio
};
public struct deckCards {
    public cardValue value;
    // The suit of the card.
    public suits suit;
    // The type of the card.
    public cardType type;
}

public struct players {
    public string role;
    public int health;
    public List<GameObject> hand;
}

public class gameManager : NetworkBehaviour
{
    public SyncList<deckCards> draw = new SyncList<deckCards>();
    private SyncList<players> playersList = new SyncList<players>();
    public List<deckCards> discardList = new List<deckCards>();

    public int turnOrder = 0;

    public GameObject spellCards;
    public GameObject enemyPanel;
    public GameObject yourHand;
    public GameObject discard;
    public GameObject deckButton;

    [Server]
    public override void OnStartServer() {
        base.OnStartServer();

        yourHand = GameObject.Find("yourHand");
        enemyPanel = GameObject.Find("enemyPanel");
        discard = GameObject.Find("discardButton");
        deckButton = GameObject.Find("deckButton");

        List<GameObject> tempHand = new List<GameObject>();
        playersList.Add(new players { role = "sheriff", hand = tempHand, health = 4 });
        playersList.Add(new players { role = "vice", hand = tempHand, health = 4 });
        playersList.Add(new players { role = "vice", hand = tempHand, health = 4 });
        playersList.Add(new players { role = "fugitive", hand = tempHand, health = 4 });
        playersList.Add(new players { role = "fugitive", hand = tempHand, health = 4 });
        playersList.Add(new players { role = "fugitive", hand = tempHand, health = 4 });
        playersList.Add(new players { role = "renegade", hand = tempHand, health = 4 });
        fillDeck();
    }

    // Return health of a player
    public int getHealth(int p) {
        return playersList[p].health;
    }

    //******************************************** Deck Stuff ********************************************//
    // Generate entire new deck
    private void fillDeck() {
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Remington, value = cardValue.King });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Dynamite, value = cardValue.N2 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Scope, value = cardValue.Ace });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Barrel, value = cardValue.Queen });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Barrel, value = cardValue.King });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Mustang, value = cardValue.N8 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Mustang, value = cardValue.N9 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Jail, value = cardValue.Jack });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Jail, value = cardValue.N10 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Jail, value = cardValue.N4 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.RevCarabine, value = cardValue.Ace });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Schofield, value = cardValue.Jack });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Schofield, value = cardValue.Queen });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Schofield, value = cardValue.King });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Volcanic, value = cardValue.N10 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Volcanic, value = cardValue.N10 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Winchester, value = cardValue.N8 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Bang, value = cardValue.Ace });
        foreach (cardValue v in System.Enum.GetValues(typeof(cardValue))) {
            draw.Add(new deckCards { suit = suits.wDiamonds, type = cardType.Bang, value = v });
        }
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Bang, value = cardValue.N2 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Bang, value = cardValue.N3 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Bang, value = cardValue.N4 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Bang, value = cardValue.N5 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Bang, value = cardValue.N6 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Bang, value = cardValue.N7 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Bang, value = cardValue.N8 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Bang, value = cardValue.N9 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Bang, value = cardValue.Queen });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Bang, value = cardValue.King });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Bang, value = cardValue.Ace });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Beer, value = cardValue.N6 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Beer, value = cardValue.N7 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Beer, value = cardValue.N8 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Beer, value = cardValue.N9 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Beer, value = cardValue.N10 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Beer, value = cardValue.Jack });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.CatBalou, value = cardValue.King });
        draw.Add(new deckCards { suit = suits.wDiamonds, type = cardType.CatBalou, value = cardValue.N9 });
        draw.Add(new deckCards { suit = suits.wDiamonds, type = cardType.CatBalou, value = cardValue.N10 });
        draw.Add(new deckCards { suit = suits.wDiamonds, type = cardType.CatBalou, value = cardValue.Jack });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Diligenza, value = cardValue.N9 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Diligenza, value = cardValue.N9 });
        draw.Add(new deckCards { suit = suits.wDiamonds, type = cardType.Duel, value = cardValue.Queen });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Duel, value = cardValue.Jack });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Duel, value = cardValue.N8 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Emporio, value = cardValue.N9 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Emporio, value = cardValue.Queen });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Gatling, value = cardValue.N10 });
        draw.Add(new deckCards { suit = suits.wDiamonds, type = cardType.Indians, value = cardValue.King });
        draw.Add(new deckCards { suit = suits.wDiamonds, type = cardType.Indians, value = cardValue.Ace });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Missed, value = cardValue.N10 });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Missed, value = cardValue.Jack });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Missed, value = cardValue.King });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Missed, value = cardValue.Queen });
        draw.Add(new deckCards { suit = suits.bClubs, type = cardType.Missed, value = cardValue.Ace });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Missed, value = cardValue.N2 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Missed, value = cardValue.N3 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Missed, value = cardValue.N4 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Missed, value = cardValue.N5 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Missed, value = cardValue.N6 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Missed, value = cardValue.N7 });
        draw.Add(new deckCards { suit = suits.bSpades, type = cardType.Missed, value = cardValue.N8 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Panic, value = cardValue.Jack });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Panic, value = cardValue.Queen });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Panic, value = cardValue.Ace });
        draw.Add(new deckCards { suit = suits.wDiamonds, type = cardType.Panic, value = cardValue.N8 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.Saloon, value = cardValue.N5 });
        draw.Add(new deckCards { suit = suits.wHearts, type = cardType.WellsFargo, value = cardValue.N3 });

        shuffleDeck();
    }

    // Shuffle deck
    private void shuffleDeck() {
        System.Random rng = new System.Random();
        // Note: It's important to only select a number into each index once.
        // Otherwise you'll get bias toward some numbers over others.
        for (int i = draw.Count - 1; i >= 0; i--) {
            int number = rng.Next(i);
            swapCards(i, number);
        }
    }

    // Function for swapping positions 
    // Hyper-Kinetic Position Reverser LUL
    private void swapCards(int i, int j) {
        deckCards temp = draw[i];
        draw[i] = draw[j];
        draw[j] = temp;
    }

    // Return card at specified location in deck
    private deckCards getDeckCard(int i) {
        return draw[i];
    }

    // Remove card from deck (after add to hand/discard)
    private void removeFromDeck(int r) {
        draw.RemoveAt(r);
    }

    //****************************************** Draw Stuff ********************************************//
    // Draw card helper function
    public GameObject drawCards() {
        int p = 0;
        if (draw.Count > 0) {
            deckCards drawn = getDeckCard(0);
            removeFromDeck(0);

            GameObject toAdd = Instantiate(spellCards, new Vector3(0, 0, 0), Quaternion.identity);
            toAdd.name = drawn.type.ToString();
            toAdd.GetComponent<spellData>().updateCard(playersList[p].hand.Count, drawn);
            playersList[p].hand.Add(toAdd);

            return toAdd;
        } else if(discardList.Count > 0) {
            reshuffleDiscard();
            deckCards drawn = getDeckCard(0);
            removeFromDeck(0);

            GameObject toAdd = Instantiate(spellCards, new Vector3(0, 0, 0), Quaternion.identity);
            toAdd.name = drawn.type.ToString();
            toAdd.GetComponent<spellData>().updateCard(playersList[p].hand.Count, drawn);
            playersList[p].hand.Add(toAdd);

            return toAdd;
        } else {
            // TODO : how do i do errors (?)
            return null;
        }
    }

    //********************************************* Discard Logic *******************************************//
    // Remove card from discard (adding to hand)
    private void removeFromDiscard(int r) {
        discardList.RemoveAt(r);
    }

    // Reshuffle discard pile back into deck
    private void reshuffleDiscard() {
        deckCards temp = getDiscardCard(0);
        removeFromDiscard(0);
        foreach (deckCards c in getDiscardPile()) {
            draw.Add(c);
        }
        clearDiscard();
        // Add last discarded card back
        playDiscard(temp);
        shuffleDeck();
    }

    // Add to discard pile after a card is played
    public void playDiscard(deckCards card) {
        discardList.Insert(0, card);
    }

    // Clear discard pile
    private void clearDiscard() {
        discardList.Clear();
    }

    // Return card at specified location in discard
    private deckCards getDiscardCard(int i) {
        return discardList[i];
    }

    // Return entire discard pile (display purposes)
    public List<deckCards> getDiscardPile() {
        return discardList;
    }

    private int getDiscardSize() {
        return discardList.Count;
    }

    //************************************************ Play Stuff **********************************************//
    // Remove card after being played
    public void removeCardHand(int p, int index) {
        playDiscard(playersList[p].hand[index].GetComponent<spellData>().getCard());
        GameObject.Destroy(playersList[p].hand[index]);
        playersList[p].hand.RemoveAt(index);
        int handCount = 0;
        for (int k = 0; k < playersList[p].hand.Count; k++) {
            playersList[p].hand[k].GetComponent<spellData>().updateIndex(handCount);
            handCount++;
        }
    }
}
