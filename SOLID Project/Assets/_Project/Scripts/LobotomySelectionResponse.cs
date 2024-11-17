using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LobotomySelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField]
    private GameObject lobotomyEffectsHolder;

    private List<ILobotomyEffect> _lobotomyEffects;

    int randomValue = 0;
    bool firstSelection = true;

    private void Start()
    {
        _lobotomyEffects = lobotomyEffectsHolder.GetComponents<ILobotomyEffect>().ToList();
    }

    public void OnSelect(Transform selection)
    {
        if (firstSelection)
        {
            _lobotomyEffects[0].StartEffect(selection);
            return;
        }

        randomValue = Random.Range(0, _lobotomyEffects.Count);
        _lobotomyEffects[randomValue].StartEffect(selection);
    }

    public void OnDeselect(Transform selection)
    {
        if (firstSelection)
        {
            _lobotomyEffects[0].StartEffect(selection);
            firstSelection = false;
            return;
        }

        _lobotomyEffects[randomValue].StopEffect(selection);
    }



}
