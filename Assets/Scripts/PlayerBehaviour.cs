using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public UnitUIBehaviour UnitUI;
    public UnitUIBehaviour BuildingUI;
    [SerializeField]
    private Unit selected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            OnLeftClick();
        }
        if(Input.GetButtonDown("Fire2"))
        {
            OnRightClick();
        }
	}

    public void OnLeftClick()
    {
        
        var cameraPos = Camera.main.transform.position;
        var mousePos = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(mousePos);
        var direction = cameraPos - mousePos;
        direction = direction.normalized;
        var rayHit = new RaycastHit();
        Physics.Raycast(ray, out rayHit);
        Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 99);
        Debug.Log(rayHit.collider.name);
        var unit = rayHit.collider.transform;
        if (rayHit.collider.transform.CompareTag("Pikmin"))
        {
            UnitUI.TurnOffUI();
            BuildingUI.TurnOffUI();
            selected = unit.GetComponent<PikminBehaviour>();
            UnitUI.transform.gameObject.SetActive(true);
            UnitUI.SetUnitUI(selected);
        }
        if (rayHit.collider.transform.CompareTag("Onion"))
        {
            UnitUI.TurnOffUI();
            BuildingUI.TurnOffUI();
            BuildingUI.SetOnionUI(unit.gameObject.GetComponent<OnionBehaviour>());
        }
    }

    public void OnRightClick()
    {
        if (selected != null)
        {
            var cameraPos = Camera.main.transform.position;
            var mousePos = Input.mousePosition;
            var ray = Camera.main.ScreenPointToRay(mousePos);
            var direction = cameraPos - mousePos;
            direction = direction.normalized;
            var rayHit = new RaycastHit();
            Physics.Raycast(ray, out rayHit);
            Debug.DrawRay(ray.origin, ray.direction * 30, Color.green, 99);
            Debug.Log(rayHit.collider.name);
            var unit = rayHit.collider.transform;
            if (rayHit.collider.transform.CompareTag("Enemy"))
            {
                selected.targetGO = unit.gameObject;
            }
        }
    }
}
