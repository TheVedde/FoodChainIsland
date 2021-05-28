using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public static class Utilities
{
    public static List<Vector2Int> Directions = new List<Vector2Int>() {Vector2Int.left, Vector2Int.up, Vector2Int.right, Vector2Int.down};
    public static List<Vector2Int> Directions2 = new List<Vector2Int>() {Vector2Int.left + Vector2Int.left, Vector2Int.up + Vector2Int.up,  Vector2Int.right + Vector2Int.right, Vector2Int.down + Vector2Int.down};

    public static List<Vector2Int> Diagonals = new List<Vector2Int>() 
        {Vector2Int.left + Vector2Int.up, Vector2Int.up + Vector2Int.right, Vector2Int.right + Vector2Int.down, Vector2Int.down + Vector2Int.left};

    public const int HEIGHT = 10;
    public const int WIDTH = 10;
    public static Field[,] map = new Field[WIDTH, HEIGHT];
    
    public static Random rnd = new Random();
    public static bool IsWithinRange(Vector2Int firstCard, Vector2Int secondCard) {
        Vector2Int diff = firstCard - secondCard;
        if (Directions.Contains(diff)) {
            return true;
        }else {
            return false;
        }
    }

    public static bool IsWithinRangeFox(Vector2Int firstCard, Vector2Int secondCard) {
        Vector2Int diff = firstCard - secondCard;
        if (Diagonals.Contains(diff)) {
            return true;
        }else {
            return false;
        }
    }
    
    public static void Shuffle<T>( IList<T> list)  
    {
        int n = list.Count;  
     
        while (n > 1) {  
            n--;  
            int k = rnd.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
    
    public static bool IsWithinRangeTiger(Vector2Int firstCard, Vector2Int secondCard) {
       
        if (Mathf.Abs(firstCard.x - secondCard.x) + 
            Mathf.Abs(firstCard.y - secondCard.y) == 2) {
            return true;
        }else {
            return false;
        }
    }
    
    public static bool IsWithinRangeLynx(Vector2Int firstCard, Vector2Int secondCard) {
        Vector2Int diff = firstCard - secondCard;
        if (Directions2.Contains(diff)) {
            return true;
        }
        else {
            return false;
        }
    }
    
    public static bool CanPredEatPray(Card firstCard, Card secondCard) 
    {
        int diff = firstCard.number - secondCard.number;
        
        if (firstCard.number > secondCard.number &&
            diff > 0 && diff < 4) 
        { 
            return true;
        }else {
            return false;
        }
    }
    public static bool CanPredEatPrayLion(Card firstCard, Card secondCard) 
    {
        int diff = firstCard.number - secondCard.number;
        
        if (firstCard.number > secondCard.number && diff == 1) 
        { 
            return true;
        }else {
            return false;
        }
        
    }
    public static bool CanPredEatPrayShark(Card firstCard, Card secondCard) 
    {
        int diff = firstCard.number - secondCard.number;
        
        if (firstCard.number > secondCard.number) 
        { 
            return true;
        }else {
            return false;
        }
    }
    
    public static bool IsWitihinBounds(Vector2Int direction, Vector2Int pos) {
        Vector2Int vec = direction + pos;
        if (vec.x > 0 || vec.y > 0) {
            return false;
        }
        if (vec.y >= HEIGHT || vec.y >= WIDTH) {
            return false;
        }
        return true;
    }
}
