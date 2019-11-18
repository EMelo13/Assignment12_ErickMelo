﻿using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public Color color;

    float moveSpeed = 1.875f;


    public override void OnStartClient()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        MoveIt(x, y);
    }

    void MoveIt(float x, float y)
    {
        transform.Translate(x, y, 0);
    }
}
