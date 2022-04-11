using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Micronix
{
    public class ConteextMenuUI : MonoBehaviour
    {
        public GameObject Copy;
        public GameObject Paste;
        public GameObject Cut;

        //make the buttons not interactable
        void UninteractableButton(GameObject btn)
        {
            btn.GetComponent<Button>().interactable = false;
            btn.GetComponentInChildren<Text>().color = new Color(50, 50, 50, 122);
        }
        //make the buttons interactable
        void InteractableButton(GameObject btn)
        {
            btn.GetComponent<Button>().interactable = true;
            btn.GetComponentInChildren<Text>().color = new Color(50, 50, 50, 255);
        }
        //For the cube 
        public void ObjSelect()
        {
            InteractableButton(Copy);
            InteractableButton(Cut);
            UninteractableButton(Paste);
        }
        //for the ground 
        public void GroundSelect()
        {
            UninteractableButton(Copy);
            UninteractableButton(Cut);
            InteractableButton(Paste);
        }

    }
}