using UnityEngine;

public class SFXTester : MonoBehaviour
{
    public AudioSource sfxSource;

    public AudioClip playerShot;
    public AudioClip enemyShot;
    public AudioClip damage;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            sfxSource.PlayOneShot(playerShot);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            sfxSource.PlayOneShot(enemyShot);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            sfxSource.PlayOneShot(damage);
    }
}