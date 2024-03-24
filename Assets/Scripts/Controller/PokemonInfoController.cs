using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokemonInfoController : MonoBehaviour
{
    [SerializeField] private Image _imgSprite;
    [SerializeField] private Text _txtName;
    [SerializeField] private Text _size;
    [SerializeField] private Text _weight;
    [SerializeField] private Text _type;
    [SerializeField] private Text _caption;
    [SerializeField] private Text _stats;

    private DatabaseManager _databaseMgr;
    private int _currentPokemonIndex = 0;

    private void Awake()
    {
        _databaseMgr = FindObjectOfType<DatabaseManager>();
    }

    void Start()
    {
        ShowPokemon(_currentPokemonIndex);
    }

    private void ShowPokemon(int index)
    {
        PokemonData _data = _databaseMgr.GetData(index);

        _imgSprite.sprite = _data.icon;
        _txtName.text = $"N°{_data.number.ToString("0000")} {_data.name}";
        _size.text = $" Taille : {_data.size.ToString()} m ";
        _weight.text = $" Poids : {_data.weight.ToString()} kg ";
        _type.text = $" Type : {_data.type}";
        _caption.text = _data.caption.ToString();
    }

    public void NextPokemon()
    {
        _currentPokemonIndex++;
        if (_currentPokemonIndex >= _databaseMgr.GetTotalPokemonCount())
        {
            _currentPokemonIndex = 0;
        }
        ShowPokemon(_currentPokemonIndex);
    }

    public void PreviousPokemon()
    {
        _currentPokemonIndex--;
        if (_currentPokemonIndex < 0)
        {
            _currentPokemonIndex = _databaseMgr.GetTotalPokemonCount() - 1;
        }
        ShowPokemon(_currentPokemonIndex);
    }
}
