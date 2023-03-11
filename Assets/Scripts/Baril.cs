using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Baril : MonoBehaviour
{
    public Movements playerController;
    private bool ExloseWall;
    public Rigidbody rb;
    public BoxCollider bC;
    public GameObject BarilsObj;
    public Score score;
    public AudioSource barilHit;

    private void Update()
    {

        if ((Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            playerController.Taper();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PushBaril();
        }

    }
    public void PushBaril()
    {

        barilHit.Play();
        //StartCoroutine(DestroyVerif());
        float vitesseDestruction = Random.Range(2000, 2500);
        float angleDestruction = Random.Range(0f, 45f);
        Quaternion angleDeTir = Quaternion.Euler(angleDestruction, angleDestruction, angleDestruction);
        float super = angleDeTir.x;
        //rb.transform = new Vector3(transform.position.x * angleDestruction, transform.position.y, transform.position.z * angleDestruction;
        
        
            rb.AddForce(transform.forward * vitesseDestruction);
            rb.useGravity = true;

        Destroy(gameObject, 1f);
        
        if (!ExloseWall)
        {
            score.ScoreSystemBaril();
            ExloseWall = true;
        }
    }
}
