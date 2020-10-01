using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item
{
    public enum ItemTypes { Weapon, Consumeable, Money, Questitems}//verlängerbar muss im JSON angegeben werden
    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]//Enum name statt index  
    public ItemTypes ItemType { get; set; }
    public string ActionName { get; set; }
    public string ItemName { get; set; }
    public bool ItemModifier { get; set; }
    //ObjectSlug ist nur der Name eines Objects bspw. gibt es den "Namen" super duper Schwert und super Schwert der Unterschied liegt nur in den Stats und den Namen aber das Prefab bleibt das Gleiche so können wir hier die
    // Stats abändern ohne das wir ein komplett neues Item anlegen müssen ;)
    public Item(List<BaseStat> _Stats, string _ObjectSlug)
    {
        this.Stats = _Stats;
        this.ObjectSlug = _ObjectSlug;
    }
    [JsonConstructor]
    public Item(List<BaseStat> _Stats, string _ObjectSlug, string _Description, ItemTypes _ItemType,string _ActionName, string _ItemName, bool _ItemModifier)
    {
        this.Stats = _Stats;
        this.ObjectSlug = _ObjectSlug;
        this.Description = _Description;
        this.ItemType = _ItemType;
        this.ActionName = _ActionName;
        this.ItemName = _ItemName;
        this.ItemModifier = _ItemModifier;
    }
}
