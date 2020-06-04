using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// author@htz
/// </summary>


public class LD_Controller : MonoBehaviour
{

    public static LD_Controller Instance;

    public LD_LayoutData MainData;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
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
