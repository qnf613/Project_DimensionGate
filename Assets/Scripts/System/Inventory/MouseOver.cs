using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public GameObject DetailUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        DetailUI.SetActive(true);
        DetailUI.transform.parent.transform.parent.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DetailUI.SetActive(false);
    }
}
