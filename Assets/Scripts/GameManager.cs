using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Dice[] dice;
    public Pawn[] pawns;
    public Pawn currentPlayer;
    public Button rollButton;

    bool isRolling;

    private void Start()
    {
        isRolling= false;
    }

    private void Update()
    {
        
    }


    public void TakeTurn(Pawn player)
    {
        rollButton.interactable = true;

        if (!isRolling) 
        {
            rollButton.interactable= false;
            isRolling = true;
            currentPlayer = player;

            foreach (Dice die in dice)
            {
                die.RollDice();
            }
            StartCoroutine(WaitForNewDiceVal(6));
        }
        
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

        Debug.Log("Steps = " + steps);
        currentPlayer.steps= steps;
        isRolling= false;
    }

}
