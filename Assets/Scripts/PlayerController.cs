using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float rotationSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] bool playerSit;
    [SerializeField] bool isOnGround;
    [SerializeField] Rigidbody PlayerRb;
    [SerializeField] private GameObject SitPlayer;
    [SerializeField] private GameObject StayPlayer;
    private InputSystem PlayerInputSystem;
    public Vector2 mouseDelta;
     
    private void Awake() 
    {
        PlayerInputSystem = new InputSystem(); 
        PlayerInputSystem.Player.Jump.performed += context => Jump();
        PlayerInputSystem.Player.Sit.started += context => Sit();
        PlayerInputSystem.Player.Sit.canceled += context => Stay();
        PlayerInputSystem.Player.MouseAxis.performed += context => mouseDelta = context.ReadValue<Vector2>();

        
        
        
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

        float mouseX = mouseDelta.x;
        // Rotate function
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }    
    }
    private void Move(Vector2 direction)
    {   
        float scaleMoveSpeed = moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        PlayerRb.velocity += moveDirection * scaleMoveSpeed;
    }
    private void Jump()
    {
        if (isOnGround)
        {
        PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        }
    }
    private void Stay()
    {
        playerSit = false;
        StayPlayer.SetActive(true);
        SitPlayer.SetActive(false);
    }
    private void Sit()
    {
        if(!playerSit)
        {
        StayPlayer.SetActive(false);
        SitPlayer.SetActive(true);
        playerSit = false;
        }
    }
    
}
