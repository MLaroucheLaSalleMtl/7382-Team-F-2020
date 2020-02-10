using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IDeselectHandler, IPointerDownHandler
{
	public void OnDeselect(BaseEventData eventData)
	{
		GetComponent<Selectable>().OnPointerExit(null); //When use keyboard, deselect the button ******
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (GetComponent<Button>() != null)
		{
			GetComponent<Button>().onClick.Invoke();
			Input.ResetInputAxes();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		//********************************************************// focus mouse
		GetComponent<Selectable>().Select(); //On mouse over, select that button
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
