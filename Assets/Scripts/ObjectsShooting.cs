using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsShooting : MonoBehaviour
{
    public LifeManager lifeManager;

    private bool giveScore;
    public Score score;
    public Movements playerController;
    bool objHit = false;
    bool dontHitObj;

    public MeshRenderer objectClean;
    public GameObject objectFracturé;

    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<BoxCollider> bC = new List<BoxCollider>();
    public List<GameObject> objectsObj = new List<GameObject>();

    float _thrust = 200;
    bool isDestroyed = false;

    //public AudioSource objectCrashSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Mouse0)) && playerController.canMove)
        {
            if (playerController.canMove)
            {
                playerController.Taper();
            }
        }


        if (objHit)
        {
            DetruireObjectWhenHitted();
            objHit = false;
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if ((Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Mouse0)) && playerController.canMove && !objHit)
            {
                DetruireObject();
                dontHitObj = true;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !dontHitObj)
        {
            objHit = true;
        }
    }

    

    public void DetruireObjectWhenHitted()
    {
        if (playerController.canMove)
        {
            StartCoroutine(WaitToRestoreFromDegats());
            playerController.DegatEffects.SetTrigger("oof");
            lifeManager.LifeCounter();
            float vitesseDestruction = Random.Range(1000, 1500);
            float angleDestruction = Random.Range(0f, 45f);
            Quaternion angleDeTir = Quaternion.Euler(angleDestruction, angleDestruction, angleDestruction);
            float super = angleDeTir.x;
            //rb.transform = new Vector3(transform.position.x * angleDestruction, transform.position.y, transform.position.z * angleDestruction;
            for (int i = 0; i < rb.Count; i++)
            {
                rb[i].AddForce(playerController.transform.forward * vitesseDestruction * super);
                rb[i].useGravity = true;
            }
            for (int i = 0; i < bC.Count; i++)
            {
                bC[i].isTrigger = false;
            }
            for (int i = 0; i < objectsObj.Count; i++)
            {
                Destroy(objectsObj[i], 3f);
            }
        }
    }

    public void DetruireObject()
    {
        if (playerController.canMove)
        {
            objectClean.enabled = false;
            objectFracturé.SetActive(true);
            //StartCoroutine(DestroyVerif());
            float vitesseDestruction = Random.Range(1000, 1500);
            float angleDestruction = Random.Range(0f, 45f);
            Quaternion angleDeTir = Quaternion.Euler(angleDestruction, angleDestruction, angleDestruction);
            float super = angleDeTir.x;
            //rb.transform = new Vector3(transform.position.x * angleDestruction, transform.position.y, transform.position.z * angleDestruction;
            for (int i = 0; i < rb.Count; i++)
            {
                rb[i].AddForce(playerController.transform.forward * vitesseDestruction * super);
                rb[i].useGravity = true;
            }
            for (int i = 0; i < bC.Count; i++)
            {
                bC[i].isTrigger = false;
            }
            for (int i = 0; i < objectsObj.Count; i++)
            {
                Destroy(objectsObj[i], 3f);
            }
            if (!giveScore)
            {
                //objectCrashSound.Play();
                score.ScoreSystem();
                giveScore = true;
            }
        }
    }

    public IEnumerator DestroyVerif()
    {
        playerController.hitted = true;
        yield return new WaitForSeconds(.1f);
        playerController.hitted = true;
    }


    public IEnumerator WaitToRestoreFromDegats()
    {
        playerController.oof.Play();
        playerController.speed = 0;
        yield return new WaitForSeconds(2.5f);
        playerController.canMove = true;
        playerController.speed = 3;
        yield return new WaitForSeconds(.5f);
        playerController.speed = 6;
        yield return new WaitForSeconds(.5f);
        playerController.speed = 9;
        yield return new WaitForSeconds(.5f);
        playerController.speed = 11;
        yield return new WaitForSeconds(.5f);
        playerController.speed = 15;

    }
}
