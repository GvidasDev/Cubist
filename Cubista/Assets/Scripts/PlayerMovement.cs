using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] LayerMask wallMask;

    [SerializeField] GameObject explosionParticle;

    bool isDead;
    public bool IsDead {get{return isDead;}}

    Vector3 startPosition = new Vector3(0, 0.8f, -5);

    // Start is called before the first frame update
    void Start()
    {
        LifeSettings(true, true, false);
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Keys();
        if(!isDead){
            MovePlayer();
        }

        DetectWalls();
    }

    void DetectWalls(){
        Vector3 size = new Vector3(0.3f, 0.3f, 0.3f);
        Vector3 directionToCheck = new Vector3(0, 0, transform.localScale.z);
        if (Physics.BoxCast(transform.position, size, directionToCheck, transform.rotation, 0.1f, wallMask))
        {
            if(!isDead)
                Kill();
            Invoke("ReloadScene", 1f);
        }
    } 

    void MovePlayer(){
        Vector3 pos = transform.position;
        float xValue = Input.GetAxis("Horizontal");
        transform.Translate(xValue * Time.deltaTime * moveSpeed, 0, 0);
        pos.x = Mathf.Clamp(transform.position.x, -2.2f, 2.2f);
        transform.position = pos;
    }

    void Kill(){
        LifeSettings(false, false, true);
        Instantiate(explosionParticle, gameObject.transform.position, Quaternion.identity);
    }

    void LifeSettings(bool a, bool b, bool c){
        isDead = c;
        GetComponentInChildren<MeshRenderer>().enabled = a;
        GetComponentInChildren<Collider>().enabled = b;
    }

    void Keys(){
        if(Input.GetKeyDown(KeyCode.R)){
            ReloadScene();
        }
        else if(Input.GetKeyDown(KeyCode.Equals)){
           Application.Quit();
        }
    }
    void ReloadScene(){
        string currentScene = SceneManager.GetActiveScene().name; 
        SceneManager.LoadScene(currentScene);

    }
}
