﻿using UnityEngine;
using System.Collections;
using Mirror;

public class SceneObject : NetworkBehaviour
{
    //sync the item on the server to all clients
    [SyncVar(hook = nameof(onChangeItem))]
    public EquippedItem equippedItem;


    //rock prefab
    public GameObject rockPrefab;
    
    void onChangeItem(EquippedItem oldEquippedItem, EquippedItem newEquippedItem)
    {

        StartCoroutine(ChangeEquipment(newEquippedItem));

    }

    //change item
    IEnumerator ChangeEquipment(EquippedItem newEquippedItem)
    {

        //destroy anything the hand is holding
        while (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
            yield return null;
        }

        // Use the new value, not the SyncVar property value
        SetEquippedItem(newEquippedItem);
    }
   
    public void SetEquippedItem(EquippedItem newEquippedItem)
    {
        //attach item to scene
        switch (newEquippedItem)
        {
            case EquippedItem.rock:

                Instantiate(rockPrefab, transform);
                break;

        }
    }

    void Update()
    {
        Debug.Log(NetworkClient.connection.identity);
        if (Input.GetKeyDown(KeyCode.E))
        {
            float dist = Vector3.Distance(NetworkClient.connection.identity.transform.position, transform.position);
            if(dist <= 2.5f)
            {
                Debug.Log(gameObject);
                equippedItem = EquippedItem.rock;
                Debug.Log("onKeyDown");
                Debug.Log(NetworkClient.connection.identity);
                NetworkClient.connection.identity.GetComponent<ItemPickUp>().CmdPickupItem(gameObject);
            }
        }
    }
    void OnMouseDown()
    {
        
        Debug.Log("onMouseDown");
    }
}