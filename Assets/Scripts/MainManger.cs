using UnityEngine;

namespace Micronix
{
    public class MainManger : MonoBehaviour
    {
        bool copy;
            
        public GameObject Copied;
        public GameObject Selected;
        public UiManger _UiManger;
        
        
        public void Copy()
        {
            Copied = Selected;
            Destroy(_UiManger.contextMenu);
            copy = true;
        }
        public void Cut()
        {
            Copied = Selected;
            Selected.SetActive(false);
            Copied.transform.position = _UiManger.hitPostion;
            Destroy(_UiManger.contextMenu);
            copy = false;
        }
        public void Paste()
        {
            if(copy)
            {
                //create onother copy of the cube
                Copied = Instantiate(Copied,transform);
            }
            // change the cube's place
            Copied.transform.position = _UiManger.hitPostion;
            //reset the defalt placeof the cube
            _UiManger.Cube = null;
            Selected.SetActive(true);
            Destroy(_UiManger.contextMenu);
        }
    }
}