using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MasterVolumeManager : MonoBehaviour
{
    public float volume;
    public MonoBehaviour myScript;
    private UnityEngine.UI.Slider myUI;
    public virtual void Start()
    {
    }

    public MasterVolumeManager()
    {
        this.volume = 1;
    }

}