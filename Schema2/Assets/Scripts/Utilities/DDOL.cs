using UnityEngine;
/// <summary>
/// All this script does is make sure the object it's attached to is not destroyed on scene load. 
/// This is useful for music objects that should continue working across scenes.
/// </summary>
public class DDOL : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
