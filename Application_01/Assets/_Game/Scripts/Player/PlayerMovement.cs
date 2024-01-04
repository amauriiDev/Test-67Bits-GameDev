using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    private PlayerInput playerInput;
    private InputAction movementInput;
    [Header("ATRIB. INSPECTOR")]
    [SerializeField]private UserData userData;
    [SerializeField]private PlayerAnimation playerAnimation;
    [SerializeField]private HitEnemy hitEnemy;


    [Header("ATRIB. CLASSE")]
    [SerializeField]private float rotationSpeed = 20f;
    [SerializeField]private float speed;

    void Awake()
    {
        playerInput = new PlayerInput();
    }
    void OnEnable()
    {
        movementInput = playerInput.Gameplay.Movement;
        movementInput.Enable();

        playerInput.Gameplay.Punch.performed+= Attack;
        playerInput.Gameplay.Punch.Enable();
    }
    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        speed = userData.Speed;
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement(){
        
        Vector2 movement = movementInput.ReadValue<Vector2>();
        if (movement.Equals(Vector2.zero)){
            playerAnimation.PlayIdleAnimation(); // animation
            return;
        }
        playerAnimation.PlayRunAnimation(); //animation
        transform.position +=  speed * Time.fixedDeltaTime* new Vector3(movement.x, 0, movement.y);
        
        float angle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    private void Attack(InputAction.CallbackContext context){
        playerAnimation.PlayPunchAnimation(); //animation
        hitEnemy.Attack();
    }

    void OnDisable() {
        movementInput.Disable();

        playerInput.Gameplay.Punch.performed-= Attack;
        playerInput.Gameplay.Punch.Disable();
    }
}
