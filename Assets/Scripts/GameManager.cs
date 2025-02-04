using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoMem;
    [SerializeField] private VideoClip jokes;
    [SerializeField] private RawImage screen;
    [SerializeField] private GameObject error;

    private float speed = 0.13f;

    void Start()
    {
        StartCoroutine(Mem(1f));
    }

    IEnumerator Mem(float waitTime)
    {
        Color color = screen.color;

        yield return new WaitForSeconds(waitTime);
        videoMem.gameObject.SetActive(true);

        while(color.a < 1f)
        {
            color.a += speed * Time.deltaTime;
            screen.color = color;
            yield return null;
        }

        error.SetActive(false);

        videoMem.clip = jokes;
        yield return new WaitForSeconds((float)jokes.length);

        videoMem.gameObject.SetActive(false);
        screen.gameObject.SetActive(false);
    }
}
