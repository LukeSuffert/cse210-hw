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
        // Combine all elements from reactants into one compound

        Dictionary<Element, int> combinedComposition =
            new Dictionary<Element, int>();

        foreach (Compound compound in _reactants)
        {
            foreach (Element element in compound.GetElements())
            {
                int count = compound.GetElementCount(element);

                if (combinedComposition.ContainsKey(element))
                    combinedComposition[element] += count;
                else
                    combinedComposition[element] = count;
            }
        }

        Compound product = new Compound("Product", combinedComposition);
        _products.Add(product);
    }
}