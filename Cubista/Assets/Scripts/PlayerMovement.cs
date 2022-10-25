using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int points;

    bool isDead = false;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        scoreText.text = points.ToString();
        AliveSettings(true, true, false);
    }

    // Update is called once per frame
    void Update()
    {
        Keys();
        if(!isDead){
            MovePlayer();
        }
    }

    void MovePlayer(){
        Vector3 pos = transform.position;
        float xValue = Input.GetAxis("Horizontal");
        transform.Translate(xValue * Time.deltaTime * moveSpeed, 0, 0);
        pos.x = Mathf.Clamp(transform.position.x, -2.2f, 2.2f);
        transform.position = pos;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log($"{other.gameObject.name}");
            AliveSettings(false, false, true);
            Invoke("ReloadScene", 1f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Coin"){
            Destroy(other.gameObject);
            points++;
            scoreText.text = points.ToString();
        }
    }

    void AliveSettings(bool a, bool b, bool c){
        GetComponent<MeshRenderer>().enabled = a;
        GetComponent<Collider>().enabled = b;
        isDead = c;
    }

    void Keys(){
        if(Input.GetKeyDown(KeyCode.R)){
            ReloadScene();
        }
    }
    void ReloadScene(){
            string currentScene = SceneManager.GetActiveScene().name; 
            SceneManager.LoadScene(currentScene);
    }
}
