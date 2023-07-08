using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFactory
{
    private static List<TreeType> _treeTypes = new List<TreeType>();

    public static TreeType getTreeType(string name, string color, string texture)
    {
        foreach (var treeType in _treeTypes)
        {
            if (treeType.Name == name && treeType.Color == color && treeType.Texture == texture)
            {
                return treeType;
            }
        }

        TreeType newTreeType = new TreeType(name, color, texture);
        _treeTypes.Add(newTreeType);
        return newTreeType;
    }
}
