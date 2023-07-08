using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    private List<Tree> _trees = new List<Tree>();

    public void PlantTree(int x, int y, string name, string color, string texture)
    {
        TreeType treeType = TreeFactory.getTreeType(name, color, texture);
        _trees.Add(new Tree(x,y,treeType));
    }

    private void Start()
    {
        PlantTree(2,1,"Pine","Green","Simple");
        for (int i = 0; i < 100; i++)
        {
            PlantTree(i,5,"Pine","Brown","Simple");
        }
        
        this.draw();
    }

    public void draw()
    {
        foreach (var tree in _trees)
        {
            Debug.Log(tree.draw());
        }
    }
}
