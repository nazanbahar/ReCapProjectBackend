namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        // Move Type to UserOperationClaim.cs
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }

}
