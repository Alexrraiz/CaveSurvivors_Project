using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera2 : MonoBehaviour
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
            if (player2 == null)
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

            if (player1 == null)
            {
                return;
            }
            var targetPosition = new Vector3(player2.position.x, player2.position.y, -20);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
        }
    }
}
