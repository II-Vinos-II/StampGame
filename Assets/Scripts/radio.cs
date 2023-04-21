using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : MonoBehaviour
{
    public Movements playerController;

    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<BoxCollider> bC = new List<BoxCollider>();
    public List<GameObject> radioObj = new List<GameObject>();
    public Score score;

    public GameObject fin;

    public bool isDestroyed = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerController.Taper();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            StartCoroutine(Finish());
        }

    }
    public void DestroyRadio()
    {

        float vitesseDestruction = Random.Range(1000, 2500);
        float angleDestruction = Random.Range(0f, 45f);
        Quaternion angleDeTir = Quaternion.Euler(angleDestruction, angleDestruction, angleDestruction);
        float super = angleDeTir.x;
        //rb.transform = new Vector3(transform.position.x * angleDestruction, transform.position.y, transform.position.z * angleDestruction;
        for (int i = 0; i < rb.Count; i++)
        {
            rb[i].AddForce(transform.right * vitesseDestruction * super);
            rb[i].useGravity = true;
        }
        for (int i = 0; i < bC.Count; i++)
        {
            bC[i].isTrigger = false;
        }

    }

    public IEnumerator Finish()
    {
        Time.timeScale = .25f;
        DestroyRadio();
        yield return new WaitForSeconds(.25f);
        playerController.canMove = false;
        yield return new WaitForSeconds(1);
        fin.SetActive(true);
    }
}
