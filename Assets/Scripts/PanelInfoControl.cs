using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfoControl : MonoBehaviour {

public GameObject infoPanel;
public GameObject mainPanel;

	// Use this for initialization
	public void StartOnclick () {
		infoPanel.SetActive(true);
		mainPanel.SetActive(false);
	}
	// Update is called once per frame
}
