using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeType
{
    private string name;
    private string color;
    private string texture;

    public TreeType(string name, string color, string texture)
    {
        this.name = name;
        this.color = color;
        this.texture = texture;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Color
    {
        get => color;
        set => color = value;
    }

    public string Texture
    {
        get => texture;
        set => texture = value;
    }

    public string draw(int x, int y)
    {
        return "The tree is planted at (" + x.ToString() + "," + y.ToString() + ") with name, color, texture: " + name +
               ", " + color + ", " + texture;
    }
}
