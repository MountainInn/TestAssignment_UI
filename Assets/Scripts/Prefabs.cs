using UnityEngine;

public class Prefabs : MonoBehaviour
{
    static Prefabs inst;
    static public Prefabs _Inst => inst??=GameObject.FindObjectOfType<Prefabs>();

    public Item prefItem;

}
