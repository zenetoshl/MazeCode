using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Example : MonoBehaviour, IPointerDownHandler
{

    public Transform prefab;

    private Transform spawn;
    public Button button;

    private void Start() {
        Debug.Log(button.transform);
    }

    void Update()
    {
        //Debug.Log(this.gameObject.GetComponent<RectTransform>().rect);

        if (Input.GetMouseButton(0) && spawn != null)
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            spawn.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(EventSystem.current.IsPointerOverGameObject()){
                Destroy(spawn.gameObject);
                //adicionar 1 ao inventário novamente
            }
            ClickController.isClickingOnObject = false;
            spawn = null;
        }


    }

    public void OnPointerDown(PointerEventData eventData){
        ClickController.isClickingOnObject = true;
        var pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        spawn = Instantiate(prefab, pos, Quaternion.identity) as Transform;
    }

    void OnGUI() {
         
     }
}