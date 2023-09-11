using UnityEngine;

public class SelectedCategory : MonoBehaviour
{
    // This instance is saved when loading next scene and has the category selected
    public int category;

    void Awake()
    {
        DontDestroyOnLoad(FindFirstObjectByType<SelectedCategory>());
    }
}
