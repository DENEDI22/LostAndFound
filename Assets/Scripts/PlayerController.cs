using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject StayPlayerBody;
    [SerializeField] public GameObject SitPlayerBody;

    private PlayerInput PlayerInputSystem;

    private void Awake() 
    {
        PlayerInputSystem = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
