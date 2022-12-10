using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public Transform player1;
    [SerializeField] public Transform player2;
    [SerializeField] public GameObject player_1;
    [SerializeField] public GameObject player_2;
    [SerializeField] public float speed = 5f;


    private void Update()
    {
        if (TitleManager.saveData.player_num == 0)
        {
            player_1.SetActive(true);
            player_2.SetActive(false);

            if (player1 == null)
            {
                return;
            }
            var targetPosition = new Vector3(player1.position.x, player1.position.y, -20);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
        }
        else
        {
            player_2.SetActive(true);
            player_1.SetActive(false);

            if (player2 == null)
            {
                return;
            }
            var targetPosition = new Vector3(player2.position.x, player2.position.y, -20);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
        }

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

