namespace InMemoryTest.ClaimRecoveries
{
    public class ClaimRecovery
    {
        public int Id { get; private set; }
        public int ClaimId { get; private set; }
        public int ClientId { get; private set; }
        public DateTime CreatedAt { get; set; }

        public ClaimRecovery(int id, int claimId, int clientId)
        {
            Id = id;
            ClaimId = claimId;
            ClientId = clientId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
