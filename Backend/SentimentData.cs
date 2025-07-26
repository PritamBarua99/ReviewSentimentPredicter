
using Microsoft.ML.Data;

namespace CommentSentimentPredictor.Api
{
    public class SentimentData
    {
        [LoadColumn(0)]
        public string? SentimentText { get; set; }
        [LoadColumn(1), ColumnName("Label")]
        public bool Sentiment { get; set; } // 1 for positive, 0 for negative
    }

    public class SentimentPrediction 
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }
        public float Probability { get; set; } // Probability of the prediction being true 
    }
}
