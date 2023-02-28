using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movements : MonoBehaviour
{
    [SerializeField] private AnimationCurve easingCurve;

    [SerializeField] int positionLane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();
    }



    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button5) && positionLane <= -2.5f)
        {
            transform.DOMoveX(0f, 1f);
            positionLane = 0;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5) && positionLane <= 2.5f)
        {
            transform.DOMoveX(5f, 1f);
            positionLane = 5;
        }


        if (Input.GetKeyDown(KeyCode.Joystick1Button4) && positionLane >= 2.5f)
        {
            transform.DOMoveX(0f, 1f);
            positionLane = 0;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button4) && positionLane >= -2.5f)
        {
            transform.DOMoveX(-5f, 1f);
            positionLane = -5;
        }

        
        if (positionLane == 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (positionLane == 5)
        {
            transform.position = new Vector3(5, transform.position.y, transform.position.z);
        }
        if (positionLane == -5)
        {
            transform.position = new Vector3(-5, transform.position.y, transform.position.z);
        }

    }
}
