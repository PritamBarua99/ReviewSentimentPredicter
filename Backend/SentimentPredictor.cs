using Microsoft.ML;

namespace CommentSentimentPredictor.Api
{
    public class SentimentPredictor
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _model;

        public SentimentPredictor()
        {
            _mlContext = new MLContext();
            string yelpDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");
            var dataView = _mlContext.Data.LoadFromTextFile<SentimentData>(yelpDataPath, hasHeader: false);
            var splitDataView = _mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var estimator = _mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.SentimentText))
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression("Label", "Features"));
            _model = estimator.Fit(splitDataView.TrainSet);
        }

        public SentimentPrediction Predict(string text)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(_model);
            var sentimentData = new SentimentData { SentimentText = text };
            return predictionEngine.Predict(sentimentData);
        }
    }
}
