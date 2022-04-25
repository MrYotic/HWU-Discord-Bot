namespace DooDHackAPI.CompoundPattern;
public class Element
{
    public Element() { }
    public Element(string name, dynamic value)
    {
        Name = name;
        Value = value;
    }
    public string Name { get; set; }
    public dynamic Value { get; set; }
}
public class ElementCollection
{
    public ElementCollection() { }
    public ElementCollection(List<Element> elements) => Elements = elements;
    public List<Element> Elements = new List<Element>();
    public Element this[string name]
    {
        get
        {
            int index = Elements.FindIndex(z => z.Name == name);
            if (index != -1)
                return Elements[index];
            return null;
        }
        set
        {
            int index = Elements.FindIndex(z => z.Name == name);
            if (index != -1)
                Elements[index] = value;
        }
    }
    public Element this[int index]
    {
        get
        {
            if (index >= 0 && index < Elements.Count)
                return Elements[index];
            return null;
        }
        set
        {
            if (index >= 0 && index < Elements.Count)
                Elements[index] = value;
        }
    }
    public int Count { get => Elements.Count; }
    public void Add(Element compound) => Elements.Add(compound);
    public void Remove(Element compound) => Elements.Remove(compound);
    public void RemoveAt(int index) => Elements.RemoveAt(index);
    public int IndexOf(string name) => Elements.FindIndex(x => x.Name == name);
    public void Clear() => Elements = new List<Element>();
}