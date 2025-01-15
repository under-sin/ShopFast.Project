namespace Domain.Entities;

public abstract class BaseEntity {
    public bool Active { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
