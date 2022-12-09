using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public float speed = 5f;

    private void Update()
    {
        if (player == null)
        {
            return;
        }
        var targetPosition = new Vector3(player.position.x, player.position.y, -20);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);

        /*if (player != null)
        {
           


            float playerX = player.transform.position.x;
            float playerY = player.transform.position.y;
            float cameraZ = transform.position.z;

            transform.position = new Vector3(playerX, playerY, cameraZ);
        }*/
}

    /*[SerializeField] public Transform player;

    public float smoothSpeed = 0.125f;

    [SerializeField] public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 wantedPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, wantedPosition, smoothSpeed);
        transform.position = smoothPosition;
    }*/ 
}

