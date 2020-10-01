using UnityEngine;

	[CreateAssetMenu (menuName = "VorbereitungsRaum/Create Attribute")]		//Menu tool um neue Attribute zu erstellen
    public class Attribute : ScriptableObject								//Spielers Attributewert in PlayerAttribute
    {
        public string Description;
        public Sprite Thumbnail;
    }
