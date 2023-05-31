using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float startSpeed = 10f;
    [SerializeField] float moveSpeed = 10f;

    PlayerMovement playerMover;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = startSpeed;

        playerMover = FindObjectOfType<PlayerMovement>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyEnemy();
    }

    void Move(){
        if(playerMover.IsDead){
            moveSpeed = 0;
        }

        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
    }
    void DestroyEnemy() {
        if(transform.position.z < -10){
            Destroy(gameObject);
        }
    }
}
