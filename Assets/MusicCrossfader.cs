using UnityEngine;
using System.Collections;

public class MusicCrossfader : MonoBehaviour
{
    public AudioSource exploration;
    public AudioSource combat;

    public float fadeDuration = 1.5f;

    private Coroutine currentFade;

    void Start()
    {
        exploration.volume = 1f;
        combat.volume = 0f;

        // Both begin together so they stay synchronized
        exploration.Play();
        combat.Play();
    }

    void Update()
    {
        // Practice controls
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crossfade(exploration, combat);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Crossfade(combat, exploration);
        }
    }

    void Crossfade(AudioSource from, AudioSource to)
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(Fade(from, to));
    }

    IEnumerator Fade(AudioSource from, AudioSource to)
    {
        float time = 0f;

        float fromStart = from.volume;
        float toStart = to.volume;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            float progress = time / fadeDuration;

            from.volume = Mathf.Lerp(fromStart, 0f, progress);
            to.volume = Mathf.Lerp(toStart, 1f, progress);

            yield return null;
        }

        from.volume = 0f;
        to.volume = 1f;
    }
}