using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{
    private Vector3 arrow;
    float kspeed = 15f;
    public void SetUp(Vector3 arrowDir)
    {
        this.arrow = arrowDir;
    }

    private void Update()
    {
        transform.position += arrow * Time.deltaTime * kspeed;
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
