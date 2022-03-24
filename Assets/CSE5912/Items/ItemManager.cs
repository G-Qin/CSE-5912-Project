using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    [SerializeField] private GameObject ammoBox;
    AmmoBox ammo_script;

    private IA_Player input;
    public GameObject HoldToFill;
    public float startTime = 0f;
    public float endTime = 0f;
    // check if in range of an interactable item
    bool ammoInRange = false;

    private void Awake()
    {
        input = new IA_Player();
        ammo_script = ammoBox.GetComponent<AmmoBox>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        // ammoBox.AddComponent<AmmoBox>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoInRange = ammo_script.inRange;
        if(ammoInRange)
        {
            HoldToFill.SetActive(true);
        }
        else
        {
            HoldToFill.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        { 
            startTime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.E))
        { 
            endTime = Time.time;
            if(endTime-startTime>=2)
            {
                // check if in range of ammo box
                if(ammoInRange)
                ammo_script.interaction();
            }
            //Debug.Log("Interact");
        }        
        
    }
}
