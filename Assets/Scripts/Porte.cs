using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Porte : MonoBehaviour
{
    public Movements movements;
    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<BoxCollider> bC = new List<BoxCollider>();
    float _thrust = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Joystick1Button0))
        {
            movements.Taper();

            print("ca marche ?");
            float vitesseDestruction = Random.Range(1000, 2000);
            float angleDestruction = Random.Range(0f, 45f);
            Quaternion angleDeTir = Quaternion.Euler(angleDestruction, angleDestruction, angleDestruction);
            float super = angleDeTir.x;
            //rb.transform = new Vector3(transform.position.x * angleDestruction, transform.position.y, transform.position.z * angleDestruction;
            for (int i = 0; i <  rb.Count; i++)
            {
                rb[i].AddForce(transform.right * vitesseDestruction * super);
                rb[i].useGravity = true;
            }
            for (int i = 0; i < bC.Count; i++)
            {
                bC[i].isTrigger = false;
            }

        }
        
    }
}
