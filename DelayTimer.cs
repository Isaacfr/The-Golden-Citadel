using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTimer : MonoBehaviour
{
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    public GameObject buttonFight;

    // Start is called before the first frame update
    void Start()
    {
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        buttonFight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PlayText2());
        StartCoroutine(PlayText3());
        StartCoroutine(PlayText4());
        StartCoroutine(PlayButton());
    }

    IEnumerator PlayText2()
    {
        yield return new WaitForSeconds(2.0f);
        text2.SetActive(true);
    }

    IEnumerator PlayText3()
    {
        yield return new WaitForSeconds(4.0f);
        text3.SetActive(true);
    }

    IEnumerator PlayText4()
    {
        yield return new WaitForSeconds(6.0f);
        text4.SetActive(true);
    }

    IEnumerator PlayButton()
    {
        yield return new WaitForSeconds(8.0f);
        buttonFight.SetActive(true);
    }
}
