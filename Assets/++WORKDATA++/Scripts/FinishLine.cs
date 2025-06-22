using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            GameManager.instance.WinGame();
        }
    }
}