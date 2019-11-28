//using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public string number;
    public int n;

    private static GameObject player1, player2;

    public static int turn = 1;
    public static bool roll = true;


    private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>(number);

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

    }

    private void OnMouseDown()
    {
        if (roll && !GameControl.gameover)
        {
             StartCoroutine("RollTheDice");
        }
    }

    private IEnumerator RollTheDice()
    {
        roll = false;

        int randomDiceSide = 0;
        int finalside = 0;

        for (int j = 0; j <= 15; j++)
        {
            randomDiceSide = UnityEngine.Random.Range(0, n);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        finalside = randomDiceSide + 1;
        GameControl.finalSide = finalside;

        propusk();
        dop();

        if (turn == 1)
        {
            GameControl.MovePlayer(1);
        }
        else if (turn == -1)
        {
            GameControl.MovePlayer(2);
        }
        turn *= -1;
        //roll = true;
        Debug.Log(finalside);
    }

    private void dop()
    {
        if(player1.GetComponent<Move>().i==15 && player1.GetComponent<Move>().i15 == false)
        {
            turn = 1;
            player1.GetComponent<Move>().i15 = true;
        }

        if (player2.GetComponent<Move>().i == 15 && player2.GetComponent<Move>().i15 == false)
        {
            turn = -1;
            player2.GetComponent<Move>().i15 = true;
        }
    }

    private void propusk()
    {

        if (GameControl.player1Start == 9 && turn == 1)
        {
            if (player1.GetComponent<Move>().i10 == false)
            {
                turn = -1;
                player1.GetComponent<Move>().i10 = true;
            }
        }

        if (GameControl.player2Start == 9 && turn == -1)
        {
            if (player2.GetComponent<Move>().i10 == false)
            {
                turn = 1;
                player2.GetComponent<Move>().i10 = true;
            }
        }
    }
}
