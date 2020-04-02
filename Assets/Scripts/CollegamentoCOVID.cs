using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollegamentoCOVID : MonoBehaviour {

		public void OpenUrl() {
		Application.OpenURL("http://www.salute.gov.it/portale/nuovocoronavirus/dettaglioContenutiNuovoCoronavirus.jsp?lingua=italiano&id=5386&area=nuovoCoronavirus&menu=vuoto");
	}

		public void Youtube() {
		Application.OpenURL("https://www.youtube.com/watch?v=vn3dwDMKRJE");
	}
}
