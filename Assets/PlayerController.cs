using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    Animator animator;
    Vector2 movementInput;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;


    List<RaycastHit2D> castCollisions = new List<RaycastHit2D> ();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {
                TryMove(new Vector2(movementInput.x, 0));
            }
            if (!success)
            {
                success = TryMove(new Vector2(0, movementInput.y));
            }

            if (movementInput.y > 0) { animator.SetBool("goUp", success); }
            else if (movementInput.y < 0) { animator.SetBool("goUp", false); }

            if (movementInput.y < 0) { animator.SetBool("goDown", success); }
            else if (movementInput.y < 0)
            {
                animator.SetBool("goDown", false);


                if (movementInput.x < 0) { spriteRenderer.flipX = true; animator.SetBool("goSides", success); }
                else if (movementInput.x > 0) { spriteRenderer.flipX = false; animator.SetBool("goSides", false); }
            }
        }
    }

    private bool TryMove(Vector2 direction){
        if (direction == Vector2.zero){
            int count = rb.Cast(
                   movementInput,
                   movementFilter,
                   castCollisions,
                   moveSpeed * Time.deltaTime + collisionOffset);
            if (count == 0){ 
              rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime); return true; }
            else { return false; }
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {movementInput = movementValue.Get<Vector2>();}
}
