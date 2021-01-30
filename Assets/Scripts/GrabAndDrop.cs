
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabAndDrop : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] Transform targetObj;
    [SerializeField] public float interactionDistance;
    private InputSystem PlayerInputSystem;
    
    private GameObject tapObject;

    private void Awake() 
    {
        PlayerInputSystem = new InputSystem();
        PlayerInputSystem.Player.Click.performed += context => InteractButton();
        mainCamera = GetComponent<Camera>();   
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
        
    }
    
    GameObject GetMouseHoverObject()
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit hit;
        // Vector3 target = (position + mainCamera.transform.forward) * range;
        // Vector3 target = mainCamera.ScreenToViewportPoint(new Vector3(0.5f, 0.5f, 5f));
        //Ray ray = mainCamera.ScreenToViewportPoint(mainCamera.transform.forward);
        Vector3 fromPosition = mainCamera.transform.position;
        Vector3 toPosition = targetObj.transform.position;
        Vector3 direction = toPosition - fromPosition;
        
        //LayerMask interactibleObjects = LayerMask.GetMask("8");
        
        Debug.DrawRay(mainCamera.transform.position, direction, Color.red);
        if (Physics.Raycast(mainCamera.transform.position, direction, out hit, interactionDistance))
            return hit.collider.gameObject;
        
    return null;
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(GetMouseHoverObject());
        tapObject = GetMouseHoverObject();
        Debug.Log(tapObject.name);
    }
    private void InteractButton()
    {
        
        tapObject.SendMessage("ClickedOnObject");
    }
    
}