using UnityEngine;

public enum Position
{
	Left,
	Right,
}

[System.Serializable]
public class Dialogue
{
	public string[] name;
	public Position[] position;

	[TextArea(3, 10)]
	public string[] sentences;
}