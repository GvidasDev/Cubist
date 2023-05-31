using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] Text scoreText;

    public int Points {get{return points;}} 
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        scoreText.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(){
        points++;
        scoreText.text = points.ToString();
    }
}
