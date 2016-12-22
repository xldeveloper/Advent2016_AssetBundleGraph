using UnityEngine;
using UnityEditor;

using System;
using System.Collections.Generic;
using System.Linq;

using AssetBundleGraph;

[AssetBundleGraph.CustomPrefabBuilder("MyBuilder")]
public class MyPrefabBuilder : IPrefabBuilder {

	[SerializeField] private Color color;

	/**
		 * Test if prefab can be created with incoming assets.
		 * @result Name of prefab file if prefab can be created. null if not.
		 */
	public string CanCreatePrefab (string groupKey, List<UnityEngine.Object> objects) {

		if(objects.Count == 1) {
			Debug.Log("ho");
			return string.Format("MyPrefab{0}", groupKey);
		}

		return null;
	}

	/**
	 * Create Prefab.
	 */ 
	public UnityEngine.GameObject CreatePrefab (string groupKey, List<UnityEngine.Object> objects) {

		GameObject go = new GameObject(string.Format("MyPrefab{0}", groupKey));

		GUITexture t = go.AddComponent<GUITexture>();

		Texture2D tex = (Texture2D)objects.Find(o => o.GetType() == typeof(UnityEngine.Texture2D));

		t.texture = tex;
		t.color = color;

		return go;
	}

	/**
	 * Draw Inspector GUI for this PrefabBuilder.
	 */ 
	public void OnInspectorGUI (Action onValueChanged) {

	}

	/**
	 * Serialize this PrefabBuilder to JSON using JsonUtility.
	 */ 
	public string Serialize() {
		return JsonUtility.ToJson(this);
	}
}