using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int points;
    public int Points {get{return points;}}
    [SerializeField] Text scoreText;

    [SerializeField] GameObject destroyParticles;

    void Start(){
        points = 0;
        scoreText.text = points.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Coin"){
            Destroy(other.gameObject);
            GameObject a = Instantiate(destroyParticles, other.gameObject.transform.position, Quaternion.identity);
            Destroy(a, 0.5f);
            points++;
            scoreText.text = points.ToString();
        }
    }
}
