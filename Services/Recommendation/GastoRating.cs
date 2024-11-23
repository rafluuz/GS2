namespace SustenAI.API.Services.Recommendation
{
    public class DispositivoRating
    {
        public string UserId { get; set; }
        public string DispositivoId { get; set; }
        public float Label { get; set; }
    }

    public class DispositivoPrediction
    {
        public float Score { get; set; }
    }
}