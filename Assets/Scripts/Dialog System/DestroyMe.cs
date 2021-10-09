using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField] private float timeToDie;
    void Start()
    {
        StartCoroutine("KillMe");
    }

    IEnumerator KillMe()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
    }
}
