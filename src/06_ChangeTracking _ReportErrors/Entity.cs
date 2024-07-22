namespace ChangeTrackingWithErrorsDemo;

public class Entity : ISwitchableChangeTracking
{
    public void AcceptChanges() => this.IsChanged = false;

    public bool IsChanged { get; protected set; }
    
    public bool IsTrackingChanges { get; set; }
}