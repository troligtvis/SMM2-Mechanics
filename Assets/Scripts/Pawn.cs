using System;
using System.Collections;
using System.Collections.Generic;
using Door_System;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public CharacterController controller;
    private float x = 0f;

    private Animator _animator;
    
    private void Awake()
    {
        if (controller == null)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }

        DoorManager.onBeginUpdatePawnPosition += UpdatePosition;

        _animator = GetComponent<Animator>();
    }

    public void UpdatePosition(Vector2 position)
    {
        gameObject.transform.position = position;
    }

    private void InputListener()
    { 
        x = Input.GetAxis("Horizontal");
    }

    private void Update()
    {
        InputListener();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        controller.Move(x);
    }

    private void UpdateAnimation()
    {
        _animator.SetFloat("Speed", Mathf.Abs(x));
    }
}
