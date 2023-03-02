using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Porte : MonoBehaviour
{
    public Score score;
    public Movements playerController;
    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<BoxCollider> bC = new List<BoxCollider>();
    public List<GameObject> portesObj = new List<GameObject>();
    float _thrust = 200;
    bool isDestroyed = false;

    public bool entered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            playerController.Taper();
        }

    }

    public void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Mouse0)))
        {

            //StartCoroutine(DestroyVerif());
            float vitesseDestruction = Random.Range(1000, 1500);
            float angleDestruction = Random.Range(0f, 45f);
            Quaternion angleDeTir = Quaternion.Euler(angleDestruction, angleDestruction, angleDestruction);
            float super = angleDeTir.x;
            //rb.transform = new Vector3(transform.position.x * angleDestruction, transform.position.y, transform.position.z * angleDestruction;
            for (int i = 0; i <  rb.Count; i++)
            {
                print("rb add froced");
                rb[i].AddForce(transform.right * vitesseDestruction * super);
                rb[i].useGravity = true;
            }
            for (int i = 0; i < bC.Count; i++)
            {
                print("bc super");
                bC[i].isTrigger = false;
            }
            for(int i = 0; i < portesObj.Count; i++)
            {
                print("destroyed");
                Destroy(portesObj[i], 3f);
            }

            score.ScoreSystem();
        }
        
    }

    public IEnumerator DestroyVerif()
    {
        playerController.hitted = true;
        yield return new WaitForSeconds(.1f);
        playerController.hitted = true;
    }
    
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            entered = false;
            playerController.hitted = false;
        }
    }
}
