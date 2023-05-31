using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float startSpeed = 10f;
    [SerializeField] float maxSpeed = 25f;
    [SerializeField] float moveSpeed;

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
        
        SpeedControl(3);

        Debug.Log("Move speed " + moveSpeed);
    }

    void Move(){
        if(playerMover.IsDead){
            SetSpeed(0);
        }

        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
    }
    void DestroyEnemy() {
        if(transform.position.z < -10){
            Destroy(gameObject);
        }
    }

    void SetSpeed(float speed){
        if(speed <= maxSpeed){
            moveSpeed = speed;
        }
    }

    void SpeedControl(float speedIncrease){
        //TODO: didinti greiti pagal laika arba rezultata
    }
}
