﻿using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public Color color;

    [SyncVar]
    public int score;

    float moveSpeed = 1.875f;
    public GameObject bulletPrefab;
    private Text scoreText;

    public override void OnStartClient()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        if (isLocalPlayer && hasAuthority)
        {
            GetInput();
            scoreText.text = "Score: " + score;
        }
    }


    void GetInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        if (isServer)
        {
            RpcMoveIt(x, y);
        }
        else
        {
            CmdMoveIt(x, y);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            CmdDoFire();
        }

    }

    [ClientRpc]
    void RpcMoveIt(float x, float y)
    {
        transform.Translate(x, y, 0);
    }

    [Command]
    public void CmdMoveIt(float x, float y)
    {
        RpcMoveIt(x, y);
    }

    [Command]
    public void CmdDoFire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position + this.transform.right, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * 17.5f;
        bullet.GetComponent<Bullet>().color = color;
        bullet.GetComponent<Bullet>().parentNetId = this.netId;
        Destroy(bullet, 0.875f);
        NetworkServer.Spawn(bullet);
    }

    private void Start()
    {
        PlayerHealth playerHealth = new PlayerHealth(100);
        Debug.Log("Health: " + playerHealth.GetHealth());
    }
}
