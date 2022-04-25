namespace DooDHackAPI.CompoundPattern;
public class Compound
{
    public Compound() { }
    public Compound(string name) { Name = name; }
    public dynamic this[string name]
    {
        get => Elements[name].Value;
        set
        {
            int index = Elements.IndexOf(name);
            if (index != -1)
                Elements[index].Value = value;
        }
    }
    public dynamic this[int index]
    {
        get => Elements[index].Value;
        set
        {
            if (index >= 0 && index < Elements.Count)
                Elements[index].Value = value;
        }
    }

    public string Name { get; set; }
    public ElementCollection Elements { get; set; }
    public CompoundCollection Compounds { get; set; }
    public int GetElementIndex(string name) => Elements.IndexOf(name);
    public int GetCompoundIndex(string name) => Compounds.IndexOf(name);
    public Element GetElement(int index) => Elements[index];
    public Element GetElement(string name) => Elements[name];
    public Compound GetCompound(int index) => Compounds[index];
    public Compound GetCompound(string name) => Compounds[name];
    public void AddElement(Element element) => Elements.Add(element);
    public void AddElement(string name, dynamic value) => AddElement(new(name, value));
    public void RemoveElement(int index) => Elements.RemoveAt(index);
}
public class CompoundCollection
{
    public CompoundCollection() { }
    public CompoundCollection(List<Compound> compounds) => Compounds = compounds;
    public List<Compound> Compounds = new List<Compound>();
    public Compound this[string name] 
    {
        get
        {
            int index = Compounds.FindIndex(z => z.Name == name);
            if (index != -1)
                return Compounds[index];
            return null;
        }
        set
        {
            int index = Compounds.FindIndex(z => z.Name == name);
            if (index != -1)
                Compounds[index] = value;
        }
    }
    public Compound this[int index]
    {
        get
        {
            if(index >= 0 && index < Compounds.Count)
                return Compounds[index];
            return null;
        }
        set
        {
            if (index >= 0 && index < Compounds.Count)
                Compounds[index] = value;
        }
    }
    public int Count { get => Compounds.Count; }
    public void Add(Compound compound) => Compounds.Add(compound);
    public void Remove(Compound compound) => Compounds.Remove(compound);
    public void RemoveAt(int index) => Compounds.RemoveAt(index);
    public int IndexOf(string name) => Compounds.FindIndex(x => x.Name == name);       
    public void Clear() => Compounds = new List<Compound>();
}