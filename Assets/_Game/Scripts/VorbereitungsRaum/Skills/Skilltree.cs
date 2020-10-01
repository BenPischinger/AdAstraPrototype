using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class Skilltree : Interactable {

		[SerializeField]
		private Canvas m_Canvas;
		private bool m_SeeCanvas;

		public override void Interact()
		{
			if (m_Canvas)										//es Canvas zugewiesen
			{
				m_SeeCanvas = !m_SeeCanvas;						
				Cursor.visible = !Cursor.visible;
				m_Canvas.gameObject.SetActive(m_SeeCanvas); 	//Skilltree Canvas wird an und aus geschaltet
			}
		}		
	}

