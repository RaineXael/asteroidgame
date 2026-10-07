using UnityEngine;
using System.Collections;

public class ThrusterTester : MonoBehaviour
{
    public AudioSource thruster;

    public float fadeDuration = 0.3f;
    public float maxVolume = 1f;

    private Coroutine fadeCoroutine;

    void Start()
    {
        thruster.volume = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!thruster.isPlaying)
                thruster.Play();

            StartFade(maxVolume, false);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartFade(0f, true);
        }
    }

    void StartFade(float targetVolume, bool stopAfter)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(Fade(targetVolume, stopAfter));
    }

    IEnumerator Fade(float targetVolume, bool stopAfter)
    {
        float startVolume = thruster.volume;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            float progress = time / fadeDuration;

            thruster.volume =
                Mathf.Lerp(startVolume, targetVolume, progress);

            yield return null;
        }

        thruster.volume = targetVolume;

        if (stopAfter)
            thruster.Stop();
    }
}