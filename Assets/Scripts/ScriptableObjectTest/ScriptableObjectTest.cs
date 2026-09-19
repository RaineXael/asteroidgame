using UnityEngine;
// Use the CreateAssetMenu attribute to allow creating instances of this ScriptableObject from the Unity Editor.
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ScriptableObjectTest : ScriptableObject
{
    //This is an example of a scriptable object.
    //We can use this for various things: Dialog,
    //shop assets, etc. Very versitile.

    public string prefabName;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
}