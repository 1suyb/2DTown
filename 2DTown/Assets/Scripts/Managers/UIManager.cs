using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class UIManager
{
	// popUp 들을 관리
	private Stack<UI_Popup> UI_popups = new Stack<UI_Popup>();
	private Dictionary<string, GameObject> _cache = new Dictionary<string, GameObject>();

	private int _sort = 0;

	public void Init()
	{
	}

	public UI_Scene OpenSceneUI(string path)
	{
		GameObject obj = Managers.Resource.Instantiate($"UI/Scene/{path}",caching:false);
		if (!CheckGameObjectUIType<UI_Scene>(obj)) { return null; }
		SetCanvas(obj,sort:false);
		return obj.GetComponent<UI_Scene>();
	}

	public UI_Popup OpenPopUp(string path)
	{
		GameObject obj;
		if (!_cache.ContainsKey(path)) 
		{
			obj = Managers.Resource.Instantiate($"UI/Popup/{path}");
			if (!CheckGameObjectUIType<UI_Popup>(obj)) { return null; }
			_cache.Add(path, obj);
		}
		obj = _cache[path];
		obj.SetActive(true);
		SetCanvas(obj);
		UI_Popup popup = obj.GetComponent<UI_Popup>();
		UI_popups.Push(obj.GetComponent<UI_Popup>());
		return popup;
	}

	public List<T> CreateSubItems<T>(string path, int count = 1, Transform parent= null) where T : UI_SubItem
	{
		List<T> list = new List<T>();
		for (int i = 0; i < count; i++)
		{
			GameObject obj = Managers.Resource.Instantiate($"UI/SubItem/{path}",parent);
			if (!CheckGameObjectUIType<T>(obj))
				return null;
			list.Add(obj.GetComponent<T>());
		}
		return list;
	}

	public bool CheckGameObjectUIType<T>(GameObject obj) where T : UI_Base
	{
		if(!obj.TryGetComponent<T>(out T component))
		{
			GameObject.Destroy(obj);
			Debug.LogWarning("잘못된 UI를 불러왔습니다.");
			return false;
		}
		return true;
	}

	public void SetCanvas(GameObject obj, bool sort = true)
	{
		Canvas canvas = obj.GetOrAddComponent<Canvas>();
		if (sort)
			canvas.sortingOrder = ++_sort;
		else
			canvas.sortingOrder = 0;
	}

	public void ClosePopUp()
	{
		UI_Popup popup = UI_popups.Pop();
		popup.gameObject.SetActive(false);
		_sort--;
	}

	public void Clear()
	{
		_cache.Clear();
		GC.Collect();
	}
	

}
