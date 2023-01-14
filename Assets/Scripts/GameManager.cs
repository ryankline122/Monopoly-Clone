using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dice[] dice;
    public Pawn[] pawns;

    private Pawn currentPlayer;

    private void Update()
    {
        currentPlayer = pawns[0];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeTurn(currentPlayer);
        }
    }


    void TakeTurn(Pawn player)
    {
        currentPlayer = player;
        

        foreach(Dice die in dice) 
        {
            die.RollDice();
        }
        StartCoroutine(WaitForNewDiceVal(6));
    }

    IEnumerator WaitForNewDiceVal(int seconds)
    {
        int steps = 0;

        yield return new WaitForSeconds(seconds);
        foreach (Dice die in dice)
        {
           die.SideValueCheck();
            steps += die.diceValue;
        }

        //pawns[0].steps= steps;
        Debug.Log("Steps = " + steps);
        currentPlayer.steps= steps;
    }

}
