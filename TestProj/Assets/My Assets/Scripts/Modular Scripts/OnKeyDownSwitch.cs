using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class OnKeyDownSwitch : MonoBehaviour
{
    //iterate through a list of disabled objects. Once we've reached the end of the list, load a scene
    public GameObject[] myObjects;
    public int myIndex;
    public string myScene;
    public virtual void Update()
    {
        if (Input.anyKeyDown)
        {
            this.IterateObjects();
        }
    }

    public virtual void IterateObjects()
    {
        if (this.myIndex < (this.myObjects.Length - 1))
        {
            this.myIndex = this.myIndex + 1;
            this.myObjects[this.myIndex - 1].active = false;
            this.myObjects[this.myIndex].active = true;
        }
        else
        {
            Application.LoadLevel(this.myScene);
        }
    }

}