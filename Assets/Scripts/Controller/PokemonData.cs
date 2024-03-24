using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PokemonData
{
    [Serializable]
    public struct Stats
    {
        public int pv;
        public int attack;
        public int defense;
        public int atkSpe;
        public int defSpe;
        public int speed;

        public Stats(int pv, int attack, int defense, int atkSpe, int defSpe, int speed)
        {
            this.pv = pv;
            this.attack = attack;
            this.defense = defense;
            this.atkSpe = atkSpe;
            this.defSpe = defSpe;
            this.speed = speed;
        }

        public Stats(Stats statsBase, int coeff)
        {
            this.pv = statsBase.pv * coeff;
            attack = statsBase.attack * coeff;
            defense = statsBase.defense * coeff;
            atkSpe = statsBase.atkSpe * coeff;
            defSpe = statsBase.defSpe * coeff;
            speed = statsBase.speed * coeff;
        }
    }

    public string name;
    public int number;
    public float size;
    public float weight;
    public string type;
    public Sprite icon;
    public string caption;

    public Stats statsBase;
    public PokemonData(){ }

    public PokemonData(string name, int number, float size, float weight, string type, Sprite icon, string caption, Stats stats = default)
    {
        this.name = name;
        this.number = number;
        this.size = size;
        this.weight = weight;
        this.type = type;
        this.icon = icon;
        this.caption = caption;

        this.statsBase = stats;
    }
}