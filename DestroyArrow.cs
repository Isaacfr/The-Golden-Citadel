using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(DestroyMe());
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
