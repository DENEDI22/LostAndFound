
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    private Camera mainCamera;

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
        Vector3 target = position + mainCamera.transform.forward * range;
        if (Physics.Raycast(transform.position ,target, out hit))
            return hit.collider.gameObject;
        
    return null;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetMouseHoverObject(5));
    }
    
}