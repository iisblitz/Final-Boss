using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D> ();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {
            int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.deltaTime + collisionOffset);
            if (count == 0)
            {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
        }
    }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();

    }

}
