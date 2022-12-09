using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantKnife : MonoBehaviour 
{
    private Vector3 knifeDir;
    float kspeed = 15f;
    public void SetUp(Vector3 knifeDir)
    {
        this.knifeDir = knifeDir;
    }

    private void Update()
    {
        transform.position += knifeDir * Time.deltaTime * kspeed;
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
       
       
    
       



    
    

