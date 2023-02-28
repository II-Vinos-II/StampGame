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

    private void MovePlayer()
    {
        if (Input.GetAxis("Horizontal") == 1 && positionLane == -5 && positionLane != 5)
        {
            transform.DOMoveX(0f, 1f, true).SetEase(easingCurve);
            positionLane = 0;
        }
        if (Input.GetAxis("Horizontal") == 1 && positionLane == 0 && positionLane != -5 && positionLane != 5)
        {
            transform.DOMoveX(5f, 1f, true).SetEase(easingCurve);
            positionLane = 5;
        }


        if (Input.GetAxis("Horizontal") == -1 && positionLane == 5 && positionLane != -5)
        {
            transform.DOMoveX(0f, 1f, true).SetEase(easingCurve);
            positionLane = 0;
        }
        if (Input.GetAxis("Horizontal") == -1 && positionLane == 0 && positionLane != -5 && positionLane != 5)
        {
            transform.DOMoveX(-5f, 1f, true).SetEase(easingCurve);
            positionLane = -5;
        }


    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
