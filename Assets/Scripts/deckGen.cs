using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class deckGen : MonoBehaviour{
    public GameObject spellCards;
    public GameObject enemyPanel;
    public GameObject yourHand;


    //public const int LIMIT = 80;
    private static List<deckCards> draw = new List<deckCards>();
    private static List<players> playersList = new List<players>();
    private static List<deckCards> discard = new List<deckCards>();


    private static bool drawHand = false;
    // Start is called before the first frame update
    void Start() {
        Debug.Log("started");
        fillDeck();
        List<deckCards> tempHand = new List<deckCards>();
        playersList.Add(new players(roles.sheriff, tempHand, 4));
    }

    // Update is called once per frame
    void Update() {
       

        if (drawHand) {
            instantiateHand(0);
        }
    }
    
    //********************************************* Deck Logic *******************************************//

    // Shuffle deck
    private static void shuffleDeck() {
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
    private static void swapCards(int i, int j) {
        deckCards temp = draw[i];
        draw[i] = draw[j];
        draw[j] = temp;
    }

    // Generate entire new deck
    private void fillDeck() {
        draw.Add(new deckCards(suits.bClubs, cardType.Remington, cardValue.King));
        draw.Add(new deckCards(suits.wHearts, cardType.Dynamite, cardValue.N2));
        draw.Add(new deckCards(suits.bSpades, cardType.Scope, cardValue.Ace));
        draw.Add(new deckCards(suits.bSpades, cardType.Barrel, cardValue.Queen));
        draw.Add(new deckCards(suits.bSpades, cardType.Barrel, cardValue.King));
        draw.Add(new deckCards(suits.wHearts, cardType.Mustang, cardValue.N8));
        draw.Add(new deckCards(suits.wHearts, cardType.Mustang, cardValue.N9));
        draw.Add(new deckCards(suits.bSpades, cardType.Jail, cardValue.Jack));
        draw.Add(new deckCards(suits.bSpades, cardType.Jail, cardValue.N10));
        draw.Add(new deckCards(suits.wHearts, cardType.Jail, cardValue.N4));
        draw.Add(new deckCards(suits.bClubs, cardType.RevCarabine, cardValue.Ace));
        draw.Add(new deckCards(suits.bClubs, cardType.Schofield, cardValue.Jack));
        draw.Add(new deckCards(suits.bClubs, cardType.Schofield, cardValue.Queen));
        draw.Add(new deckCards(suits.bSpades, cardType.Schofield, cardValue.King));
        draw.Add(new deckCards(suits.bSpades, cardType.Volcanic, cardValue.N10));
        draw.Add(new deckCards(suits.bClubs, cardType.Volcanic, cardValue.N10));
        draw.Add(new deckCards(suits.bSpades, cardType.Winchester, cardValue.N8));
        draw.Add(new deckCards(suits.bSpades, cardType.Bang, cardValue.Ace));
        foreach (cardValue v in System.Enum.GetValues(typeof(cardValue))) {
            draw.Add(new deckCards(suits.wDiamonds, cardType.Bang, v));
        }
        draw.Add(new deckCards(suits.bClubs, cardType.Bang, cardValue.N2));
        draw.Add(new deckCards(suits.bClubs, cardType.Bang, cardValue.N3));
        draw.Add(new deckCards(suits.bClubs, cardType.Bang, cardValue.N4));
        draw.Add(new deckCards(suits.bClubs, cardType.Bang, cardValue.N5));
        draw.Add(new deckCards(suits.bClubs, cardType.Bang, cardValue.N6));
        draw.Add(new deckCards(suits.bClubs, cardType.Bang, cardValue.N7));
        draw.Add(new deckCards(suits.bClubs, cardType.Bang, cardValue.N8));
        draw.Add(new deckCards(suits.bClubs, cardType.Bang, cardValue.N9));
        draw.Add(new deckCards(suits.wHearts, cardType.Bang, cardValue.Queen));
        draw.Add(new deckCards(suits.wHearts, cardType.Bang, cardValue.King));
        draw.Add(new deckCards(suits.wHearts, cardType.Bang, cardValue.Ace));
        draw.Add(new deckCards(suits.wHearts, cardType.Beer, cardValue.N6));
        draw.Add(new deckCards(suits.wHearts, cardType.Beer, cardValue.N7));
        draw.Add(new deckCards(suits.wHearts, cardType.Beer, cardValue.N8));
        draw.Add(new deckCards(suits.wHearts, cardType.Beer, cardValue.N9));
        draw.Add(new deckCards(suits.wHearts, cardType.Beer, cardValue.N10));
        draw.Add(new deckCards(suits.wHearts, cardType.Beer, cardValue.Jack));
        draw.Add(new deckCards(suits.wHearts, cardType.CatBalou, cardValue.King));
        draw.Add(new deckCards(suits.wDiamonds, cardType.CatBalou, cardValue.N9));
        draw.Add(new deckCards(suits.wDiamonds, cardType.CatBalou, cardValue.N10));
        draw.Add(new deckCards(suits.wDiamonds, cardType.CatBalou, cardValue.Jack));
        draw.Add(new deckCards(suits.bSpades, cardType.Diligenza, cardValue.N9));
        draw.Add(new deckCards(suits.bSpades, cardType.Diligenza, cardValue.N9));
        draw.Add(new deckCards(suits.wDiamonds, cardType.Duel, cardValue.Queen));
        draw.Add(new deckCards(suits.bSpades, cardType.Duel, cardValue.Jack));
        draw.Add(new deckCards(suits.bClubs, cardType.Duel, cardValue.N8));
        draw.Add(new deckCards(suits.bClubs, cardType.Emporio, cardValue.N9));
        draw.Add(new deckCards(suits.bSpades, cardType.Emporio, cardValue.Queen));
        draw.Add(new deckCards(suits.wHearts, cardType.Gatling, cardValue.N10));
        draw.Add(new deckCards(suits.wDiamonds, cardType.Indians, cardValue.King));
        draw.Add(new deckCards(suits.wDiamonds, cardType.Indians, cardValue.Ace));
        draw.Add(new deckCards(suits.bClubs, cardType.Missed, cardValue.N10));
        draw.Add(new deckCards(suits.bClubs, cardType.Missed, cardValue.Jack));
        draw.Add(new deckCards(suits.bClubs, cardType.Missed, cardValue.King));
        draw.Add(new deckCards(suits.bClubs, cardType.Missed, cardValue.Queen));
        draw.Add(new deckCards(suits.bClubs, cardType.Missed, cardValue.Ace));
        draw.Add(new deckCards(suits.bSpades, cardType.Missed, cardValue.N2));
        draw.Add(new deckCards(suits.bSpades, cardType.Missed, cardValue.N3));
        draw.Add(new deckCards(suits.bSpades, cardType.Missed, cardValue.N4));
        draw.Add(new deckCards(suits.bSpades, cardType.Missed, cardValue.N5));
        draw.Add(new deckCards(suits.bSpades, cardType.Missed, cardValue.N6));
        draw.Add(new deckCards(suits.bSpades, cardType.Missed, cardValue.N7));
        draw.Add(new deckCards(suits.bSpades, cardType.Missed, cardValue.N8));
        draw.Add(new deckCards(suits.wHearts, cardType.Panic, cardValue.Jack));
        draw.Add(new deckCards(suits.wHearts, cardType.Panic, cardValue.Queen));
        draw.Add(new deckCards(suits.wHearts, cardType.Panic, cardValue.Ace));
        draw.Add(new deckCards(suits.wDiamonds, cardType.Panic, cardValue.N8));
        draw.Add(new deckCards(suits.wHearts, cardType.Saloon, cardValue.N5));
        draw.Add(new deckCards(suits.wHearts, cardType.WellsFargo, cardValue.N3));

        shuffleDeck();
    }

    // Return remaining size of the deck
    public static int getDeckRemains() {
        return draw.Count;
    }

    // Return card at specified location in deck
    private static deckCards getDeckCard(int i) {
        return draw[i];
    }

    // Remove card from deck (after add to hand/discard)
    private static void removeFromDeck(int r) {
        draw.RemoveAt(r);
    }

    // Draw card logic
    public static void drawCard(int p) {
        deckCards drawn = getDeckCard(0);
        // Place into appropriate player's hand
        playersList[p].addCard2Hand(drawn);
        removeFromDeck(0);
        drawHand = true;
    }

    // Return individual player data
    private static players getPlayerData(int p) {
        return playersList[p];
    }

    // Remove card after being played
    private void removeCardHand(int p, int index) {
        playersList[p].removeCard(index);
    }

    //********************************************* Discard Logic *******************************************//

    // Return card at specified location in discard
    public static deckCards getDiscardCard(int i) {
        return discard[i];
    }

    // Return entire discard pile (display purposes)
    public static List<deckCards> getDiscardPile() {
        return discard;
    }

    // Remove card from discard (adding to hand)
    private static void removeFromDiscard(int r) {
        discard.RemoveAt(r);
    }

    // Add to discard pile after a card is played
    private static void playDiscard(deckCards card) {
        discard.Insert(0, card);
    }

    // Clear discard pile
    private static void clearDiscard() {
        discard.Clear();
    }

    // Reshuffle discard pile back into deck
    public static void reshuffleDiscard() {
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

    //********************************************* Hand *******************************************//

    // Play card from hand
    public static void playCard(int p, int hi) {
        playersList[p].removeCard(hi);
        drawHand = true;
    }

    // Instantiate hand for player
    public void instantiateHand(int p) {
        // Update is called once per frame
        while (yourHand.transform.childCount > 0) {
            DestroyImmediate(yourHand.transform.GetChild(0).gameObject);
        }

        int handCount = 0;
        foreach (deckCards dc in playersList[p].getHand()) {
            GameObject playerCard = Instantiate(spellCards, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(yourHand.transform, false);
            playerCard.name = dc.getCardString();
            playerCard.GetComponent<spellData>().updateCard(handCount, dc);
            handCount++;

            
        }
        drawHand = false;
    }
}
