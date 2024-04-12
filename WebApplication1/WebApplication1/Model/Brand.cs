namespace WebApplication1.Model;

public class Brand : IComparable<Brand>, IComparable
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        return obj is Brand other
                ? CompareTo(other)
                : throw new ArgumentException($"Object must be of type {nameof(Brand)}");
    }

    public int CompareTo(Brand? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var brandIdComparison = BrandId.CompareTo(other.BrandId);
        if (brandIdComparison != 0) return brandIdComparison;
        return string.Compare(BrandName, other.BrandName, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return $"{nameof(BrandId)}: {BrandId}, {nameof(BrandName)}: {BrandName}, {nameof(Products)}: {Products}";
    }

    public static bool operator <(Brand? left, Brand? right)
    {
        return Comparer<Brand>.Default.Compare(left, right) < 0;
    }

    public static bool operator >(Brand? left, Brand? right)
    {
        return Comparer<Brand>.Default.Compare(left, right) > 0;
    }

    public static bool operator <=(Brand? left, Brand? right)
    {
        return Comparer<Brand>.Default.Compare(left, right) <= 0;
    }

    public static bool operator >=(Brand? left, Brand? right)
    {
        return Comparer<Brand>.Default.Compare(left, right) >= 0;
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}