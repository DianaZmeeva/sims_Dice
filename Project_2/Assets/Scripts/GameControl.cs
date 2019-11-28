using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static int n;

    public GameObject d6, d8, d10;
    private static GameObject player1, player2;

    public static bool gameover = false;

    public static int finalSide = 0;
    public static int player1Start = 0;
    public static int player2Start = 0;

    public Text t1, t2, wt;

    public void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<Move>().flag = false;
        player2.GetComponent<Move>().flag = false;

        if(n==1)
        {
            Destroy(d8);
            Destroy(d10);
        }

        if (n == 2)
        {
            Destroy(d6);
            Destroy(d10);
        }
        if (n == 3)
        {
            Destroy(d6);
            Destroy(d8);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            again();
        }


        if (player1Start == 9 && player2Start == 9)
        {
            t1.text = "Your move";
            t2.text = "";
        }


            if (player1.GetComponent<Move>().i >player1Start + finalSide)
        {
            player1.GetComponent<Move>().flag = false;
            player1Start = player1.GetComponent<Move>().i - 1;
            if (player2Start == 9 && player2.GetComponent<Move>().i10 == false)
            {
                t2.text = "Skip stroke";
            }
            else
            {
                t2.text = "Your move";
                t1.text = "";
            }
            Dice.roll = true;

        }

        if (player2.GetComponent<Move>().i > player2Start + finalSide)
        {
            player2.GetComponent<Move>().flag = false;
            player2Start = player2.GetComponent<Move>().i - 1;
            if (player1Start == 9 && player1.GetComponent<Move>().i10 == false)
            {
                t1.text = "Skip stroke";
            }
            else
            {
                t1.text = "Your move";
                t2.text = "";
            }
            Dice.roll = true;
        }

        if (player1.GetComponent<Move>().i == 15 && player1.GetComponent<Move>().flag == false && player1.GetComponent<Move>().i15 == false)
        {
            t1.text = "Extra turn";
            t2.text = "";
        }

        if (player2.GetComponent<Move>().i == 15 && player2.GetComponent<Move>().flag == false && player2.GetComponent<Move>().i15 == false)
        {
            t2.text = "Extra turn";
            t1.text = "";
        }


        if (player1.GetComponent<Move>().i == player1.GetComponent<Move>().cells.Length)
        {
            gameover = true;
            wt.text = "First player win!!!";
        }

        if (player2.GetComponent<Move>().i == player2.GetComponent<Move>().cells.Length)
        {
            gameover = true;
            wt.text = "Second player win!!!";
        }

        pr();
    }

    private void pr()
    {
        if (player1.GetComponent<Move>().i == 5)
        {
            if (player1.GetComponent<Move>().flag == false)
            {
                player1.GetComponent<Move>().i = 11;
                player1Start = player1.GetComponent<Move>().i - 1;
                player1.transform.position = player1.GetComponent<Move>().cells[player1Start].transform.position;
                player1.GetComponent<Move>().flag = false;
            }
        }

        if (player2.GetComponent<Move>().i == 5)
        {
            if (player2.GetComponent<Move>().flag == false)
            {
                player2.GetComponent<Move>().i = 11;
                player2Start = player2.GetComponent<Move>().i - 1;
                player2.transform.position = player2.GetComponent<Move>().cells[player2Start].transform.position;
                player2.GetComponent<Move>().flag = false;
            }
        }

        if (player1.GetComponent<Move>().i == 20)
        {
            if (player1.GetComponent<Move>().flag == false)
            {
                player1.GetComponent<Move>().i = 14;
                player1Start = player1.GetComponent<Move>().i - 1;
                player1.transform.position = player1.GetComponent<Move>().cells[player1Start].transform.position;
                player1.GetComponent<Move>().flag = false;
            }
        }

        if (player2.GetComponent<Move>().i == 20)
        {
            if (player2.GetComponent<Move>().flag == false)
            {
                player2.GetComponent<Move>().i = 14;
                player2Start = player2.GetComponent<Move>().i - 1;
                player2.transform.position = player2.GetComponent<Move>().cells[player2Start].transform.position;
                player2.GetComponent<Move>().flag = false;
            }
        }

        if (player1.GetComponent<Move>().i == 25)
        {
            if (player1.GetComponent<Move>().flag == false)
            {
                player1.GetComponent<Move>().i = 23;
                player1Start = player1.GetComponent<Move>().i - 1;
                player1.transform.position = player1.GetComponent<Move>().cells[player1Start].transform.position;
                player1.GetComponent<Move>().flag = false;
                
            }
        }

        if (player2.GetComponent<Move>().i == 25)
        {
            if (player2.GetComponent<Move>().flag == false)
            {
                player2.GetComponent<Move>().i = 24;
                player2Start = player2.GetComponent<Move>().i - 1;
                player2.transform.position = player2.GetComponent<Move>().cells[player2Start].transform.position;
                player2.GetComponent<Move>().flag = false;
            }
        }

        if (player1.GetComponent<Move>().i == 30)
        {
            if (player1.GetComponent<Move>().flag == false)
            {
                player1.GetComponent<Move>().i = 19;
                player1Start = player1.GetComponent<Move>().i - 1;
                player1.transform.position = player1.GetComponent<Move>().cells[player1Start].transform.position;
                player1.GetComponent<Move>().flag = false;
            }
        }

        if (player2.GetComponent<Move>().i == 30)
        {
            if (player2.GetComponent<Move>().flag == false)
            {
                player2.GetComponent<Move>().i = 19;
                player2Start = player2.GetComponent<Move>().i - 1;
                player2.transform.position = player2.GetComponent<Move>().cells[player2Start].transform.position;
                player2.GetComponent<Move>().flag = false;
            }
        }
    }

    public static void MovePlayer(int x)
    {
        switch (x)
        {
            case 1:
                player1.GetComponent<Move>().flag = true;
                break;

            case 2:
                player2.GetComponent<Move>().flag = true;
                break;
        }
    }

    private void again()
    {
        gameover = false;

        finalSide = 0;
        player1Start = 0;
        player2Start = 0;
        Dice.turn = 1;
        Dice.roll = true;
        player1.GetComponent<Move>().i = 0;
        player2.GetComponent<Move>().i = 0;
        player1.GetComponent<Move>().i10 = false;
        player2.GetComponent<Move>().i10 = false;
        player1.GetComponent<Move>().i15 = false;
        player2.GetComponent<Move>().i15 = false;
        player1.GetComponent<Move>().flag = false;
        player2.GetComponent<Move>().flag = false;


        SceneManager.LoadScene("Start_Scene");
    }
}