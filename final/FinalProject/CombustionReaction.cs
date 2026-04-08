using System.Collections.Generic;

public class CombustionReaction : Reaction
{
    public CombustionReaction(List<Compound> reactants)
        : base(reactants)
    {
        CalculateProducts();
    }

    public override string GetReactionType()
    {
        return "Combustion";
    }

    public override void CalculateProducts()
    {
        _products.Clear();

        Element carbon = null;
        Element hydrogen = null;
        Element oxygen = null;

        Compound hydrocarbon = null;

        for (int i = 0; i < _reactants.Count; i++)
        {
            Compound reactant = _reactants[i];
            List<Element> elements = reactant.GetElements();

            bool containsCarbon = false;
            bool containsHydrogen = false;
            bool containsOnlyCH = true;

            for (int j = 0; j < elements.Count; j++)
            {
                string symbol = elements[j].GetFormula();

                if (symbol == "C")
                {
                    containsCarbon = true;
                    carbon = elements[j];
                }
                else if (symbol == "H")
                {
                    containsHydrogen = true;
                    hydrogen = elements[j];
                }
                else if (symbol == "O")
                {
                    oxygen = elements[j];
                    containsOnlyCH = false;
                }
                else
                {
                    containsOnlyCH = false;
                }
            }

            if (containsCarbon && containsHydrogen && containsOnlyCH)
            {
                hydrocarbon = reactant;
            }

            for (int j = 0; j < elements.Count; j++)
            {
                if (elements[j].GetFormula() == "O")
                {
                    oxygen = elements[j];
                }
            }
        }

        if (hydrocarbon == null || oxygen == null)
        {
            return;
        }

        Dictionary<Element, int> carbonDioxideComposition = new Dictionary<Element, int>();
        carbonDioxideComposition.Add(carbon, 1);
        carbonDioxideComposition.Add(oxygen, 2);

        Dictionary<Element, int> waterComposition = new Dictionary<Element, int>();
        waterComposition.Add(hydrogen, 2);
        waterComposition.Add(oxygen, 1);

        Compound carbonDioxide = new Compound("Carbon Dioxide", carbonDioxideComposition);
        Compound water = new Compound("Water", waterComposition);

        _products.Add(carbonDioxide);
        _products.Add(water);
    }

    public override void Balance()
    {
        _coefficients.Clear();

        Compound hydrocarbon = null;
        Compound oxygenGas = null;

        for (int i = 0; i < _reactants.Count; i++)
        {
            Compound reactant = _reactants[i];

            if (IsHydrocarbon(reactant))
            {
                hydrocarbon = reactant;
            }
            else if (reactant.GetFormula() == "O2")
            {
                oxygenGas = reactant;
            }
        }

        if (hydrocarbon == null || oxygenGas == null || _products.Count != 2)
        {
            return;
        }

        Element carbon = null;
        Element hydrogen = null;

        List<Element> hydrocarbonElements = hydrocarbon.GetElements();

        for (int i = 0; i < hydrocarbonElements.Count; i++)
        {
            Element element = hydrocarbonElements[i];

            if (element.GetFormula() == "C")
            {
                carbon = element;
            }
            else if (element.GetFormula() == "H")
            {
                hydrogen = element;
            }
        }

        int carbonCount = hydrocarbon.GetElementCount(carbon);
        int hydrogenCount = hydrocarbon.GetElementCount(hydrogen);

        int hydrocarbonCoefficient = 1;
        int carbonDioxideCoefficient = carbonCount;
        int waterCoefficient = hydrogenCount / 2;

        bool needsDoubling = false;

        if (hydrogenCount % 2 != 0)
        {
            needsDoubling = true;
        }

        if (needsDoubling)
        {
            hydrocarbonCoefficient = 2;
            carbonDioxideCoefficient = carbonCount * 2;
            waterCoefficient = hydrogenCount;
        }

        int oxygenAtomsNeeded = (carbonDioxideCoefficient * 2) + waterCoefficient;
        int oxygenGasCoefficient = oxygenAtomsNeeded / 2;

        Compound carbonDioxide = _products[0];
        Compound water = _products[1];

        _coefficients.Add(hydrocarbon, hydrocarbonCoefficient);
        _coefficients.Add(oxygenGas, oxygenGasCoefficient);
        _coefficients.Add(carbonDioxide, carbonDioxideCoefficient);
        _coefficients.Add(water, waterCoefficient);
    }

    private bool IsHydrocarbon(Compound compound)
    {
        List<Element> elements = compound.GetElements();
        bool hasCarbon = false;
        bool hasHydrogen = false;

        for (int i = 0; i < elements.Count; i++)
        {
            string symbol = elements[i].GetFormula();

            if (symbol == "C")
            {
                hasCarbon = true;
            }
            else if (symbol == "H")
            {
                hasHydrogen = true;
            }
            else
            {
                return false;
            }
        }

        return hasCarbon && hasHydrogen;
    }
}