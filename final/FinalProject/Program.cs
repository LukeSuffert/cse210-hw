Element hydrogen = new Element("Hydrogen", "H", 1, 1.008);
Element oxygen = new Element("Oxygen", "O", 8, 16.00);

var waterComposition = new Dictionary<Element, int>
{
    { hydrogen, 2 },
    { oxygen, 1 }
};

Compound water = new Compound("Water", waterComposition);

Console.WriteLine(water.GetFormula());    
Console.WriteLine(water.GetMolarMass());  