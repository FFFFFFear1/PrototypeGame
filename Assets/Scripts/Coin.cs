using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject coinParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UIController.instance.CoinsCount++;
            Instantiate(coinParticle, transform.position, transform.rotation);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
