using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrap : MonoBehaviour
{
    public GameObject explo;
    private SpriteRenderer sprite;
    [SerializeField] private float timeToExplo = 0.5f;
    private void Start()
    {
    sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite.enabled = true;
          
            StartCoroutine(StartExplo());
        }
    }
    
    IEnumerator StartExplo()
    {
        yield return new WaitForSeconds(timeToExplo);
        this.gameObject.SetActive(false);
        Instantiate(explo, transform.position, Quaternion.identity);
        SoundManager.Instance.PlaySound(SoundTags.AttackExplo);
    }
}
