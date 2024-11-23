using Microsoft.ML;

namespace SustenAI.API.Services.Recommendation
{

    public class RecommendationService
    {
        private readonly MLContext _mlContext;
        private ITransformer _modelo;

        public RecommendationService()
        {
            _mlContext = new MLContext();
        }

        public void TrainModel(IEnumerable<DispositivoRating> avaliacoes)
        {
            var dadosTreinamento = _mlContext.Data.LoadFromEnumerable(avaliacoes);

            var pipeline = _mlContext.Transforms
                .Conversion.MapValueToKey("userIdEncoded", nameof(DispositivoRating.UserId))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("dispositivoIdEncoded", nameof(DispositivoRating.DispositivoId)))
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(
                    labelColumnName: nameof(DispositivoRating.Label),
                    matrixColumnIndexColumnName: "userIdEncoded",
                    matrixRowIndexColumnName: "dispositivoIdEncoded"));

            _modelo = pipeline.Fit(dadosTreinamento);
        }

        public float PreverPontuacao(string idUsuario, string idDispositivo)
        {
            // Cria o mecanismo de previsão com o modelo treinado
            var motorPrevisao = _mlContext.Model.CreatePredictionEngine<DispositivoRating, DispositivoPrediction>(_modelo);

            // Realiza a previsão para um par de usuário e dispositivo
            var previsao = motorPrevisao.Predict(new DispositivoRating
            {
                UserId = idUsuario,
                DispositivoId = idDispositivo
            });

            // Trata valores inválidos como infinito ou NaN
            if (float.IsInfinity(previsao.Score) || float.IsNaN(previsao.Score))
            {
                return 0;
            }

            return previsao.Score;
        }
    }
}