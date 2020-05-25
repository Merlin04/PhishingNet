using System.IO;
using Microsoft.ML;
using Model.DataModels;

namespace ModelAccess
{
    public class Access
    {
        //Machine Learning model to load and use for predictions
        private const string MODEL_FILEPATH = @"../../../../Model/MLModel.zip";
        private readonly PredictionEngine<ModelInput, ModelOutput> _predEngine;

        public Access()
        {
            MLContext mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(GetAbsolutePath(MODEL_FILEPATH), out DataViewSchema inputSchema);
            _predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        public ModelOutput Predict(string predictText)
        {
            ModelInput data = new ModelInput
            {
                Email = predictText
            };
            ModelOutput predictionResult = _predEngine.Predict(data);
            return predictionResult;
        }

        private static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Access).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }
}