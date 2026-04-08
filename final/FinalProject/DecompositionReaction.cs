using System.Collections.Generic;

public class DecompositionReaction : Reaction
{
    public DecompositionReaction(List<Compound> reactants)
        : base(reactants)
    {
        CalculateProducts();
    }

    public override string GetReactionType()
    {
        return "Decomposition";
    }

    public override void CalculateProducts()
    {
        _products.Clear();

        if (_reactants.Count != 1)
        {
            return;
        }

        Compound sourceCompound = _reactants[0];
        List<Element> elements = sourceCompound.GetElements();

        for (int i = 0; i < elements.Count; i++)
        {
            Element element = elements[i];
            Dictionary<Element, int> composition = new Dictionary<Element, int>();
            composition.Add(element, 1);

            Compound product = new Compound(element.GetName(), composition);
            _products.Add(product);
        }
    }

    public override void Balance()
    {
        _coefficients.Clear();

        if (_reactants.Count != 1)
        {
            return;
        }

        Compound sourceCompound = _reactants[0];
        _coefficients.Add(sourceCompound, 1);

        for (int i = 0; i < _products.Count; i++)
        {
            Compound product = _products[i];
            List<Element> elements = product.GetElements();

            if (elements.Count == 1)
            {
                Element element = elements[0];
                int count = sourceCompound.GetElementCount(element);
                _coefficients.Add(product, count);
            }
        }
    }
}