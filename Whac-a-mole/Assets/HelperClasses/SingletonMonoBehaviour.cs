using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour
	where T : SingletonMonoBehaviour<T>
{
	private static T _instance;

	public static T Instance
	{
		get
		{
			CreateInstance();
			return _instance;
		}
	}

	public static void CreateInstance()
	{
		if (_instance != null)
		{
			return;
		}

		_instance = FindObjectOfType<T>();

		if (_instance == null)
		{
			GameObject _go = new GameObject(typeof(T).Name);
			_instance = _go.AddComponent<T>();
		}
	}
}
