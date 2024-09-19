using UnityEngine;

[CreateAssetMenu(fileName = "towerScriptableObjectScript", menuName = "Scriptable Objects/towerScriptableObjectScript")]
public class towerScriptableObjectScript : ScriptableObject
{
	public enum towerType
	{
		Archer,
		Mage,
		Gadget
	}

	public string towerName;
	public int towerLevel;
	public string towerDescription;
	public int towerCost;
    public float towerDamage;
    public float towerSpeed;
	public float towerRange;

	//public float frz; psn; brn;
}
