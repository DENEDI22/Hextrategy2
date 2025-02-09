using System;

[Serializable]
public class RecoursesContainer
{
    public int Money;
    public int Food;
    public int Wood;
    public int Minerals;

    public RecoursesContainer(int _money, int _food, int _wood, int _minerals)
    {
        Money = _money;
        Food = _food;
        Wood = _wood;
        Minerals = _minerals;
    }

    public RecoursesContainer()
    {
        Money = 0;
        Food = 0;
        Wood = 0;
        Minerals = 0;
    }

    public static RecoursesContainer operator +(RecoursesContainer x, RecoursesContainer y)
    {
        RecoursesContainer addition = new RecoursesContainer
        {
            Money = x.Money + y.Money,
            Food = x.Food + y.Food,
            Wood = x.Wood + y.Wood,
            Minerals = x.Minerals + y.Minerals
        };
        return addition;
    }

    public static RecoursesContainer operator -(RecoursesContainer x, RecoursesContainer y)
    {
        RecoursesContainer addition = new RecoursesContainer
        {
            Money = x.Money - y.Money,
            Food = x.Food - y.Food,
            Wood = x.Wood - y.Wood,
            Minerals = x.Minerals - y.Minerals
        };
        return addition;
    }

    public static RecoursesContainer operator -(RecoursesContainer x)
    {
        RecoursesContainer opUnaryNegation = new RecoursesContainer
        {
            Money = -x.Money,
            Food = -x.Food,
            Wood = -x.Wood,
            Minerals = -x.Minerals
        };
        return opUnaryNegation;
    }

    public static RecoursesContainer operator *(RecoursesContainer x, RecoursesContainer y)
    {
        RecoursesContainer opMultiply = new RecoursesContainer
        {
            Money = x.Money * y.Money,
            Food = x.Food * y.Food,
            Wood = x.Wood * y.Wood,
            Minerals = x.Minerals * y.Minerals
        };
        return opMultiply;
    }

    public static RecoursesContainer operator *(RecoursesContainer x, int y)
    {
        RecoursesContainer opMultiply = new RecoursesContainer
        {
            Money = x.Money * y,
            Food = x.Food * y,
            Wood = x.Wood * y,
            Minerals = x.Minerals * y
        };
        return opMultiply;
    }

    public static RecoursesContainer operator /(RecoursesContainer x, RecoursesContainer y)
    {
        RecoursesContainer opDivision = new RecoursesContainer
        {
            Money = x.Money / y.Money,
            Food = x.Food / y.Food,
            Wood = x.Wood / y.Wood,
            Minerals = x.Minerals / y.Minerals
        };
        return opDivision;
    }

    public static RecoursesContainer operator /(RecoursesContainer x, int y)
    {
        RecoursesContainer opMultiply = new RecoursesContainer
        {
            Money = x.Money / y,
            Food = x.Food / y,
            Wood = x.Wood / y,
            Minerals = x.Minerals / y
        };
        return opMultiply;
    }

    public static bool operator >(RecoursesContainer x, RecoursesContainer y) =>
        x.Money > y.Money && x.Food > y.Food && x.Wood > y.Wood && x.Minerals > y.Minerals;

    public static bool operator <(RecoursesContainer x, RecoursesContainer y) =>
        x.Money < y.Money && x.Food < y.Food && x.Wood < y.Wood && x.Minerals < y.Minerals;

    public static bool operator >=(RecoursesContainer x, RecoursesContainer y) =>
        x.Money > y.Money && x.Food > y.Food && x.Wood > y.Wood && x.Minerals > y.Minerals;

    public static bool operator <=(RecoursesContainer x, RecoursesContainer y) =>
        x.Money < y.Money && x.Food < y.Food && x.Wood < y.Wood && x.Minerals < y.Minerals;
}