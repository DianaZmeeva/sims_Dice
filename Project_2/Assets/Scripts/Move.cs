using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public Transform[] cells;

    [SerializeField]
    private float V= 1f;

    [HideInInspector]
    public int i = 0;

    public bool flag = false;
    public bool i10, i15 = false;



    void Start () {
        transform.position = cells[i].transform.position;
    }
	
	void Update () {
        if (flag)
            Go();
    }

    private void Go()
    {
        if (i < cells.Length)
        {
            //transform.position = cells[i].transform.position;
            transform.position = Vector3.MoveTowards(transform.position, cells[i].transform.position, V * Time.deltaTime);
            //i++;

            if (transform.position == cells[i].transform.position)
            {
                i += 1;
            }
        }
    }
}
