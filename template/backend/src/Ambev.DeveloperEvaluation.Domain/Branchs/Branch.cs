namespace Ambev.DeveloperEvaluation.Domain.Branchs;

public class Branch
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Cnpj { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Branch(
        string name,
        string cnpj,
        string address,
        string phone,
        string email,
        bool isActive)
    {
        Id = Guid.NewGuid();
        Name = name;
        Cnpj = cnpj;
        Address = address;
        Phone = phone;
        Email = email;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string name,
        string cnpj,
        string address,
        string phone,
        string email,
        bool isActive)
    {
        Name = name;
        Cnpj = cnpj;
        Address = address;
        Phone = phone;
        Email = email;
        IsActive = isActive;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
} 