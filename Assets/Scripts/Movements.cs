using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class Movements : MonoBehaviour
{
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
       

        transform.Translate(transform.forward * 10 * Time.deltaTime);

        // Read player input
        // Horizontal axis to the left
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            MoveLeft();
        }
        // Horizontal axis to the right
        else if (Input.GetKeyDown(KeyCode.Joystick1Button4))

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
                position.x = leftLaneX;
                break;
            case 1:
                position.x = middleLaneX;
                break;
            case 2:
                position.x = rightLaneX;
                break;
            default: return;
        }
        transform.position = position;
    }
}
