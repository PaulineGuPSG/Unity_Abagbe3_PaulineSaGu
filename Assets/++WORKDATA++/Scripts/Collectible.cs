using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 1;
    public AudioClip collectSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddPoints(points);
            if (collectSound) AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(gameObject);
        }
    }
}