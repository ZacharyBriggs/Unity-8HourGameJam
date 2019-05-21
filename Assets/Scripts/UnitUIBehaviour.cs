using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUIBehaviour : MonoBehaviour
{
    public Image image;
    public Text HPText;
    public Text PowerText;
    public Text APSText;
    public Text SpeedText;
    public List<Button> buttons = new List<Button>();
	public void SetUnitUI(Unit unit)
    {
        image.gameObject.SetActive(true);
        var unitChild = unit.transform.GetChild(0);
        var unitSprite = unitChild.gameObject.GetComponent<SpriteRenderer>();
        var thisImage = this.transform.GetChild(0).GetComponent<Image>();
        thisImage.sprite = unitSprite.sprite;
        HPText.text = unit.HP.ToString();
        PowerText.text = unit.Damage.ToString();
        APSText.text = unit.attackSpeed.ToString();
        SpeedText.text = unit.moveSpeed.ToString();
    }

    public void SetOnionUI(OnionBehaviour onion)
    {
        image.gameObject.SetActive(true);
        var buildingChild = onion.transform.GetChild(0);
        var buildingSprite = buildingChild.gameObject.GetComponent<SpriteRenderer>().sprite;
        var thisImage = this.transform.GetChild(0).GetComponent<Image>();
        thisImage.sprite = buildingSprite;
        HPText.text = onion.HP.ToString();
        buttons[0].onClick.AddListener(onion.SpawnPikmin);
    }

    public void TurnOffUI()
    {
        image.gameObject.SetActive(false);
        foreach(var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
