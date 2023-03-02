using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using XInputDotNetPure;
using DG.Tweening.Core.Easing;

public class Movements : MonoBehaviour
{

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public float speed;
    public Animator anim;
    Rigidbody body;
    public CapsuleCollider bCPlayer;

    // Lanes X positions
    [SerializeField] private float leftLaneX = -5f;
    [SerializeField] private float middleLaneX = 0f;
    [SerializeField] private float rightLaneX = 5f;

    // Start the player in the middle lane
    private int _currentLane = 1; // 0: Left lane, 1: Middle lane, 2: Right lane

    private void Update()
    {
       

        transform.Translate(transform.forward * speed * Time.deltaTime);

        // Read player input
        // Horizontal axis to the left
        if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetAxisRaw("Horizontal") > .25f)
        {
            MoveLeft();
        }
        // Horizontal axis to the right
        else if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetAxisRaw("Horizontal") < -.25f)

        {
            MoveRight();
        }
    }

    /// <summary>
    /// Move the player in the lane on his right
    /// </summary>
    private void MoveRight()
    {
        // Avoid leaving the 3 lanes
        if (_currentLane - 1 < 0) return;
        _currentLane--;
        MoveToLane();
    }

    /// <summary>
    /// Move the player in the lane on his left
    /// </summary>
    private void MoveLeft()
    {
        // Avoid leaving the 3 lanes
        if (_currentLane + 1 > 2) return;
        _currentLane++;
        MoveToLane();
    }

    /// <summary>
    /// Move the player to the current lane
    /// </summary>
    private void MoveToLane()
    {


        var position = transform.position;
        switch (_currentLane)
        {
            case 0:
                transform.DOMoveX(leftLaneX, .2f);
                break;
            case 1:
                transform.DOMoveX(middleLaneX, .2f);
                break;
            case 2:
                transform.DOMoveX(rightLaneX, .2f);
                break;
            default: return;
        }
        transform.position = position;
    }

    public void Taper()
    {
        StartCoroutine(Vibre(.8f));
        anim.SetTrigger("Coup");
    }

    public IEnumerator Vibre(float vibrationPower)
    {
        
        GamePad.SetVibration(playerIndex, vibrationPower, vibrationPower);
        
        yield return new WaitForSeconds(.4f);
        
        GamePad.SetVibration(playerIndex, 0, 0);
        GamePad.SetVibration(playerIndex, 0, 0);
        
    }
}
