using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] Rigidbody PlayerRb;
    [SerializeField] GameObject SitPlayer;
    [SerializeField] GameObject StayPlayer;
    private InputSystem PlayerInputSystem;    
    private void Awake() 
    {
        PlayerInputSystem = new InputSystem(); 
        PlayerInputSystem.Player.Jump.performed += context => Jump();
        //PlayerInputSystem.Player.Sit.performed += contaxt => Sit();
    }
    private void OnEnable() 
    {
        PlayerInputSystem.Enable();
    }
    private void OnDisable() 
    {
        PlayerInputSystem.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = PlayerInputSystem.Player.MoveVector2.ReadValue<Vector2>();
        Move(direction);
    }
    private void Move(Vector2 direction)
    {   
        float scaleMoveSpeed = moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * scaleMoveSpeed;
    }
    private void Jump()
    {
        PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    private void Stay()
    {
        StayPlayer.SetActive(true);
        SitPlayer.SetActive(false);
    }
    private void Sit()
    {
        StayPlayer.SetActive(false);
        SitPlayer.SetActive(true);
    }
}
