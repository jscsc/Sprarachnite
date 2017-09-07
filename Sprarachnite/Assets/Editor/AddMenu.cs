using UnityEngine;
using UnityEditor;

// Author: Jacob Stone 1/16/17
public class AddMenu : EditorWindow {

	[MenuItem("Edit/Reset Playerprefs")]

	public static void DeletePlayerPrefs() {
		PlayerPrefs.DeleteAll();
	}
	
}
