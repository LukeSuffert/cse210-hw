using System.Collections.Generic;

public class SynthesisReaction : Reaction
{
    public SynthesisReaction(List<Compound> reactants)
        : base(reactants)
    {
        CalculateProducts();
    }

    public override string GetReactionType()
    {
        return "Synthesis";
    }

    public override void CalculateProducts()
    {
        _products.Clear();

        Dictionary<Element, int> combinedComposition = new Dictionary<Element, int>();

        for (int i = 0; i < _reactants.Count; i++)
        {
            Compound compound = _reactants[i];
            List<Element> elements = compound.GetElements();

            for (int j = 0; j < elements.Count; j++)
            {
                Element element = elements[j];
                int count = compound.GetElementCount(element);

                if (combinedComposition.ContainsKey(element))
                {
                    combinedComposition[element] = combinedComposition[element] + count;
                }
                else
                {
                    combinedComposition.Add(element, count);
                }
            }
        }

        Compound product = new Compound("Synthesis Product", combinedComposition);
        _products.Add(product);
    }

    public override void Balance()
    {
        _coefficients.Clear();

        if (_reactants.Count != 2 || _products.Count != 1)
        {
            return;
        }

        Compound reactant1 = _reactants[0];
        Compound reactant2 = _reactants[1];
        Compound product = _products[0];

        int coefficient1 = 1;
        int coefficient2 = 1;
        int productCoefficient = 1;

        List<Element> productElements = product.GetElements();

        for (int i = 0; i < productElements.Count; i++)
        {
            Element element = productElements[i];

            int leftCount = 0;
            leftCount = leftCount + reactant1.GetElementCount(element) * coefficient1;
            leftCount = leftCount + reactant2.GetElementCount(element) * coefficient2;

            int rightCount = product.GetElementCount(element) * productCoefficient;

            if (leftCount != rightCount)
            {
                int leastMultiple = GetLeastCommonMultiple(leftCount, rightCount);

                if (leftCount != 0)
                {
                    productCoefficient = leastMultiple / rightCount;
                }
            }
        }

        _coefficients.Add(reactant1, coefficient1);
        _coefficients.Add(reactant2, coefficient2);
        _coefficients.Add(product, productCoefficient);
    }

    private int GetGreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private int GetLeastCommonMultiple(int a, int b)
    {
        if (a == 0 || b == 0)
        {
            return 1;
        }

        return (a * b) / GetGreatestCommonDivisor(a, b);
    }
}