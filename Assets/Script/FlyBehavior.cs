using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class FlyBehavior : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private float _rotationSpeed;
    private Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            rigi.velocity = Vector2.up * _velocity;
        }
    }
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rigi.velocity.y * _rotationSpeed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
}
