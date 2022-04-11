namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedOnUTC { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedOnUTC { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}