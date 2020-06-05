using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class LD_StaticPoint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData e)
    {
        Debug.Log("asd");
        isSelected = true;
    }

    public void OnPointerUp(PointerEventData e)
    {
        isSelected = false;
    }

}
