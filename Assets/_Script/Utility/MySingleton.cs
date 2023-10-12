using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Start is called before the first frame update
    private static T instance_;
    public static T Instance
    {
        get
        {
            if (MySingleton<T>.instance_ == null)
            {
                MySingleton<T>.instance_ = (T)FindObjectOfType<T>();
                if (MySingleton<T>.instance_ == null)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.name = "{@" + typeof(T).Name + "]";
                    MySingleton<T>.instance_ = gameObject.AddComponent<T>();
                }
            }
            return MySingleton<T>.instance_;
        }
    }

    private void Reset()
    {
        gameObject.name = typeof(T).Name;
    }

}
