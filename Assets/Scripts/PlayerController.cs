using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float maxVelocity;
    [SerializeField] public float rotationSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] bool playerSit;
    [SerializeField] bool isOnGround;
    [SerializeField] bool lowRoof;
    [SerializeField] Rigidbody PlayerRb;
    [SerializeField] private GameObject PlayerHead;
    [SerializeField] private GameObject SitPlayer;
    [SerializeField] private GameObject StayPlayer;
    [SerializeField] Camera StayCamera;
    private InputSystem PlayerInputSystem;
    private float playerHeight;
    public Vector2 mouseDelta;
    float m_CameraVerticalAngle = 0f;
    
     
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
        playerHeight = StayPlayer.GetComponent<CapsuleCollider>().height;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = PlayerInputSystem.Player.MoveVector2.ReadValue<Vector2>();
        Move(direction);

        GroundCheck();
        RoofCheck();

        //Player rotation
        float mouseX = mouseDelta.x;
        //Camera up/down rotation
        float mouseY = mouseDelta.y;
        // Rotate function
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

        //StayCamera.transform.Rotate(Vector3.left * mouseY * Time.deltaTime);
        //SitCamera.transform.Rotate(Vector3.left * mouseY * Time.deltaTime);

        m_CameraVerticalAngle += -mouseY * Time.deltaTime;

        m_CameraVerticalAngle = Mathf.Clamp(m_CameraVerticalAngle, -89f, 89f);

        StayCamera.transform.localEulerAngles = new Vector3(m_CameraVerticalAngle, 0, 0);

        if (PlayerRb.velocity.magnitude > maxVelocity)
        {
	        PlayerRb.velocity = PlayerRb.velocity.normalized * maxVelocity;
        }
        
    }
    
    void GroundCheck()
    {
	    RaycastHit hit;
	    float distance = 0.1f;
	    

	    if(Physics.Raycast(transform.position, Vector3.down, out hit, distance))
	    {
		        isOnGround = true;
	    }
	    else
	    {
	    	isOnGround = false;
	    }
    }
    void RoofCheck()
    {
	    RaycastHit hit;
	    
	    

	    if(Physics.Raycast(transform.position, Vector3.up, out hit, playerHeight))
	    {
		    lowRoof = true;
	    }
	    else
	    {
	    	lowRoof = false;
	    }
    }
    

    private void Move(Vector2 direction)
    {   
        float scaleMoveSpeed = moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        PlayerRb.AddRelativeForce(moveDirection * scaleMoveSpeed);
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
        if(!lowRoof)
        {
        StayCamera.transform.position = new Vector3(transform.position.x, (transform.position.y + 1.8f), transform.position.z);
        playerSit = false;
        StayPlayer.SetActive(true);
        SitPlayer.SetActive(false);
        }
    }
    private void Sit()
    {
        if(!playerSit)
        {
        StayCamera.transform.position = new Vector3(transform.position.x, (transform.position.y + 0.8f), transform.position.z);
        StayPlayer.SetActive(false);
        SitPlayer.SetActive(true);
        playerSit = false;
        }
    }
    
}
