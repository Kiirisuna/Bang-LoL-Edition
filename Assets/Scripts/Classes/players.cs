using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum roles {sheriff, vice, fugitive, renegade };

public class players {
    // The player's hp.
    protected int health;
    // The player's role.
    protected roles role;
    // The player's hand.
    protected List<deckCards> hand;

    public players(roles role, List<deckCards> hand, int health) {
        this.role = role;
        this.hand = hand;
        this.health = health;
    }

    public string getRoleString() {
        switch (role) {
            case roles.sheriff: return "SCERIFFO";
            case roles.vice: return "VICE";
            case roles.fugitive: return "FUORILEGGE";
            case roles.renegade: return "RINNEGATO";
            default: return "-1";
        }
    }

    // Gets the single character version of the card value.
    public int getHealth() {
        return this.health;
    }

    // Gets the string to be written on the face card.
    public List<deckCards> getHand() {
        return this.hand;
    }

    // Return hand size
    public int getHandSize() {
        return this.hand.Count;
    }

    // Add card to hand.
    public void addCard2Hand(deckCards drawn) {
        this.hand.Add(drawn);
    }

    public void removeCard(int index) {
        this.hand.RemoveAt(index);
    }

    public void updateHealth(int u) {
        this.health += u;
    }

    
}
