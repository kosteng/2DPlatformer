using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler, IPointerClickHandler, IPointerDownHandler
{
    [SerializeField] private UnityAction onSome;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Click");
        onSome.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onSome.Invoke();
        Debug.Log("Enter");
    }

    private void OnMouseOver()
    {
  //      Debug.Log("Over");
    }

    private void OnMouseDrag()
    {
  //      Debug.Log("Drag");
    }

    private void OnMouseEnter()
    {
        onSome.Invoke();
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onSome.Invoke();
        Debug.Log("Exit");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onSome.Invoke();
        Debug.Log("Click");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onSome.Invoke();
        Debug.Log("Down");
    }
}
