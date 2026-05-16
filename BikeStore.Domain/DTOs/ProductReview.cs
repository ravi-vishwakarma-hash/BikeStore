namespace BikeStore.Domain.DTOs
{
    public record ProductReview
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public string ReviewerName { get; init; } = string.Empty;
        public string ReviewText { get; init; } = string.Empty;
        public int Rating { get; init; }
        public DateTime ReviewDate { get; init; }
    }

}
