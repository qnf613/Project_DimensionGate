using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePOPUPS : MonoBehaviour
{
    private Vector3 OffSet;

    [SerializeField] private TextMeshPro DamageIndicator;
    [SerializeField] private GameObject pfDamagePopup;
    [SerializeField] private Transform TempPosition;
    [SerializeField] private float originalFontSize = 36;

    // Start is called before the first frame update
    void Start()
    {
        OffSet = this.gameObject.transform.position;
        OffSet.y += 1;
    }
    public void DamagePopUp(float dmg, bool crit)
    {
        float randomAngle;
        float randomOffset;
        randomOffset = UnityEngine.Random.Range(-1f, 1.5f);
        Vector3 TempOffset = new Vector3(OffSet.x + randomOffset, OffSet.y, 0);
        SetFont(dmg, crit);
        ShowDamageUI(dmg);
        Instantiate(pfDamagePopup, TempOffset, Quaternion.identity);
        
    }
    void SetFont(float dmg, bool crit)
    {
        DamageIndicator.fontSize += dmg * .2f;
        if (DamageIndicator.fontSize > 100)
        {
            DamageIndicator.fontSize = 100;
        }
        if (crit == true)
        {
            DamageIndicator.color = Color.red;
        }
        DamageIndicator.color = Color.white;

    }
    void ResetFontSize()
    {
        DamageIndicator.fontSize = originalFontSize;
    }
    private void ShowDamageUI(float dmg)
    {
        DamageIndicator.text = dmg.ToString();
        Invoke("ClearDamageUI", .5f);
        ResetFontSize();

    }
    private void ClearDamageUI()
    {
        DamageIndicator.text = "";
    }
}
