using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyStackBalancer : MonoBehaviour
{
    [Header("Inspector Atrib.")]
    [SerializeField] private Transform pivot;

    [Header("Variaveis Locais.")]
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float rotateTarget = -35f; // Limite da rotação nos eixos X e Z
    [SerializeField] private float targetRotationX = 0;

    InputAction movementInput;

    void OnEnable() {
        PlayerInput playerInput = new PlayerInput();
        movementInput = playerInput.Gameplay.Movement;
        movementInput.Enable();
    }

    private void FixedUpdate()
    {
       SwingStack();
    }

    private void SwingStack(){

        //Vector2 playerMovementInput = ; 
        targetRotationX = Mathf.Abs(movementInput.ReadValue<Vector2>().magnitude) * rotateTarget; // caso o jogador esteja andando na Horizontal
        //targetRotationX = Mathf.Abs(playerMovementInput.y) * rotateTarget; // caso o jogador esteja andando na "Vertical"    

        Quaternion targetQuaternionX = Quaternion.Euler(targetRotationX, 0, 0);
        pivot.localRotation = Quaternion.Lerp(pivot.localRotation, targetQuaternionX, rotationSpeed * Time.fixedDeltaTime);
    }

    void OnDisable()
    {
        movementInput.Disable();
    }
}
