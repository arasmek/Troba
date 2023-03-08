using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    private Vector2 lastDirection;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.Direction.magnitude != 0)lastDirection = controller.Direction;
    }
    public void Initialize()
    {
        controller.DashKey.SetPressedAction(Dash);
    }

    void FixedUpdate()
    {
        rb.AddForce(controller.Direction * speed, ForceMode2D.Force);
        float DirectionDeg = Mathf.Atan2(controller.MousePos.y - transform.position.y,
                                         controller.MousePos.x - transform.position.x) * Mathf.Rad2Deg;
        rb.MoveRotation(DirectionDeg);
    }

    private void Dash()
    {
        rb.AddForce(lastDirection * dashSpeed, ForceMode2D.Impulse);
    }
}
