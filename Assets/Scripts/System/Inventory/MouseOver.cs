using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool itemEquiped;
    // Start is called before the first frame update
    public GameObject DetailUI;
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
}
