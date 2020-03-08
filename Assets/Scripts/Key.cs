using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Pickupable
{
    
}

public class Item : MonoBehaviour
{
    public bool isCollected;
    public bool canFollow = true;
    public bool canBounce = true;
}

public class Key : Item
{
    public float bounceForce;
    private Rigidbody2D _rigidbody2D;
    private SpringJoint2D _springJoint2D;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _springJoint2D = GetComponent<SpringJoint2D>();
        _springJoint2D.enabled = false;
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Ground")) return;
            _rigidbody2D.AddForce(Vector2.up * bounceForce);
        }
        else
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            _springJoint2D.enabled = true;
            isCollected = true;
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            
            var connectedBody = GameObject.FindWithTag("Backpack").GetComponent<Rigidbody2D>();
            _springJoint2D.connectedBody = connectedBody;
        }
    }
}
