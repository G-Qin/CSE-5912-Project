using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    Image yiChen;
    [SerializeField]
    Image aoranWang;
    [SerializeField]
    Image zinaZhang;
    [SerializeField]
    Image liangcanLi;
    [SerializeField]
    Image gengyiQin;
    [SerializeField]
    Image patrickCheng;
    [SerializeField]
    Image jiashuZhang;
    [SerializeField]
    Image teamBadge;
    [SerializeField]
    TextMeshProUGUI teamText;
    [SerializeField]
    AudioSource audioManager;

    // Start is called before the first frame update
    void Start()
    {
        yiChen.enabled = false;
        aoranWang.enabled = false;
        zinaZhang.enabled = false;
        liangcanLi.enabled = false;
        gengyiQin.enabled = false;
        patrickCheng.enabled = false;
        jiashuZhang.enabled = false;
        teamBadge.enabled = false;
        teamText.enabled = false;
        StartCoroutine(LoadText());
    }

    IEnumerator LoadText(){
        teamText.color = new Color(teamText.color.r, teamText.color.g, teamText.color.b, 0);
        teamText.enabled = true;
        while (teamText.color.a < 1f){
            teamText.color = new Color(teamText.color.r, teamText.color.g, teamText.color.b, 
                teamText.color.a + Time.deltaTime);
            yield return null;
        }
        yield return StartCoroutine(LoadImages());
    }

    IEnumerator LoadImages(){
        yield return new WaitForSeconds(1f);

        patrickCheng.enabled = true;
        audioManager.Play();
        yield return new WaitForSeconds(0.5f);

        jiashuZhang.enabled = true;
        liangcanLi.enabled = true;
        audioManager.Play();
        yield return new WaitForSeconds(0.5f);

        zinaZhang.enabled = true;
        gengyiQin.enabled = true;
        audioManager.Play();
        yield return new WaitForSeconds(0.5f);

        yiChen.enabled = true;
        aoranWang.enabled = true;
        audioManager.Play();
        yield return new WaitForSeconds(0.5f);

        teamBadge.enabled = true;
        audioManager.Play();
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu(){
        Debug.Log("Loading the menu");
        SceneManager.LoadScene("Menu_Scene");
        yield return null;
    }
}
