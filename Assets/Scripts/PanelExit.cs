using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelExit : MonoBehaviour {

public GameObject infoPanel;
public GameObject mainPanel;
	public void onClickExit () {
		infoPanel.SetActive(false);
		mainPanel.SetActive(true);
	}
}
