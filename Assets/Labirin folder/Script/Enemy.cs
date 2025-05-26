using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void Destroyed();
    public event Destroyed OnDestroyed;

    void OnDestroy()
    {
        if (OnDestroyed != null)
        {
            OnDestroyed.Invoke();
        }
    }

    // Fungsi lain untuk musuh...
}
