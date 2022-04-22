using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCrosshairScript : MonoBehaviour
{
    [SerializeField] GameObject topRight;
    [SerializeField] GameObject topLeft;
    [SerializeField] GameObject botRight;
    [SerializeField] GameObject botLeft;

    // Start is called before the first frame update
    void Start()
    {
        topRight.SetActive(false);
        topLeft.SetActive(false);
        botLeft.SetActive(false);
        botRight.SetActive(false);
    }

    public void EnableHitCrosshair(){
        StopCoroutine(CrosshairFadeOut());
        topRight.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        topLeft.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        botRight.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        botLeft.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        topRight.SetActive(true);
        topLeft.SetActive(true);
        botLeft.SetActive(true);
        botRight.SetActive(true);
    }

    public void DisableHitCrosshair(){
        StartCoroutine(CrosshairFadeOut());
    }

    IEnumerator CrosshairFadeOut(){
        for (float i = 1; i >= 0; i -= Time.deltaTime * 3){
            
            topRight.GetComponent<Image>().color = new Color(1, 1, 1, i);
            topLeft.GetComponent<Image>().color = new Color(1, 1, 1, i);
            botRight.GetComponent<Image>().color = new Color(1, 1, 1, i);
            botLeft.GetComponent<Image>().color = new Color(1, 1, 1, i);
            yield return null;
        }
        topRight.SetActive(false);
        topLeft.SetActive(false);
        botLeft.SetActive(false);
        botRight.SetActive(false);
        yield return null;
    }
}
