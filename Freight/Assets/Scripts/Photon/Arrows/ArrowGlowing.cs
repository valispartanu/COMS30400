﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//this script is placed on the player
//it finds all the tutorial arrows and makes them glow when the player is near them
public class ArrowGlowing : MonoBehaviourPun
{

    GameObject[] arrows;
    // Start is called before the first frame update
    void Start()
    {
        arrows = GameObject.FindGameObjectsWithTag("Arrow");
    }

    // Update is called once per frame
    void Update()
    {
        if(!photonView.IsMine)
            return;
        foreach(var arrow in arrows) {
            if(Vector3.Distance(transform.position, arrow.transform.position) < 25)
                arrow.GetComponent<Outline>().enabled = true;
            else
                arrow.GetComponent<Outline>().enabled = false;
            
        }
    }
}
