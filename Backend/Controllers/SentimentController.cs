using Microsoft.AspNetCore.Mvc;

namespace CommentSentimentPredictor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentController : ControllerBase
    {
        private readonly SentimentPredictor _predictor;

        public SentimentController(SentimentPredictor predictor)
        {
            _predictor = predictor;
        }

        [HttpPost("PredictCustomerSentiment")]
        public ActionResult<SentimentPrediction> PredictCustomerSentiment([FromBody] SentimentData input)
        {
            if (input?.SentimentText == null)
            {
                return BadRequest();
            }
            return _predictor.Predict(input.SentimentText);
        }
    }
}
