using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveInput = Vector3.ClampMagnitude(moveInput, 1f);

        if ((Input.GetKey(KeyCode.W) && Input.GetMouseButton(2)) ||
            (Input.GetKey(KeyCode.A) && Input.GetMouseButton(2)) ||
            (Input.GetKey(KeyCode.S) && Input.GetMouseButton(2)) ||
            (Input.GetKey(KeyCode.D) && Input.GetMouseButton(2)))
        {
            moveInput = transform.TransformDirection(moveInput) * runSpeed;
        }
        else
        {
            moveInput = transform.TransformDirection(moveInput) * walkSpeed;
        }

        moveInput.y += -20f * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }
}