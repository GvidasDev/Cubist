using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
        DestroyEnemy();
    }
    void DestroyEnemy() {
        if(transform.position.z < -10){
            Destroy(gameObject);
        }
    }
}
