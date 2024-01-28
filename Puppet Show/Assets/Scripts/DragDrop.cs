using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 initialPosition;

    private GameObject puppetItemObject;
    private PuppetComponents itemDragged;


    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        initialPosition = new Vector2(rectTransform.position.x, rectTransform.position.y);
    }
    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        puppetItemObject = gameObject;
        itemDragged = gameObject.GetComponent<PuppetComponents>();
     
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("click down");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (!(eventData.pointerEnter != null && eventData.pointerEnter.tag == "Slot"))
        {
            rectTransform.position = initialPosition;
        }
        else
        {
            Inventory.Instance.AddPuppetComponent(GameObject.Instantiate(itemDragged));
        }
        
        Debug.Log("drag end");

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
}
