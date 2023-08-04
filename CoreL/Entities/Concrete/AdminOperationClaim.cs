namespace CoreL.Entities.Concrete
{
    public class AdminOperationClaim :IEntity
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
