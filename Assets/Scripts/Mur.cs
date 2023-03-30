using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.VFX;

public class Mur : MonoBehaviour
{
    public Baril barilController;

    public VisualEffect explosion;

    public MeshRenderer murClean;
    public BoxCollider murCleanCollider;
    public GameObject murFracturé;
    public AudioSource explosionSound;

    public List<MeshRenderer> portesCleanRenderers = new List<MeshRenderer>(); 
    public List<GameObject> portesCleanObj = new List<GameObject>();
    public List<GameObject> portesFracturéesObj = new List<GameObject>();

    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<BoxCollider> bC = new List<BoxCollider>();
    public List<GameObject> mursObj = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        murClean.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Baril")
        {

            explosionSound.Play();
            explosion.Play();

            print("baril détécté");
            murClean.enabled = false;
            murFracturé.SetActive(true);

            for (int i = 0; i < portesCleanRenderers.Count; i++)
            {
                portesCleanRenderers[i].enabled = false;
            }
            for (int i = 0; i < portesFracturéesObj.Count; i++)
            {
                portesFracturéesObj[i].SetActive(true);
            }
            for(int i = 0; i < portesCleanObj.Count; i++)
            {
                if(portesCleanObj[i].tag == "Porte Condamnée")
                {
                    portesCleanObj[i].tag = "Untagged";
                }
            }

            //StartCoroutine(DestroyVerif());
            float vitesseDestruction = Random.Range(2000, 2500);
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
            for (int i = 0; i < mursObj.Count; i++)
            {
                Destroy(mursObj[i], 3f);
            }
            //if (!giveScore)
            //{
            //    porteCrashSound.Play();
            //    score.ScoreSystem();
            //    giveScore = true;
            //}
        }
    }
}
