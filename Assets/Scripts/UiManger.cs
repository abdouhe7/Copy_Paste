using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Micronix
{
    public class UiManger : MonoBehaviour
    {
        public GameObject Cube;
        public MainManger _MainManger;
        public GameObject contextMenuPre;
        public GameObject contextMenu;
        public Vector3 hitPostion;

        public void CreateCube()
        {
            if (!Cube)
            {
                //Create a cube with new coloer
                Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.position = new Vector3(0, 0.5f, 0);
                Cube.tag = "Cube";
                Cube.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
            else
            {
                //if the cube created change the coloer value
                Cube.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
        }

        private void Update()
        {
            MouseContextMenuLisener();
        }

        void MouseContextMenuLisener()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay((Input.mousePosition));
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    switch (hitInfo.collider.gameObject.tag)
                    {
                        case "Cube":
                            CreatContextMenu();
                            // make the object optines only appers
                            contextMenu.GetComponent<ConteextMenuUI>().ObjSelect();
                            _MainManger.Selected = hitInfo.collider.gameObject;
                            break;
                        case "Ground":
                            CreatContextMenu();
                            // make he ground options only appers
                            contextMenu.GetComponent<ConteextMenuUI>().GroundSelect();
                            // save the mouse position to paste the object
                            hitPostion = hitInfo.point;
                            hitPostion.y += 0.5f;
                            break;
                    }
                }
            }
        }
        
        void CreatContextMenu()
        {
            //destroy other Contextmenu
            if (contextMenu)
            {
                Destroy(contextMenu);
            }
            // insilize ContextMenu
            contextMenu = Instantiate(contextMenuPre, this.gameObject.transform);
            // in the mouse position
            contextMenu.transform.position = Input.mousePosition;
            foreach (var btn in contextMenu.GetComponentsInChildren<Button>())
            {
                //insilize the functions on the button 
                switch (btn.name)
                {
                    case "Copy":
                        btn.onClick.AddListener(_MainManger.Copy);
                        break;
                    case "Paste":
                        btn.onClick.AddListener(_MainManger.Paste);
                        break;
                    case "Cut":
                        btn.onClick.AddListener(_MainManger.Cut);
                        break;
                }
            }

        }

    }
}