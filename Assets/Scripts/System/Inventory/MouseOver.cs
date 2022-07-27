using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public bool itemEquiped;
    public GameObject DetailUI;
    // Start is called before the first frame update
    void Start()
    {
        itemEquiped = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemEquiped)
        {
            DetailUI.SetActive(true);
            DetailUI.transform.parent.transform.parent.GetComponent<RectTransform>().SetAsLastSibling();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DetailUI.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

}
