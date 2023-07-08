using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    private int x;
    private int y;
    private TreeType type;

    public string draw()
    {
        return type.draw(x, y);
    }

    public Tree(int x, int y, TreeType type)
    {
        this.x = x;
        this.y = y;
        this.type = type;
    }
}
