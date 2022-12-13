using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroOrb : MonoBehaviour
{
    private Vector3 orbDir;
    float orbspeed = 15f;
    public void SetUp(Vector3 knifeDir)
    {
        this.orbDir = knifeDir;
    }

    private void Update()
    {
        transform.position += orbDir * Time.deltaTime * orbspeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {


            if (player.ONdamage())
            {
                Destroy(gameObject);
            }
        }


    }
}
