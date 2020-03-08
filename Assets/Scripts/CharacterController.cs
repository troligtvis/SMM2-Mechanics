using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    public float speed = 10f;
    private Vector3 _velocity = Vector2.zero;

    private const float MovementSmoothing = 0.2f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        ListenForInput();
    }

    public void Move(float direction)
    {
        var velocity = _rigidbody2D.velocity;
        var targetVelocity = new Vector2(direction * speed, velocity.y);
        _rigidbody2D.velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref _velocity, MovementSmoothing);
        
        // Update sprite to look in the moving direction
        if (direction > 0)
        {
            UpdateFacingDirection(false);   
        } 
        else if (direction < 0)
        {
            UpdateFacingDirection(true);
        }
    }

    private void UpdateFacingDirection(bool isFacingLeft)
    {
        var localScale = transform.localScale;
        localScale.x = isFacingLeft ? -1f : 1f;
        transform.localScale = localScale;
        
        
    }

    private void ListenForInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            EventManager.RaiseOnUpKeyPressed();
        }
    }
}
