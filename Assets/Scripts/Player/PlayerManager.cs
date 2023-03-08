using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    private Vector2 lastDirection;
    [SerializeField] private Weapon weapon;

    private Vector2 lookDirection = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = (controller.MousePos - (Vector2)transform.position).normalized;
        
        if(controller.Direction.magnitude != 0)
        {
            lastDirection = controller.Direction;
        }
        if(controller.LeftMB && weapon.CanShoot)
        {
            weapon.Shoot(lookDirection);
        }
    }
    public void Init()
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
