using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager
{
	Dictionary<string, object> _cache = new Dictionary<string, object>();

	public T Load<T>(string path, bool caching = true) where T : Object
	{
		if (_cache.ContainsKey(path))
			return _cache[path] as T;

		if (!caching)
		{
			return Resources.Load<T>(path);
		}
		_cache.Add(path, Resources.Load<T>(path));
		return _cache[path] as T;
	}

	public GameObject Instantiate(GameObject obj,Transform parent=null, bool caching = true)
	{
		return GameObject.Instantiate(obj,parent,caching);
	}

	public GameObject Instantiate(string path, Transform parent = null, bool caching = true)
	{
		return Instantiate(Load<GameObject>($"Prefabs/{path}",caching), parent);
	}

	public void ClearCache()
	{
		GC.Collect();
	}
}