using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TriggerTimeLine : MonoBehaviour
{
    public PlayableDirector playable;
    public GameObject uI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playable.Play();

            uI.SetActive(false);   
            GameManager.Instance.StopMusicAccordingScene();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uI.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Instance.PlayMusicAccordingScene();

        }
    }

}
