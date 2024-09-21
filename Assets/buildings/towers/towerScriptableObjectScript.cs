using UnityEngine;

public enum towerType
{
    Archer, //Marksman
    Mage,	//Magicial
    Gadget, //Machine, Mechanical
    Gizmo
}

[CreateAssetMenu(fileName = "towerScriptableObjectScript", menuName = "Scriptable Objects/towerScriptableObjectScript")]

public class towerScriptableObjectScript : ScriptableObject
{
	public string towerName;
	public int towerLevel;
	public towerType towerType;
	public string towerDescription;
	public int towerCost;
    public float towerDamage;
    public float towerSpeed;
	public float towerBaseSpeed; //arbitrary number for show, 1 = slowest, 5 = fastets, archer is 4, mage is 3.
	public float towerRange;

	public float frz;
	public float psn;
	public float brn;

	public Sprite towerIcon;
	public towerScriptableObjectScript upgradeTower;
	public GameObject upgradeTowerObj;
	public float upgradeCost;
}
