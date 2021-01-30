
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] Transform targetObj;
    

    private void Awake() 
    {
     mainCamera = GetComponent<Camera>();   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit hit;
        // Vector3 target = (position + mainCamera.transform.forward) * range;
        // Vector3 target = mainCamera.ScreenToViewportPoint(new Vector3(0.5f, 0.5f, 5f));
        //Ray ray = mainCamera.ScreenToViewportPoint(mainCamera.transform.forward);
        Vector3 fromPosition = mainCamera.transform.position;
        Vector3 toPosition = targetObj.transform.position;
        Vector3 direction = toPosition - fromPosition;
        

        Debug.DrawRay(mainCamera.transform.position, direction, Color.red);
        if (Physics.Raycast(mainCamera.transform.position, direction, out hit))
            return hit.collider.gameObject;
        
    return null;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(GetMouseHoverObject(5));

    }
    
}