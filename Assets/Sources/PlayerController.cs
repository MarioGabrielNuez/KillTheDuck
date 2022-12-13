using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    Vector3 moveInput = Vector3.zero;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        moveInput = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")), 1f);

        moveInput = transform.TransformDirection(moveInput) * (Input.GetMouseButton(2) ? runSpeed : walkSpeed);

        moveInput.x += Time.deltaTime;
        if (Input.GetAxis("Jump") <= 0) {moveInput.y = 0f;}
        characterController.Move(moveInput * Time.deltaTime);
    }
}