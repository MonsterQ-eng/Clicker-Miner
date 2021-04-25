using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject shop;
    public GameObject lab;




    public void OpenShop()
    {
        shop.SetActive(true);
        shop.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(shop, new Vector3(1, 1, 1), 0.6f).setEaseOutBack();
    }

    public void CloseShop()
    {
        LeanTween.scale(shop, new Vector3(0, 0, 0), 0.3f).setOnComplete(() => shop.SetActive(false));
    }

    public void OpenLab()
    {
        lab.SetActive(true);
        lab.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(lab, new Vector3(1, 1, 1), 0.6f).setEaseOutBack();
    }

    public void CloseLab()
    {
        LeanTween.scale(lab, new Vector3(0, 0, 0), 0.3f).setOnComplete(() => lab.SetActive(false));
    }


}
